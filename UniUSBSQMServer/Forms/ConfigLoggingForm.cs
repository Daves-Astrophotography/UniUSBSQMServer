
namespace UniUSBSQMServer
{
    public partial class ConfigLoggingForm : Form
    {
        public ConfigLoggingForm()
        {
            InitializeComponent();

            numericUpDownInterval.Minimum = SettingsManager.LOGGING_MINIMUM_INTERVAL_SECONDS;
            numericUpDownInterval.Maximum = SettingsManager.LOGGING_MAXIMUM_INTERVAL_SECONDS;
            labelIntervalLimits.Text = $"Min: {SettingsManager.LOGGING_MINIMUM_INTERVAL_SECONDS} , Max: {SettingsManager.LOGGING_MAXIMUM_INTERVAL_SECONDS}";
            
            //Set the form values to minimum if there is an error
            try
            {
                numericUpDownInterval.Value = SettingsManager.MemoryLoggingInterval;
            }
            catch (Exception )
            {
                //Set to the minimum value
                numericUpDownInterval.Value = SettingsManager.LOGGING_MINIMUM_INTERVAL_SECONDS;
            }

            try
            {
                numericUpDownRecords.Value = SettingsManager.MemoryLoggingRecordLimit;
            }
            catch (Exception )
            {
                numericUpDownRecords.Value = numericUpDownRecords.Minimum;
            }
  
            
            
            if (SettingsManager.MemoryLoggingNoLimit)
            {
                radioButtonNoLimitRecords.Checked = true;
            } else
            {
                radioButtonMaxRecordsNumber.Checked = true;
            }

            numericUpDownRecords.Minimum = SettingsManager.LOGGING_MINIMUM_RECORDS;
            numericUpDownRecords.Maximum = SettingsManager.LOGGING_MAXIMUM_RECORDS;
            labelRecordsLimits.Text = $"Min: {SettingsManager.LOGGING_MINIMUM_RECORDS} , Max: {SettingsManager.LOGGING_MAXIMUM_RECORDS}";
            
            try 
            {
                numericUpDownRecords.Value = SettingsManager.MemoryLoggingRecordLimit;
            } 
            catch (Exception)
            {
                numericUpDownRecords.Value= SettingsManager.LOGGING_MINIMUM_RECORDS;

            }

            checkBoxFileLogging.Checked = SettingsManager.FileLoggingEnabled;

            if (SettingsManager.FileLoggingDefaultPath)
            {
                radioButtonDefaultPath.Checked = true;
            } else
            {
                radioButtonCustomPath.Checked = true;
            }

            labelFilePath.Text = SettingsManager.FileLoggingCustomPath;

            labelEstimateMemoryDuration.Text = CalcEstimatedMemoryLoggingDuration();

        }

        private string CalcEstimatedMemoryLoggingDuration()
        {
            int interval = Convert.ToInt32(Math.Round(numericUpDownInterval.Value, 0));
            int maxRecords = Convert.ToInt32(Math.Round(numericUpDownRecords.Value, 0));

            int totalSeconds = interval * (maxRecords);

            int calcHours = totalSeconds / 3600;

            int calcMinutes = (totalSeconds - (calcHours * 3600)) / 60;

            int calcSeconds = totalSeconds - ((calcHours * 3600) + (calcMinutes * 60)) ;

            string output;
            if (calcHours == 1)
                output = "1 hour ";
            else
                output = $"{calcHours} hours ";

            if (calcMinutes == 1)
                output += "1 minute ";
            else
                output += $"{calcMinutes} minutes ";

            if (calcSeconds == 1)
                output += output + "1 second";
            else
                output += $"{calcSeconds} seconds";

            return output;
        }


        private void ButtonOK_Click(object sender, EventArgs e)
        {
            SettingsManager.MemoryLoggingInterval = Convert.ToInt32(Math.Round(numericUpDownInterval.Value, 0));
            SettingsManager.MemoryLoggingRecordLimit = Convert.ToInt32(Math.Round(numericUpDownRecords.Value, 0));;
            SettingsManager.MemoryLoggingNoLimit = radioButtonNoLimitRecords.Checked;
            
            SettingsManager.FileLoggingEnabled = checkBoxFileLogging.Checked;
            SettingsManager.FileLoggingDefaultPath = radioButtonDefaultPath.Checked;
            SettingsManager.FileLoggingCustomPath = labelFilePath.Text;

            SettingsManager.EndSettingsChange();
        }

        private void ButtonSelectFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new();
            dialog.SelectedPath = SettingsManager.FileLoggingCustomPath;
            
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                //Check the selected path exists, create if not
                if (!Directory.Exists(dialog.SelectedPath))
                    Directory.CreateDirectory(dialog.SelectedPath);
                    
                labelFilePath.Text = dialog.SelectedPath;
            }
        }

        private void NumericUpDownInterval_ValueChanged(object sender, EventArgs e)
        {
            labelEstimateMemoryDuration.Text = CalcEstimatedMemoryLoggingDuration();
        }

        private void NumericUpDownRecords_ValueChanged(object sender, EventArgs e)
        {
            labelEstimateMemoryDuration.Text = CalcEstimatedMemoryLoggingDuration();
        }

        private void ButtonOpenDefaultPath_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Application.StartupPath, "logs");
            if (Directory.Exists(path))
            {
                System.Diagnostics.ProcessStartInfo startInfo = new ()
                {
                    Arguments = path,
                    FileName = "explorer.exe"
                };

                System.Diagnostics.Process.Start(startInfo);
                }
            else
            {
                MessageBox.Show(string.Format("{0} Directory does not exist!", path));
            }
        }

        private void ButtonOpenCustomPath_Click(object sender, EventArgs e)
        {
            string path = labelFilePath.Text;
            if (Directory.Exists(path))
            {
                System.Diagnostics.ProcessStartInfo startInfo = new()
                {
                    Arguments = path,
                    FileName = "explorer.exe"
                };

                System.Diagnostics.Process.Start(startInfo);
            }
            else
            {
                MessageBox.Show(string.Format("{0} Directory does not exist!", path));
            }
        }
    }
}
