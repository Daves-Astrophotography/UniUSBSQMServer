using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UniUSBSQMServer
{
    internal sealed class SimulateManager
    {

        private static SimulateManager? instance;
        private static readonly object syncRoot = new();
        public static SimulateManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new SimulateManager();
                    }
                }

                return instance;
            }
        }

        private SimulateManager()
        {

            _settingsManager = SettingsManager.Instance;

            _simulatorTimer.Enabled = false;
            _simulatorTimer.Interval= 1000;
            _simulatorTimer.Tick += _simulatorTimer_Tick;

        }


        private readonly SettingsManager? _settingsManager;
        
        private static System.Windows.Forms.Timer _simulatorTimer = new();

        private static bool _simulatorIncrement = true;
        private static double _simulatorCounter = -1;
        private static double _simulatorRate = 1;

        private static string _ixMessage = "i,00000001,00000001,00000001,00000000";
        private static string _uxMessage = "";
        private static string _rxMessage = "";

        private static string _sentData = string.Empty;

        // r, 06.70m,0000022921Hz,0000000020c,0000000.000s, 039.4C
        // 0123456789 123456789 123456789 123456789 123456789 123456

        // u, 06.70m,0000022921Hz,0000000020c,0000000.000s, 039.4C
        // 0123456789 123456789 123456789 123456789 123456789 123456

        // i,00000002,00000003,00000001,00000413
        // 0123456789 123456789 123456789 12345678

        public event EventHandler<SimulatorDataReceivedEventArgs>? SimulatorDataReceived;

        private void _simulatorTimer_Tick(object? sender, EventArgs e)
        {
            // modify the counter which is used as a degrees value within a sine and cosine function for generating the 
            // simulated value
            
            if (_simulatorIncrement)
            {
                _simulatorCounter += _simulatorRate;

                if (_simulatorCounter >= 360)
                {
                    _simulatorCounter = 0;
                }
            }


            //Note: Convert the counter from a degress value to radians, then perform sin/cos, +1 shifts the curve from -1 to +1 to 0 to +2, then /2 to get back to 0 to 1 range of curve
            // use this to multiply by the range of trend, then add the trend minimum to pull back into valid range of trend.


            //Calculate the value for the Mpas Raw
            double mpas = ((Math.Sin(Convert.ToDouble(_simulatorCounter) * Math.PI / 180) + 1) / 2) * (Convert.ToDouble(SettingsManager.TrendMax) - Convert.ToDouble(SettingsManager.TrendMin)) + Convert.ToDouble(SettingsManager.TrendMin);

            //Calculate the value for the mpas average - this will be a simple inverse of the raw
            double mpasAvg = (((Math.Sin(Convert.ToDouble(_simulatorCounter+ 180) * Math.PI / 180) + 1) / 2) * (Convert.ToDouble(SettingsManager.TrendMax) - Convert.ToDouble(SettingsManager.TrendMin))) + Convert.ToDouble(SettingsManager.TrendMin);

            //Caclulate the value for the temp.
            double temp = (((Math.Cos(Convert.ToDouble(_simulatorCounter) * Math.PI / 180) + 1) / 2) * (Convert.ToDouble(SettingsManager.TrendMax) - Convert.ToDouble(SettingsManager.TrendMin))) + Convert.ToDouble(SettingsManager.TrendMin);

            _uxMessage = $"u, " + mpas.ToString("00.00") + "m,0000022921Hz,0000000020c,0000000.000s," + temp.ToString("000.0") + "C";
            _rxMessage = $"r, " + mpasAvg.ToString("00.00") + "m,0000022921Hz,0000000020c,0000000.000s," + temp.ToString("000.0") + "C";

        }

        private void TriggerSerialDataReceivedEvent(string command)
        {
            if (command == "ix")
            {
                _sentData = _ixMessage;
            }

            if (command == "ux")
            {
                _sentData = _uxMessage;
            }

            if (command == "rx")
            {
                _sentData = _rxMessage;
            }
            
            SimulatorDataReceivedEventArgs eventData = new()
            {
                Data = _sentData
            };
            SimulatorDataReceived?.Invoke(this, eventData);
        }

        public static void SetSimulateRate(double rate)
        {
            _simulatorRate = rate;
        }

        public static void GetMessageIx()
        {
            if (instance != null)
                instance.TriggerSerialDataReceivedEvent("ix");
        }

        public static void GetMessageRx()
        {
            if (instance != null)
                instance.TriggerSerialDataReceivedEvent("rx");
        }

        public static void GetMessageUx()
        {
            if (instance != null)
                instance.TriggerSerialDataReceivedEvent("ux");
        }

        public static void Connect()
        {
            _simulatorTimer.Start();
        }

        public static void Disconnect() 
        {
            _simulatorTimer.Stop();
        
        }
    }
}
