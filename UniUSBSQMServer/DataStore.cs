
namespace UniUSBSQMServer
{
    internal class DataStore
    {

        //Singleton
        private static DataStore? store;
        private static readonly object syncRoot = new();

        public static DataStore Store
        {
            get
            {
                if (store == null)
                {
                    lock (syncRoot)
                    {
                        if (store == null)
                            store = new DataStore();
                    }
                }

                return store;
            }
        }

        private DataStore()
        {
            //data = new();

            settings = SettingsManager.Instance;

            _memoryLoggingIntervalSeconds = SettingsManager.MemoryLoggingInterval;
            _memoryLoggingRecordLimit = SettingsManager.MemoryLoggingRecordLimit;
            _memoryLoggingNoLimit = SettingsManager.MemoryLoggingNoLimit;

            _fileLoggingEnabled = SettingsManager.FileLoggingEnabled;
            _fileLoggingUseDefaultPath = SettingsManager.FileLoggingDefaultPath;
            _fileLoggingCustomPath = SettingsManager.FileLoggingCustomPath;

            //Check default logging folder folder path Exists, create if not
            if (!Directory.Exists(Path.Combine(Application.StartupPath, "logs")))
            {
                Directory.CreateDirectory(Path.Combine(Application.StartupPath, "logs"));
            }

            //Settings Manager event handler
            settings.SettingsChanged += Settings_SettingsChanged;

            //SerialManager  event handler
            SerialManager.Instance.SerialStateChanged += Instance_SerialStateChanged;

            memoryLoggingTimer.Interval = _memoryLoggingIntervalSeconds;
            memoryLoggingTimer.Enabled = true;
            memoryLoggingTimer.Tick += LoggingTimer_Tick;            
        }



        //The Settings
        readonly SettingsManager settings;

        //The store
        private static readonly List<DataStoreDataPoint>? data = new();

        //Timer for performing the logging events
        private static readonly System.Windows.Forms.Timer memoryLoggingTimer = new();

        //SerialManager to monitor for state change
        //private static SerialManager serialManager = SerialManager.Instance;
        private static bool serialConnected = false;

        private static int _memoryLoggingIntervalSeconds = 0;
        private static int _memoryLoggingRecordLimit = 0;
        private static bool _memoryLoggingNoLimit = false;

        private static bool _fileLoggingEnabled = false;
        private static bool _fileLoggingUseDefaultPath = false;
        private static string _fileLoggingCustomPath = Path.Combine(Application.StartupPath, "logs");
        //Session Logging Filename - create new name each time app is started.
        private static string filename = $"USB_SQM_Server_{ DateTime.Now:yyyy-MM-dd-HH-mm-ss zz}.log";


        //Events
        public event EventHandler<EventArgs>? DataStoreCleared;
        public event EventHandler<EventArgs>? DataStoreRecordAdded;
        
        //Properties
        public static DataStoreDataPoint GetLatestRecord()
        {
            if (data == null)
            {
                return new DataStoreDataPoint();
            }
            else
            {
                return data.Last().Copy(); //send back a copy of the point
            }
        }

        public static List<DataStoreDataPoint> GetAllData()
        {
            if (data == null)
            {
                return new List<DataStoreDataPoint>();
            }
            else
            {
                return data.ToList(); // Send back a copy of the list.
            }
        }

        public static int DataStoreLength
        {
            get
            {
                if (data == null)
                {
                    return 0;
                }
                else
                {
                    return data.Count;
                }
            }
        }

        //External Event Handlers
        private void Settings_SettingsChanged(object? sender, EventArgs e)
        {
            _memoryLoggingIntervalSeconds = SettingsManager.MemoryLoggingInterval;
            _memoryLoggingRecordLimit = SettingsManager.MemoryLoggingRecordLimit;
            _memoryLoggingNoLimit = SettingsManager.MemoryLoggingNoLimit;

            memoryLoggingTimer.Interval = _memoryLoggingIntervalSeconds * 1000;

            _fileLoggingEnabled = SettingsManager.FileLoggingEnabled;
            _fileLoggingUseDefaultPath = SettingsManager.FileLoggingDefaultPath;
            _fileLoggingCustomPath = SettingsManager.FileLoggingCustomPath;

            //Check default logging folder folder path Exists, create if not
            if (!Directory.Exists(Path.Combine(Application.StartupPath, "logs")))
            {
                Directory.CreateDirectory(Path.Combine(Application.StartupPath, "logs"));
            }

            //Create the filename
            filename = $"USB_SQM_Server_{ DateTime.Now:yyyy-MM-dd-HH-mm-ss zz}.log";
        }

