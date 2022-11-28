using System.Security.Policy;
using UniUSBSQMServer.Enums;

namespace UniUSBSQMServer
{
    internal sealed class SerialManager
    {
        private static SerialManager? instance;
        private static readonly object syncRoot = new();

        public static SerialManager Instance
        {
            get { 
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new SerialManager();
                    }
                }
                
                return instance; 
            }
        }

        private SerialManager()
        {
            //Load Settings
            _serialPortName = SettingsManager.SerialPortName;
            _serialPortIntervalSeconds = SettingsManager.SerialPortInterval;

            _settingsManager = SettingsManager.Instance;
            _settingsManager.SettingsChanged += SettingsManager_SettingsChanged;

            //Setup the timer interval
            _refreshTimer.Interval = _serialPortIntervalSeconds * 1000;
            //Timer Tick Handler
            _refreshTimer.Tick += RefreshTimer_Tick;

            //Setup the noResponse timer interval
            _noResponseTimer.Interval = 3000;
            //noResponse Timer Tick Handler
            _noResponseTimer.Tick += NoResponseTimer_Tick;

            simulateManager.SimulatorDataReceived += SimulatorDataReceivedHandler;

        }


        private Enums.SerialConnectedStates _connectionState = SerialConnectedStates.Disconnected; 
        private static string _serialPortName = "";
        private static int _serialPortIntervalSeconds = 30;
        private readonly SettingsManager _settingsManager;

        private static SimulateManager simulateManager = SimulateManager.Instance;
        


        //Serial Port
        private static readonly System.IO.Ports.SerialPort _serialPort = new();
        
        // Refresh timer - Used for trying to refind the USB device if port disappears
        private readonly System.Windows.Forms.Timer _refreshTimer = new();

        //No Response Timer - Message sent, but nothing came back - This can happen if a serial port like COM1 is the wrong device
        private readonly System.Windows.Forms.Timer _noResponseTimer = new();

        //Events
        public event EventHandler<SerialManagerStateChangedEventArgs>? SerialStateChanged;
        public event EventHandler<SerialManagerDataReceivedEventArgs>? SerialDataReceived;
        public event EventHandler<EventArgs>? SerialPollBegin;
        public event EventHandler<EventArgs>? SerialPollEnd;
        public event EventHandler<EventArgs>? SerialNoResponse;


        private void SettingsManager_SettingsChanged(object? sender, EventArgs e)
        {
            _serialPortName = SettingsManager.SerialPortName;
            _serialPortIntervalSeconds = SettingsManager.SerialPortInterval;
        }

        private void NoResponseTimer_Tick(object? sender, EventArgs e)
        {
            if (instance != null)
            {
                instance._noResponseTimer.Stop();
                SerialPortClose();
                TriggerSerialPollEnd();
                TriggerNoResponseEvent();
            }
        }

        private void TriggerSerialStateChangeEvent() {
            
            SerialManagerStateChangedEventArgs eventData = new()
            {
                ConnectedState = _connectionState,
                SerialPortName = _serialPortName,
                SerialPortInterval = _serialPortIntervalSeconds
            };
            SerialStateChanged?.Invoke(this, eventData);
        }

        private void TriggerSerialDataReceivedEvent(string rxData)
        {
            SerialManagerDataReceivedEventArgs eventData = new()
            {
                Data = rxData
            };
            SerialDataReceived?.Invoke(this, eventData);
        }

        private void TriggerSerialPollBegin()
        {
            EventArgs eventData = new();
            SerialPollBegin?.Invoke(this, eventData);
        }

        private void TriggerSerialPollEnd()
        {
            EventArgs eventData = new();
            SerialPollEnd?.Invoke(this, eventData);
        }

        private void TriggerNoResponseEvent()
        {
            EventArgs eventData = new();
            SerialNoResponse?.Invoke(this, eventData);
        }

        private void RefreshTimer_Tick(object? sender, EventArgs e)
        {
            
            if (_serialPortName == "Simulator")
            {
                SimulateManager.GetMessageRx();
                SimulateManager.GetMessageUx();
            }
            else
            {
                //We will read both the standard and the unaveraged on each poll, the ix command doesn't change and is read on first connecion.
                SendCommand("rx");

                SendCommand("ux");
            }
        }

        public static Enums.SerialConnectedStates ConnectionState
        {
            get
            {
                if (instance == null)
                {
                    return Enums.SerialConnectedStates.Disconnected;
                }
                else
                {
                    return instance._connectionState;
                }
            }
        }

        public void Connect()
        {
            _connectionState = SerialConnectedStates.Connected; // "connected";

            SerialPortOpen();

            TriggerSerialStateChangeEvent();
        }

        public void Disconnect()
        {
            SerialPortClose();

            _connectionState = SerialConnectedStates.Disconnected; // "disconnected";
            TriggerSerialStateChangeEvent();
        }

        private void SerialPortOpen()
        {
            _serialPort.PortName = _serialPortName;
            _serialPort.BaudRate = 115200;

            if (_serialPortName == "Simulator")
            {
                SimulateManager.Connect();

                _connectionState = SerialConnectedStates.Connected; // "connected";

                SimulateManager.GetMessageIx();
                SimulateManager.GetMessageRx();
                SimulateManager.GetMessageUx();

                _refreshTimer.Start();

            }
            else
            {
                if (!_serialPort.IsOpen)
                {
                     //attach Event Listener
                    _serialPort.DataReceived += SerialDataReceivedHandler;
                
                    //Open the port
                    _serialPort.Open();

                    if (_serialPort.IsOpen)
                    {
                        _connectionState = SerialConnectedStates.Connected; // "connected";

                        //Get unit information
                        SendCommand("ix");
                
                        //Get an initial reading for rx
                        SendCommand("rx");
                
                        //Get an initial reading for ux
                        SendCommand("ux");
                
                        //start the timer
                        _refreshTimer.Start();
                    }
                }
            }

            TriggerSerialStateChangeEvent();
        }

        private void SerialPortClose()
        {
            if (_serialPortName == "Simulator")
            {
                SimulateManager.Disconnect();
                _connectionState = SerialConnectedStates.Disconnected;
                TriggerSerialStateChangeEvent();
            }
            else
            {
                if (_serialPort.IsOpen)
                {
                    //stop the timer
                    _refreshTimer.Stop();
                
                    //Detach Event Listener
                    _serialPort.DataReceived -= SerialDataReceivedHandler;
                
                    //Close the port
                    _serialPort.Close();
                    _connectionState = SerialConnectedStates.Disconnected; // "disconnected";
                    TriggerSerialStateChangeEvent();
                }
            }
        }

        private static void SerialDataReceivedHandler(object? sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (instance == null) return;

            string data = _serialPort.ReadLine();

            //Update the latest SQM Readings Store

            if (data.StartsWith("i,"))
            {
                //ix command
                instance._noResponseTimer.Stop();
                SQMLatestMessageReading.SetReading("ix", data);
            }
            else if (data.StartsWith("r,"))
            {
                //rx command
                instance._noResponseTimer.Stop();
                SQMLatestMessageReading.SetReading("rx", data);
            }
            else if (data.StartsWith("u,"))
            {
                //ux command
                instance._noResponseTimer.Stop();
                SQMLatestMessageReading.SetReading("ux", data);

            }
            instance.TriggerSerialDataReceivedEvent(data);
            instance.TriggerSerialPollEnd();
        }

        private static void SimulatorDataReceivedHandler(object? sender, SimulatorDataReceivedEventArgs e)
        {
            if (instance == null) return;

            string data = e.Data;

            //Update the latest SQM Readings Store

            if (data.StartsWith("i,"))
            {
                //ix command
                instance._noResponseTimer.Stop();
                SQMLatestMessageReading.SetReading("ix", data);
            }
            else if (data.StartsWith("r,"))
            {
                //rx command
                instance._noResponseTimer.Stop();
                SQMLatestMessageReading.SetReading("rx", data);
            }
            else if (data.StartsWith("u,"))
            {
                //ux command
                instance._noResponseTimer.Stop();
                SQMLatestMessageReading.SetReading("ux", data);

            }

            instance.TriggerSerialDataReceivedEvent(data);
            instance.TriggerSerialPollEnd();

        }

        public static bool SendCommand(string command )
        {
            if (instance == null) return false;

            string[] validCommands = new string[] { "ix", "rx", "ux" };

            if (!validCommands.Contains(command))
            {
                System.Diagnostics.Debug.WriteLine($"Invalid Command: '{command}'");
                return false;
            }


            //Simulator
            if (_serialPortName == "Simulator")
            {
                instance.TriggerSerialPollBegin();
                switch (command)
                    {
                    case "ix":
                        SimulateManager.GetMessageIx();
                        return true;
                    case "rx":
                        SimulateManager.GetMessageRx();
                        return true;
                    case "ux":
                        SimulateManager.GetMessageUx();
                        return true;
                }
            }

            //Non Simulator
            retry_send_message:

            //Unit Information
            if (_serialPort.IsOpen)
            {
                System.Diagnostics.Debug.WriteLine($"Sending command '{command}'");
                instance.TriggerSerialPollBegin();
                _serialPort.WriteLine(command);
                instance._noResponseTimer.Start();
                
                return true;
            }
            else
            {
                //Port is closed attempt to reconnect
                System.Diagnostics.Debug.WriteLine("Port Closed. no command sent");
                int retryCounter=0;

                while (!_serialPort.IsOpen)
                {
                    retryCounter += 1;

                    if (retryCounter > 20)
                    { break; }

                    System.Diagnostics.Debug.WriteLine($"Attempting to reconnect serial. Attempt: {retryCounter}");

                    instance._connectionState = SerialConnectedStates.Retry; // "retry";
                    instance.TriggerSerialStateChangeEvent();

                    try {
                        //Need to wait for the port to reappear / be plugged back in
                        
                        if (System.IO.Ports.SerialPort.GetPortNames().Contains(_serialPortName))
                        {
                            _serialPort.Open();
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("Waiting for port to re-appear/connected");
                        }
                    }
                    catch ( Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.ToString());
                    }


                    if (_serialPort.IsOpen)
                    {
                        instance._connectionState = SerialConnectedStates.Connected; // "connected";
                        instance.TriggerSerialStateChangeEvent();

                        goto retry_send_message;
                    }
                    Thread.Sleep(1000);
                }

                System.Diagnostics.Debug.WriteLine($"Reconnect serial failed. {retryCounter}");

                //Exceeded retry counter
                return false;
            }
        }
    }
}