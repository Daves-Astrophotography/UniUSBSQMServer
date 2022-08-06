
namespace UniUSBSQMServer.Forms
{
    public partial class UniUSBSQMServer : Form
    {
        readonly SerialManager? serial;
        readonly NetworkManager? manager;
        readonly DataStore? store;
        readonly Trend? trend;
        readonly SettingsManager settings;

        public UniUSBSQMServer()
        {
            InitializeComponent();

            //Initialise 
            settings = SettingsManager.Instance;
            serial = SerialManager.Instance;
            manager = NetworkManager.Instance;
            store = DataStore.Store;                    //Need this initilised or the logging config form doesn't work as no settings loaded.

            //Setup Form controls
            labelSerialInterval.Text = (SettingsManager.SerialPortInterval).ToString();
            labelSerialPortName.Text = SettingsManager.SerialPortName;
            labelServerPort.Text = SettingsManager.ServerPort.ToString(); // NetworkManager.ServerPort.ToString();

            //Check Port name found on System
            if (!ValidSerialPort())
            {
                string message = "The configured serial port '" + SettingsManager.SerialPortName + "' cannot be found on the system.";
                MessageBox.Show(message, "Serial Port Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                buttonSerialConnect.Enabled = false;
                labelSerialPortName.BackColor = Color.MistyRose;
            } else
            {
                buttonSerialConnect.Enabled = true;
                labelSerialPortName.BackColor = Color.FromKnownColor(KnownColor.Control);
            }

            //Add the trend control
            
            trend = new Trend();
            this.Controls.Add(trend);
            trend.Dock = DockStyle.Fill;
            panelTrendContainer.Controls.Add(trend);
            trend.Show();

            //Subscribe Events
            settings.SettingsChanged += Settings_SettingsChanged;

            serial.SerialStateChanged += Serial_SerialStateChanged;
            serial.SerialDataReceived += Serial_SerialDataReceived;
            serial.SerialPollBegin += Serial_SerialPollBegin;   //Used to blink the Serial Poll indicator
            serial.SerialPollEnd += Serial_SerialPollEnd;       //
            serial.SerialNoResponse += Serial_NoResponse;
            store.DataStoreRecordAdded += Store_DataStoreRecordAdded;
            store.DataStoreCleared += Store_DataStoreCleared;

            manager.ManagerStateChanged += ManagerStateChanged;
            manager.ServerMessageReceived += Manager_ServerMessageReceived;

        }

        private void Settings_SettingsChanged(object? sender, EventArgs e)
        {
            //update labels
            //Serial
            labelSerialPortName.Text = SettingsManager.SerialPortName;
            labelSerialInterval.Text = SettingsManager.SerialPortInterval.ToString();
            //Server
            labelServerPort.Text = SettingsManager.ServerPort.ToString();
        }

        private void Store_DataStoreCleared(object? sender, EventArgs e)
        {
            toolStripStatusMemory.Text = $"Memory : {DataStore.DataStoreLength}";
        }

        private void Store_DataStoreRecordAdded(object? sender, EventArgs e)
        {
            toolStripStatusMemory.Text = $"Memory : {DataStore.DataStoreLength}";
            toolStripStatusMemory.BackColor = Color.PaleGreen; ;
            Task.Delay(250).ContinueWith(t => SetMemoryBackColor());

        }

        private void Serial_NoResponse(object? sender, EventArgs e)
        {
            MessageBox.Show($"No or Invalid response received from {SettingsManager.SerialPortName}, have you selected the correct com port?","Serial Port Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        private void Serial_SerialPollEnd(object? sender, EventArgs e)
        {
            //Delay the backcolor reset to make the poll event more visible.
            Task.Delay(250).ContinueWith(t => SetPollBackColor());
        }

        private void SetPollBackColor()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(delegate () { SetPollBackColor(); }));
                return;
            }

            toolStripStatusSerialPoll.BackColor = Color.FromKnownColor(KnownColor.Control);
        }
        private void SetMemoryBackColor()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(delegate () { SetMemoryBackColor(); }));
                return;
            }

            toolStripStatusMemory.BackColor = Color.FromKnownColor(KnownColor.Control);
        }

        private void Serial_SerialPollBegin(object? sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(delegate () { Serial_SerialPollBegin(sender, e); }));
                return;
            }
            toolStripStatusSerialPoll.BackColor = Color.PaleGreen;
        }

        private void Manager_ServerMessageReceived(object? sender, NetworkMessageReceivedEventArgs e)
        {

            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(delegate () { Manager_ServerMessageReceived(sender, e); }));
                return;
            }

            labelLastServerRequest.Text = $"{e.MessgageInfo} at {DateTime.Now:yyyy-MM-dd HH:mm:ss}";
        }

        private void ManagerStateChanged(object? sender, NetworkManagerStateChangeEventArgs e)
        {
            
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(delegate() { ManagerStateChanged(sender, e); }));
                return;
            }
            
            labelServerPort.Text = e.ServerPort.ToString();
            
            if (e.ServerState == Enums.ServerRunningStates.Running)
            {
                toolStripStatusLabelServerStatus.BackColor = Color.PaleGreen;
                toolStripStatusLabelServerStatus.Text = "Server: Running";

                if (e.ClientCount == 1)
                {
                    toolStripStatusLabelClientCount.Text = "Server: 1 Client";
                    toolStripStatusLabelClientCount.BackColor  = Color.PaleGreen;  
                } else if (e.ClientCount > 1)
                {
                    toolStripStatusLabelClientCount.Text = $"Server: {e.ClientCount} Clients";
                    toolStripStatusLabelClientCount.BackColor = Color.PaleGreen;
                } else
                {
                    toolStripStatusLabelClientCount.Text = $"Server: 0 Clients";
                    toolStripStatusLabelClientCount.BackColor = Color.FromKnownColor(KnownColor.Control);
                }

                buttonServerStart.Text = "Stop";

            } else
            {
                toolStripStatusLabelServerStatus.BackColor = Color.MistyRose;
                toolStripStatusLabelServerStatus.Text = "Server: Stopped";
                toolStripStatusLabelClientCount.Text = $"Server: 0 Clients";
                toolStripStatusLabelClientCount.BackColor = Color.FromKnownColor(KnownColor.Control);
                buttonServerStart.Text = "Start";

            }
        }

        private void Serial_SerialDataReceived(object? sender, SerialManagerDataReceivedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(delegate { Serial_SerialDataReceived(sender, e); }));
                return;
            }
            
            // Display the last message
            labelLastSerialResponse.Text = e.Data.ToString();

            //Display the 'ix' informtation
            string[] data = e.Data.Split(',');
            if (data[0] == "i")
            {
                groupBoxSerial.Text = $"Protocol: {int.Parse(data[1])}, Model: {int.Parse(data[2])}, Feature Version: {int.Parse(data[3])}, Serial #: {int.Parse(data[4])} ";
            }
            
            //Display Average Data
            if (data[0] == "r")
            {
                labelLatestAvMag.Text = $"{Utility.ConvertDataToDouble(data[1])} mag/arcsec\u00b2";
                if (SettingsManager.TemperatureUnits == Enums.TemperatureUnits.Centrigrade)
                {
                    labelLatestTemp.Text = $"{Utility.ConvertDataToDouble(data[5])} \u2103";
                }
                else
                {
                    labelLatestTemp.Text = $"{Utility.ConvertTempCtoF(Utility.ConvertDataToDouble(data[5]))} \u2109";
                }
                
                labelNELM.Text = Utility.CalcNELM(Utility.ConvertDataToDouble(data[1])).ToString("N1");             //V1.3 - Add decimal point digit format 
                labelBortle.Text = Utility.GetBortleNumber(Utility.CalcNELM(Utility.ConvertDataToDouble(data[1]))).ToString();
                labelNELMColor.BackColor = Utility.GetColorByNELM(Utility.CalcNELM(Utility.ConvertDataToDouble(data[1])));
            }
            //Display Raw Data
            if (data[0] == "u")
            {
                labelLatestRawMag.Text = $"{Utility.ConvertDataToDouble(data[1])} mag/arcsec\u00b2";
            }
        }

        private void Serial_SerialStateChanged(object? sender, SerialManagerStateChangedEventArgs e)
        {

            if (this.InvokeRequired)
            { 
                this.BeginInvoke(new MethodInvoker(delegate { Serial_SerialStateChanged(sender, e); }));
                return;
            }
            
            labelSerialPortName.Text = e.SerialPortName;
            labelSerialInterval.Text = (e.SerialPortInterval).ToString();
            
            if (e.ConnectedState == Enums.SerialConnectedStates.Connected)
            {
                buttonSerialConnect.Text = "Disconnect";
                toolStripStatusSerialState.Text = "Serial: Connected";
                toolStripStatusSerialState.BackColor = Color.PaleGreen;

                ixUnitInformationToolStripMenuItem.Enabled = true;
                rxAveragedDataToolStripMenuItem.Enabled = true;
                uxUnaveragedDataToolStripMenuItem.Enabled = true;


                //Allow the server to start
                buttonServerStart.Enabled = true;

            } else if (e.ConnectedState == Enums.SerialConnectedStates.Retry) {
                toolStripStatusSerialState.Text = "Serial: Retry";
                toolStripStatusSerialState.BackColor = Color.LightYellow;

                ixUnitInformationToolStripMenuItem.Enabled = false;
                rxAveragedDataToolStripMenuItem.Enabled = false;
                uxUnaveragedDataToolStripMenuItem.Enabled = false;
            }
            else
            {
                buttonSerialConnect.Text = "Connect";
                toolStripStatusSerialState.Text = "Serial: Disconnected";
                toolStripStatusSerialState.BackColor = Color.MistyRose;

                ixUnitInformationToolStripMenuItem.Enabled = false;
                rxAveragedDataToolStripMenuItem.Enabled = false;
                uxUnaveragedDataToolStripMenuItem.Enabled = false;

                //Block the Server Start/Stop
                buttonServerStart.Enabled = false;
            }

            //Check Port name found on System
            if ((!ValidSerialPort()) && (e.ConnectedState == Enums.SerialConnectedStates.Disconnected))
            {
                string message = "The configured serial port '" + SettingsManager.SerialPortName + "' cannot be found on the system.";
                MessageBox.Show(message, "Serial Port Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                buttonSerialConnect.Enabled = false;
                labelSerialPortName.BackColor = Color.MistyRose;
            }
            else
            {
                buttonSerialConnect.Enabled = true;
                labelSerialPortName.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
            //Force the form to repaint
            this.Refresh(); 
        }
        private static bool ValidSerialPort()
        {
            //Check Port name found on System
            if (System.IO.Ports.SerialPort.GetPortNames().Contains(SettingsManager.SerialPortName))
            {
                return true;
            } else
            {
                return false;
            }
        }
        private void AboutToolStripMenuItemAbout_Click(object sender, EventArgs e)
        {
            Form about = new AboutForm();
            about.ShowDialog();

        }

        private void ButtonSerialConnect_Click(object sender, EventArgs e)
        {
            if (serial == null || manager==null) return;

            if (SerialManager.ConnectionState == Enums.SerialConnectedStates.Disconnected)
            {

                //Clear the data store
                DataStore.ClearStore();
                //Start the Serial
                serial.Connect();
                buttonSerialConnect.Text = "Disconnect";
            }
            else
            {
                if (NetworkManager.ServerState == Enums.ServerRunningStates.Running)
                {
                    if (MessageBox.Show("Disconnecting will also stop the server. Contine to disconnect?","Disconnect Serial", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        manager.ServerStop();
                        serial.Disconnect();
                        buttonSerialConnect.Text = "Connect";
                    }
                }
                else
                {
                    serial.Disconnect();
                    buttonSerialConnect.Text = "Connect";
                }
             }
        }

        private void SerialToolStripMenuSerial_Click(object sender, EventArgs e)
        {
            Form configSerial = new ConfigSerialForm();
            configSerial.ShowDialog();
        }

        private void ServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form configServer = new ConfigServerForm();
            configServer.ShowDialog();
        }

        private void ButtonServerStart_Click(object sender, EventArgs e)
        {
            if (manager == null) return;
            if (NetworkManager.ServerState == Enums.ServerRunningStates.Running)
            {
                manager.ServerStop();
            }
            else
            {
                manager.ServerStart();
            }
        }

        private void LoggingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form loggingForm = new ConfigLoggingForm();
            loggingForm.ShowDialog();
        }

        private void TrendUnitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form configTrend = new ConfigTrendForm();
            configTrend.ShowDialog();
        }

        private void ToolStripMenuItemVisitGithub_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo("https://github.com/Daves-Astrophotography/UniUSBSQMServer") { UseShellExecute = true });
        }

        private void ToolStripMenuItemVisitWebsite_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo("https://www.daves-astrophotography.com") { UseShellExecute = true });
        }

        private void ToolStripMenuItemVisitYoutube_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo("https://youtube.com/c/daves-astrophotography") { UseShellExecute = true });
        }

        private void ToolStripStatusMemory_Click(object sender, EventArgs e)
        {
            //Show the Context Menu
            contextMenuStripMemory.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void ClearMemoryRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Clear the current data records from memory, this will also clear the trend?","Clear Memory",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                DataStore.ClearStore();
            }
        }

        private void ToolStripMenuItemShowDataStore_Click(object sender, EventArgs e)
        {

            foreach (Form f in Application.OpenForms)
            {
                if (f is DataStoreRecordsForm)
                {
                    f.Focus();
                    return;
                }
            }

            Form DataStoreRecordsForm = new DataStoreRecordsForm();

            DataStoreRecordsForm.Show();
        }

        private void IXUnitInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Try to send the message
            if (!SerialManager.SendCommand("ix"))
            {
                System.Windows.Forms.MessageBox.Show("Message not sent.");
            }
        }

        private void UXUnaveragedDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Try to send the message
            if (!SerialManager.SendCommand("ux"))
            {
                System.Windows.Forms.MessageBox.Show("Message not sent.");
            }
        }

        private void RXAveragedDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Try to send the message
            if (!SerialManager.SendCommand("rx"))
            {
                System.Windows.Forms.MessageBox.Show("Message not sent.");
            }
        }

        private void ToolStripStatusSerialPoll_Click(object sender, EventArgs e)
        {
            contextMenuStripSerial.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void ViewLatestResponsesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f is LatestMessagesForm)
                {
                    f.Focus();
                    return;
                }
            }

            Form latestMessagesForm = new LatestMessagesForm();

            latestMessagesForm.Show();
        }

        private void UniUSBSQMServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serial != null )
            {
            //Detach events
                serial.SerialStateChanged -= Serial_SerialStateChanged;
                serial.SerialDataReceived -= Serial_SerialDataReceived;
                serial.SerialPollBegin -= Serial_SerialPollBegin;   //Used to blink the Serial Poll indicator
                serial.SerialPollEnd -= Serial_SerialPollEnd;       //
                serial.SerialNoResponse -= Serial_NoResponse;
            
                //Disconnect the serial port before closing
                if (SerialManager.ConnectionState == Enums.SerialConnectedStates.Connected)
                {
                    serial.Disconnect();
                }

            }

            if (manager != null)
            {
                manager.ManagerStateChanged -= ManagerStateChanged;
                manager.ServerMessageReceived -= Manager_ServerMessageReceived;
                //Stop the server if running
                if (NetworkManager.ServerState == Enums.ServerRunningStates.Running)
                {
                    manager.ServerStop();
                }
            }
                
            if (store != null)
            {
                store.DataStoreRecordAdded -= Store_DataStoreRecordAdded;
                store.DataStoreCleared -= Store_DataStoreCleared;
            }

        }

    }
}