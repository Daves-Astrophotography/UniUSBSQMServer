using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;

namespace UniUSBSQMServer.Forms
{
    public partial class ConfigSerialForm : Form
    {
        public ConfigSerialForm()
        {
            InitializeComponent();

            numericUpDownInterval.Maximum = SettingsManager.SERIAL_POLL_MAXIMUM_INTERVAL_SECONDS;
            numericUpDownInterval.Minimum = SettingsManager.SERIAL_POLL_MINIMUM_INTERVAL_SECONDS;

            //Populate the serial ports with available ports
            comboBoxSerialPorts.Items.Clear();
            comboBoxSerialPorts.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());

            if (comboBoxSerialPorts.Items.Count <=0)
            {
                //Show an error if the system reports no Serial Ports
                MessageBox.Show("No Serial Ports Detected.","Serial Port Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                //Select the port in the list for the current config item
                comboBoxSerialPorts.SelectedIndex = comboBoxSerialPorts.Items.IndexOf(SettingsManager.SerialPortName);    

                //If no item found, select the first item
                if (comboBoxSerialPorts.SelectedIndex == -1)
                {
                    comboBoxSerialPorts.SelectedIndex = 0;
                }
            }
            
            //Check if the serial port is currently connected, user cannot change if connected.
            if (SerialManager.ConnectionState == Enums.SerialConnectedStates.Disconnected)
            {
                comboBoxSerialPorts.Enabled = true;
            } else
            {
                comboBoxSerialPorts.Enabled = false;
            }
            
            //Get the current Interval
            int interval = SettingsManager.SerialPortInterval;
            numericUpDownInterval.Value = interval;
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {

            SettingsManager.SerialPortName = comboBoxSerialPorts.SelectedItem.ToString()??"COM1";

            SettingsManager.SerialPortInterval = Convert.ToInt32(Math.Round(numericUpDownInterval.Value,0));
        }
    }
}
