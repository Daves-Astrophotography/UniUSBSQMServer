
namespace UniUSBSQMServer.Forms
{
    public partial class ConfigTrendForm : Form
    {

        public ConfigTrendForm()
        {
            InitializeComponent();

            //Add Values to Temperature Combo
            comboBoxTempUnits.Items.Clear();
            comboBoxTempUnits.Items.Add("\u2103");
            comboBoxTempUnits.Items.Add("\u2109");

            //Get the current settings
            if (SettingsManager.TemperatureUnits == Enums.TemperatureUnits.Centrigrade)
            {
                comboBoxTempUnits.SelectedIndex = 0;
            } else
            {
                comboBoxTempUnits.SelectedIndex = 1;
            }

            //Trend Max/Min
            numericUpDownRangeMax.Value = SettingsManager.TrendMax;
            numericUpDownRangeMin.Value = SettingsManager.TrendMin;

            //Draw trends
            checkBoxRawMPas.Checked = SettingsManager.TrendDrawRawMPas;
            checkBoxAvgMPas.Checked = SettingsManager.TrendDrawAvgMPas;
            checkBoxTemp.Checked = SettingsManager.TrendDrawTemp;
            checkBoxNELM.Checked = SettingsManager.TrendDrawNELM;

            //Trend Colors
            labelRawMPasColor.BackColor = SettingsManager.TrendRawMPasColor;
            labelAvgMPasColor.BackColor = SettingsManager.TrendAvgMPasColor;
            labelTempColor.BackColor = SettingsManager.TrendTempColor;
            labelNELMColor.BackColor = SettingsManager.TrendNELMColor;
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            
            //Trend Max Min
            SettingsManager.TrendMax = numericUpDownRangeMax.Value;
            SettingsManager.TrendMin = numericUpDownRangeMin.Value;
            
            //Temp unit
            if (comboBoxTempUnits.SelectedIndex == 0)
            {
                SettingsManager.TemperatureUnits = Enums.TemperatureUnits.Centrigrade;
            } else
            {
                SettingsManager.TemperatureUnits = Enums.TemperatureUnits.Fahrenheit;
            }

            //Draw Trends
            SettingsManager.TrendDrawRawMPas = checkBoxRawMPas.Checked;
            SettingsManager.TrendDrawAvgMPas = checkBoxAvgMPas.Checked;
            SettingsManager.TrendDrawTemp = checkBoxTemp.Checked;
            SettingsManager.TrendDrawNELM = checkBoxNELM.Checked;

            //Trend Colors
            SettingsManager.TrendRawMPasColor = labelRawMPasColor.BackColor;
            SettingsManager.TrendAvgMPasColor = labelAvgMPasColor.BackColor;
            SettingsManager.TrendTempColor = labelTempColor.BackColor;
            SettingsManager.TrendNELMColor = labelNELMColor.BackColor;

            SettingsManager.EndSettingsChange();

        }

        private void LabelRawMPasColor_Click(object sender, EventArgs e)
        {
            colorDialogPicker.Color = labelRawMPasColor.BackColor;
            DialogResult result = colorDialogPicker.ShowDialog();

            if (result == DialogResult.OK)
            {
                labelRawMPasColor.BackColor = colorDialogPicker.Color;
            }
        }

        private void LabelAvgMPasColor_Click(object sender, EventArgs e)
        {
            colorDialogPicker.Color = labelRawMPasColor.BackColor;
            DialogResult result = colorDialogPicker.ShowDialog();

            if (result == DialogResult.OK)
            {
                labelAvgMPasColor.BackColor = colorDialogPicker.Color;
            }
        }

        private void LabelTempColor_Click(object sender, EventArgs e)
        {
            colorDialogPicker.Color = labelRawMPasColor.BackColor;
            DialogResult result = colorDialogPicker.ShowDialog();

            if (result == DialogResult.OK)
            {
                labelTempColor.BackColor = colorDialogPicker.Color;
            }
        }

        private void LabelNELMColor_Click(object sender, EventArgs e)
        {
            colorDialogPicker.Color = labelRawMPasColor.BackColor;
            DialogResult result = colorDialogPicker.ShowDialog();

            if (result == DialogResult.OK)
            {
                labelNELMColor.BackColor = colorDialogPicker.Color;
            }
        }

        private void ButtonSetDefaults_Click(object sender, EventArgs e)
        {
            numericUpDownRangeMax.Value = 30;
            numericUpDownRangeMin.Value = 0;
            checkBoxRawMPas.Checked = true;
            checkBoxAvgMPas.Checked = true;
            checkBoxTemp.Checked = true;
            checkBoxNELM.Checked = true;
            labelRawMPasColor.BackColor = Color.Red;
            labelAvgMPasColor.BackColor = Color.Blue;
            labelTempColor.BackColor = Color.Yellow;
            labelNELMColor.BackColor = Color.Lime;
        }
    }
}
