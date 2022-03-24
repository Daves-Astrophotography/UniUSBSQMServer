
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

            if (NetworkManager.ServerState == Enums.ServerRunningStates.Running)
            {
                numericUpDownPort.Enabled = false;
            } else
            {
                numericUpDownPort.Enabled = true;
            }

        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        { 
            SettingsManager.ServerPort = Convert.ToInt32(Math.Round(numericUpDownPort.Value, 0));
            SettingsManager.EndSettingsChange();
        }
    }
}