        private void Instance_SerialStateChanged(object? sender, SerialManagerStateChangedEventArgs e)
        {
            //Watch for serial connection state, log only when connected
            if (e.ConnectedState == Enums.SerialConnectedStates.Connected)
            {
                serialConnected = true;
                memoryLoggingTimer.Interval = _memoryLoggingIntervalSeconds * 1000;
                memoryLoggingTimer.Start();
            }
            else
            {
                serialConnected = false;
                memoryLoggingTimer.Stop();
            }
        }

        //Local Events
        private void TriggerClearedEvent()
        {
            EventArgs eventData = new();
            DataStoreCleared?.Invoke(this, eventData);
        }

        private void TriggeDataStoreRecordAdded()
        {
            EventArgs eventData = new();
            DataStoreRecordAdded?.Invoke(this, eventData);
        }

        private void LoggingTimer_Tick(object? sender, EventArgs e)
        {
            if (!serialConnected)
            {
                //exit if not connected
                return;
            }

            //Build the datapoint
            //Check there is both an rx and ux in the snapshot
            bool hasData = false;
            DataStoreDataPoint datapoint = new();

            if (SQMLatestMessageReading.HasReadingForCommand("ux") && SQMLatestMessageReading.HasReadingForCommand("rx"))
            {
                //string rxMessage;
                SQMLatestMessageReading.GetReading("rx", out string? rxMessage);
                //string uxMessage;
                SQMLatestMessageReading.GetReading("ux", out string? uxMessage);

                if (rxMessage != null && uxMessage != null)
                {
                    string[] dataRx = rxMessage.Split(',');
                    string[] dataUx = uxMessage.Split(',');
                    datapoint.Timestamp = DateTime.Now;
                    datapoint.AvgMPAS = Utility.ConvertDataToDouble(dataRx[1]);
                    datapoint.RawMPAS = Utility.ConvertDataToDouble(dataUx[1]);
                    datapoint.AvgTemp = Utility.ConvertDataToDouble(dataRx[5]);
                    datapoint.NELM = Utility.CalcNELM(Utility.ConvertDataToDouble(dataRx[1]));

                    hasData = true;
                }
                else { hasData = false; }
            }

            //Memory Logging
            if (hasData)
            {
                AddDataPoint(datapoint);
            }

            //File Logging
            if (_fileLoggingEnabled && hasData)
            {
                string fullpathfile;
                if (_fileLoggingUseDefaultPath)
                {
                    fullpathfile = Path.Combine(Application.StartupPath, "logs", filename);
                }
                else
                {
                    fullpathfile = Path.Combine(_fileLoggingCustomPath, filename);
                }
                try
                {
                    File.AppendAllText(fullpathfile,$"{datapoint.Timestamp:yyyy-MM-dd-HH:mm:ss}, {datapoint.RawMPAS:#0.00} raw-mpas, {datapoint.AvgMPAS:#0.00} avg-mpas, {datapoint.AvgTemp:#0.0} C, {datapoint.NELM:#0.00} NELM\n");
                }
                catch (Exception ex)
                {
                    DialogResult result = MessageBox.Show($"Error writing log - {ex.Message} \n Retry or Cancel to halt file logging.", "File Logging Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    if (result == DialogResult.Cancel)
                    {
                        _fileLoggingEnabled = false;
                    }
                }   
            }
        }

        public static void ClearStore()
        {
            if (data == null || store == null) return;

                data.Clear();
                store.TriggerClearedEvent();
        }

        private static void AddDataPoint(DataStoreDataPoint datapoint)
        {
            if (data == null || store == null) return;
            
            while (!_memoryLoggingNoLimit && data.Count >= _memoryLoggingRecordLimit && data.Count > 0)
            {
                //remove 1st point
                data.RemoveAt(0);
            } //keep removing first point until space available

            //Add record
            data.Add(datapoint);
            store.TriggeDataStoreRecordAdded();
        }
    }
}
