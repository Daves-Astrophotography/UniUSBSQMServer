using System.Configuration;

namespace UniUSBSQMServer
{
    public sealed class SettingsManager
    {

        private static SettingsManager? instance;
        private static readonly object syncRoot = new();

        public static SettingsManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new SettingsManager();
                    }
                }

                return instance;
            }
        }

        public SettingsManager()
        {
            LoadSettings();
        }

        //Constants
        public const int SERIAL_POLL_MINIMUM_INTERVAL_SECONDS = 1;
        public const int SERIAL_POLL_MAXIMUM_INTERVAL_SECONDS = 3600;
        
        public const int LOGGING_MINIMUM_INTERVAL_SECONDS = 1;
        public const int LOGGING_MAXIMUM_INTERVAL_SECONDS = 3600;

        public const int LOGGING_MINIMUM_RECORDS = 10;
        public const int LOGGING_MAXIMUM_RECORDS = 10000;

        public const int SERVER_PORT_MAXIMUM = 65535;
        public const int SERVER_PORT_MINIMUM = 1024;


        //Trend and Units
        private static Enums.TemperatureUnits _temperatureUnits = Enums.TemperatureUnits.Centrigrade;
        private static decimal _trendMax = 30;
        private static decimal _trendMin = 0;
        private static bool _trendDrawRawMPas = true;
        private static bool _trendDrawAvgMPas = true;
        private static bool _trendDrawTemp = true;
        private static bool _trendDrawNELM = true;
        private static Color _trendRawMPasColor = Color.Red;
        private static Color _trendAvgMPasColor = Color.Blue;
        private static Color _trendTempColor = Color.Yellow;
        private static Color _trendNELMColor = Color.Green;

        //Server
        private static int _serverPort = 10000;

        //Serial
        private static string _comPortName = "";
        private static int _comPortInterval = 30;

        //Memory Logging
        private static int _memoryLoggingInterval = 0;
        private static int _memoryLoggingRecordLimit = 0;
        private static bool _memoryLoggingNoLimit = false;

        //File Logging
        private static bool _fileLoggingEnabled = false;
        private static bool _fileLoggingUseDefaultPath = false;
        private static string _fileLoggingCustomPath = Path.Combine(Application.StartupPath, "logs");


        //Events
        public event EventHandler<EventArgs>? SettingsChanged;

        private void TriggerSettingsChangedEvent()
        {
            EventArgs eventData = new();
            SettingsChanged?.Invoke(this, eventData);
        }

        //Serial
        public static string SerialPortName
        {
            get
            {
                return _comPortName;
            }
            set
            {
                _comPortName = value;
            }
        }

        public static int SerialPortInterval
        {
            get
            {
                return _comPortInterval;
            }
            set
            {
                _comPortInterval = value;    
            }
        }

        //Server Port Number
        public static int ServerPort
        {
            get
            {
                return _serverPort;
            }
            set
            {
                _serverPort = value;
            }
        }

        //Trend Min Max
        public static Enums.TemperatureUnits TemperatureUnits
        {
            get
            {
                return _temperatureUnits;
            }
            set
            {
                _temperatureUnits = value;
            }
        }

        public static decimal TrendMax
        {
            get
            {
                return _trendMax;
            }
            set
            {
                _trendMax = value;
            }
        }

        public static decimal TrendMin
        {
            get
            {
                return _trendMin;
            }
            set
            {
                _trendMin = value;
            }
        }

        //Draw Trends
        public static bool TrendDrawRawMPas
        {
            get 
            { 
                return _trendDrawRawMPas;
            }
            set 
            {
                _trendDrawRawMPas = value;
            }
        }
        public static bool TrendDrawAvgMPas
        {
            get
            {
                return _trendDrawAvgMPas;
            }
            set
            {
                _trendDrawAvgMPas = value;
            }
        }

        public static bool TrendDrawTemp
        {
            get
            {
                return _trendDrawTemp;
            }
            set
            {
                _trendDrawTemp = value;
            }
        }

        public static bool TrendDrawNELM
        {
            get
            {
                return _trendDrawNELM;
            }
            set
            {
                _trendDrawNELM = value;
            }
        }

        //Trend Colours
        public static Color TrendRawMPasColor
        {
            get
            {
                return _trendRawMPasColor;
            }
            set
            {
                _trendRawMPasColor = value;
            }
        }
        public static Color TrendAvgMPasColor
        {
            get
            {
                return _trendAvgMPasColor;
            }
            set
            {
                _trendAvgMPasColor = value;
            }
        }
        public static Color TrendTempColor
        {
            get
            {
                return _trendTempColor;
            }
            set
            {
                _trendTempColor = value;
            }
        }
        public static Color TrendNELMColor
        {
            get
            {
                return _trendNELMColor;
            }
            set
            {
                _trendNELMColor = value;
            }
        }

        //Memnory Logging
        public static int MemoryLoggingInterval
        {
            get
            {
                return _memoryLoggingInterval;
            }
            set
            {
                _memoryLoggingInterval = value;
            }
        }
        public static int MemoryLoggingRecordLimit
        {
            get
            {
                return _memoryLoggingRecordLimit;
            }
            set
            {
                _memoryLoggingRecordLimit = value;
            }
        }
        public static bool MemoryLoggingNoLimit
        {
            get
            {
                return _memoryLoggingNoLimit;
            }
            set
            {
                _memoryLoggingNoLimit = value;
            }
        }

        //File Logging
        public static bool FileLoggingEnabled
        {
            get
            {
                return _fileLoggingEnabled;
            }
            set
            {
                _fileLoggingEnabled = value;
            }
        }

        public static bool FileLoggingDefaultPath
        {
            get
            {
                return _fileLoggingUseDefaultPath;
            }
            set
            {
                _fileLoggingUseDefaultPath = value;
            }
        }

        public static string FileLoggingCustomPath
        {
            get { return _fileLoggingCustomPath; }
            set
            {
                _fileLoggingCustomPath = value;
            }
        }

        public static void EndSettingsChange()
        {
            SaveSettings();
        }

        static void LoadSettings()
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;

            //Serial
            //Port Nanme
            var setting = settings["SerialPortName"];

            if (setting == null)
            {
                settings.Remove("SerialPortName");
                settings.Add("SerialPortName", "Simulator");  // Default to Simulator
                _comPortName = "Simulator";
            }
            else
            {
                _comPortName = setting.Value;
            }

            //Refresh interval
            setting = settings["SerialPortInterval"];

            if (setting == null)
            {
                settings.Remove("SerialPortInterval");
                settings.Add("SerialPortInterval", "60");
                _comPortInterval = 60;
            }
            else
            {
                try
                {
                    _comPortInterval = int.Parse(setting.Value);
                }
                catch (Exception)
                {
                    _comPortInterval = 60000;
                }
            }

            //Server Settings
            //Server Port Number
            setting = settings["ServerPort"];

            if (setting == null)
            {
                settings.Remove("ServerPort");
                settings.Add("ServerPort", "10000");
                _serverPort = 10000;
            }
            else
            {
                _serverPort = int.Parse(setting.Value);
            }

            //Trend Max/Min
            setting = settings["TrendMax"];

            if (setting == null)
            {
                settings.Remove("TrendMax");
                settings.Add("TrendMax", "30");
                _trendMax = 30;
            }
            else
            {
                try
                {
                    _trendMax = Decimal.Parse(setting.Value);
                }
                catch (Exception)
                {
                    _trendMax = 30;
                }
            }

            setting = settings["TrendMin"];

            if (setting == null)
            {
                settings.Remove("TrendMin");
                settings.Add("TrendMin", "0");
                _trendMin = 0;
            }
            else
            {
                try
                {
                    _trendMin = Decimal.Parse(setting.Value);
                }
                catch (Exception)
                {
                    _trendMin = 0;
                }
            }

            //Temperature Units
            setting = settings["TemperatureUnits"];

            if (setting == null)
            {
                settings.Remove("TemperatureUnits");
                settings.Add("TemperatureUnits", "C");
                _temperatureUnits = Enums.TemperatureUnits.Centrigrade;
            }
            else
            {
                if (setting.Value == "C")
                {
                    _temperatureUnits = Enums.TemperatureUnits.Centrigrade;
                } else
                {
                    _temperatureUnits = Enums.TemperatureUnits.Fahrenheit;
                }
            }

            //Draw Trends
            setting = settings["TrendDrawRawMPas"];

            if (setting == null)
            {
                settings.Remove("TrendDrawRawMPas");
                settings.Add("TrendDrawRawMPas", "True");
                _trendDrawRawMPas = true;
            }
            else
            {
                _trendDrawRawMPas = bool.Parse(setting.Value);
            }

            setting = settings["TrendDrawAvgMPas"];

            if (setting == null)
            {
                settings.Remove("TrendDrawAvgMPas");
                settings.Add("TrendDrawAvgMPas", "True");
                _trendDrawAvgMPas = true;
            }
            else
            {
                _trendDrawAvgMPas = bool.Parse(setting.Value);
            }

            setting = settings["TrendDrawAvgTemp"];

            if (setting == null)
            {
                settings.Remove("TrendDrawAvgTemp");
                settings.Add("TrendDrawAvgTemp", "True");
                _trendDrawTemp = true;
            }
            else
            {
                _trendDrawTemp = bool.Parse(setting.Value);
            }

            setting = settings["TrendDrawNELM"];

            if (setting == null)
            {
                settings.Remove("TrendDrawNELM");
                settings.Add("TrendDrawNELM", "True");
                _trendDrawNELM = true;
            }
            else
            {
                _trendDrawNELM = bool.Parse(setting.Value);
            }

            //Trend Colors
            setting = settings["TrendColorRawMPas"];

            if (setting == null)
            {
                settings.Remove("TrendColorRawMPas");
                settings.Add("TrendColorRawMPas", ColorTranslator.ToHtml(Color.Red).ToString());
                _trendRawMPasColor = Color.Red;
            }
            else
            {
                _trendRawMPasColor = ColorTranslator.FromHtml(setting.Value);
            }

            setting = settings["TrendColorAvgMPas"];

            if (setting == null)
            {
                settings.Remove("TrendColorAvgMPas");
                settings.Add("TrendColorAvgMPas", ColorTranslator.ToHtml(Color.Blue).ToString());
                _trendAvgMPasColor = Color.Blue;
            }
            else
            {
                _trendAvgMPasColor = ColorTranslator.FromHtml(setting.Value);
            }

            setting = settings["TrendColorAvgTemp"];

            if (setting == null)
            {
                settings.Remove("TrendColorAvgTemp");
                settings.Add("TrendColorAvgTemp", ColorTranslator.ToHtml(Color.Yellow).ToString());
                _trendTempColor = Color.Yellow;
            }
            else
            {
                _trendTempColor = ColorTranslator.FromHtml(setting.Value);
            }

            setting = settings["TrendColorNELM"];

            if (setting == null)
            {
                settings.Remove("TrendColorNELM");
                settings.Add("TrendColorNELM", ColorTranslator.ToHtml(Color.Lime).ToString());
                _trendNELMColor = Color.Lime;
            }
            else
            {
                _trendNELMColor = ColorTranslator.FromHtml(setting.Value);
            }

            //Memory Logging
            setting = settings["MemoryLoggingInterval"];

            if (setting == null)
            {
                settings.Remove("MemoryLoggingInterval");
                settings.Add("MemoryLoggingInterval", "10");
                _memoryLoggingInterval = 10;
            }
            else
            {
                _memoryLoggingInterval = int.Parse(setting.Value);
                if (_memoryLoggingInterval > SettingsManager.LOGGING_MAXIMUM_INTERVAL_SECONDS) { _memoryLoggingInterval = SettingsManager.LOGGING_MAXIMUM_INTERVAL_SECONDS; }
                if (_memoryLoggingInterval < SettingsManager.LOGGING_MINIMUM_INTERVAL_SECONDS) { _memoryLoggingInterval = SettingsManager.LOGGING_MINIMUM_INTERVAL_SECONDS; }
            }

            //Logging Number Point
            setting = settings["MemoryLoggingRecordLimit"];

            if (setting == null)
            {
                settings.Remove("MemoryLoggingRecordLimit");
                settings.Add("MemoryLoggingRecordLimit", "360");
                _memoryLoggingRecordLimit = 360;
            }
            else
            {
                _memoryLoggingRecordLimit = int.Parse(setting.Value);
            }

            //No Record Limit
            setting = settings["MemoryLoggingNoLimit"];

            if (setting == null)
            {
                settings.Remove("MemoryLoggingNoLimit");
                settings.Add("MemoryLoggingNoLimit", "false");
                _memoryLoggingNoLimit = false;
            }
            else
            {
                _memoryLoggingNoLimit = bool.Parse(setting.Value);
            }

            setting = settings["FileLoggingEnabled"];

            if (setting == null)
            {
                settings.Remove("FileLoggingEnabled");
                settings.Add("FileLoggingEnabled", "false");
                _fileLoggingEnabled = false;
            }
            else
            {
                _fileLoggingEnabled = bool.Parse(setting.Value);
            }

            //File Default Path
            setting = settings["FileLoggingUseDefaultPath"];

            if (setting == null)
            {
                settings.Remove("FileLoggingUseDefaultPath");
                settings.Add("FileLoggingUseDefaultPath", "true");
                _fileLoggingUseDefaultPath = true;
            }
            else
            {
                _fileLoggingUseDefaultPath = bool.Parse(setting.Value);
            }

            //File Custom Path
            setting = settings["FileLoggingCustomPath"];

            if (setting == null)
            {
                settings.Remove("FileLoggingCustomPath");
                settings.Add("FileLoggingCustomPath", Path.Combine(Application.StartupPath, "logs"));
                _fileLoggingCustomPath = Path.Combine(Application.StartupPath, "logs");
            }
            else
            {
                _fileLoggingCustomPath = setting.Value;
            }

            configFile.Save(ConfigurationSaveMode.Full);
        }

        static void SaveSettings()
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;

            //Serial
            settings.Remove("SerialPortName");
            settings.Add("SerialPortName", _comPortName);

            settings.Remove("SerialPortInterval");
            settings.Add("SerialPortInterval", _comPortInterval.ToString());


            //Server Port Number
            settings.Remove("ServerPort");
            settings.Add("ServerPort", _serverPort.ToString());

            //Trend Max / Min
            settings.Remove("TrendMax");
            settings.Add("TrendMax", _trendMax.ToString());

            settings.Remove("TrendMin");
            settings.Add("TrendMin", _trendMin.ToString());

            //Temperature Units
            settings.Remove("TemperatureUnits");
            if (_temperatureUnits == Enums.TemperatureUnits.Centrigrade)
            {
                settings.Add("TemperatureUnits", "C");
            } else
            {
                settings.Add("TemperatureUnits", "F");
            }

            //Draw Trends
            settings.Remove("TrendDrawRawMPas");
            settings.Add("TrendDrawRawMPas", _trendDrawRawMPas.ToString());
            settings.Remove("TrendDrawAvgMPas");
            settings.Add("TrendDrawAvgMPas", _trendDrawAvgMPas.ToString());
            settings.Remove("TrendDrawAvgTemp");
            settings.Add("TrendDrawAvgTemp", _trendDrawTemp.ToString());
            settings.Remove("TrendDrawNELM");
            settings.Add("TrendDrawNELM", _trendDrawNELM.ToString());

            //Trend Colors
            settings.Remove("TrendColorRawMPas");
            settings.Add("TrendColorRawMPas", ColorTranslator.ToHtml(_trendRawMPasColor).ToString());
            settings.Remove("TrendColorAvgMPas");
            settings.Add("TrendColorAvgMPas", ColorTranslator.ToHtml(_trendAvgMPasColor).ToString());
            settings.Remove("TrendColorAvgTemp");
            settings.Add("TrendColorAvgTemp", ColorTranslator.ToHtml(_trendTempColor).ToString());
            settings.Remove("TrendColorNELM");
            settings.Add("TrendColorNELM", ColorTranslator.ToHtml(_trendNELMColor).ToString());

            //Memory Logging
            settings.Remove("MemoryLoggingInterval");
            settings.Add("MemoryLoggingInterval", _memoryLoggingInterval.ToString());
            settings.Remove("MemoryLoggingRecordLimit");
            settings.Add("MemoryLoggingRecordLimit", _memoryLoggingRecordLimit.ToString());
            settings.Remove("MemoryLoggingNoLimit");
            settings.Add("MemoryLoggingNoLimit", _memoryLoggingNoLimit.ToString());

            //File Logging
            settings.Remove("FileLoggingUseDefaultPath");
            settings.Add("FileLoggingUseDefaultPath", _fileLoggingUseDefaultPath.ToString());
            settings.Remove("FileLoggingCustomPath");
            settings.Add("FileLoggingCustomPath", _fileLoggingCustomPath);
            settings.Remove("FileLoggingEnabled");
            settings.Add("FileLoggingEnabled", _fileLoggingEnabled.ToString());

            configFile.Save(ConfigurationSaveMode.Full);
            if (instance != null)
            {
                instance.TriggerSettingsChangedEvent();
            }
        }




    }
}
