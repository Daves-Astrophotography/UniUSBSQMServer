using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniUSBSQMServer.Forms
{
    public partial class ConfigServerForm : Form
    {
        public ConfigServerForm()
        {
            InitializeComponent();

            numericUpDownPort.Maximum = SettingsManager.SERVER_PORT_MAXIMUM;
            numericUpDownPort.Minimum = SettingsManager.SERVER_PORT_MINIMUM;

            numericUpDownPort.Value = SettingsManager.ServerPort;

        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            //Set the port only if disconnected.
            if (NetworkManager.ServerState == Enums.ServerRunningStates.Stopped)
            {
                SettingsManager.ServerPort = Convert.ToInt32(Math.Round(numericUpDownPort.Value, 0));
            }
        }
    }
}
