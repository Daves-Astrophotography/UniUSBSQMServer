
namespace UniUSBSQMServer.Forms
{
    public partial class DataStoreRecordsForm : Form
    {
        public DataStoreRecordsForm()
        {
            InitializeComponent();

            listBoxStore.Items.Clear();
            
            listBoxStore.Items.AddRange(DataStore.GetAllData().ToArray());

            ScrollToLatest();

            labelRecordCount.Text = $"Records: {listBoxStore.Items.Count}";    

            DataStore.Store.DataStoreRecordAdded += Store_DataStoreRecordAdded;
            DataStore.Store.DataStoreCleared += Store_DataStoreCleared;
        }

        private void Store_DataStoreCleared(object? sender, EventArgs e)
        {
            listBoxStore.Items.Clear();
            labelRecordCount.Text = $"Records: {listBoxStore.Items.Count}";
        }

        private void Store_DataStoreRecordAdded(object? sender, EventArgs e)
        {

            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(delegate () { Store_DataStoreRecordAdded(sender, e); }));
                return;
            }

            if (!SettingsManager.MemoryLoggingNoLimit && listBoxStore.Items.Count >= SettingsManager.MemoryLoggingRecordLimit)
            {
                //prune the list to one less than limit, to make space for the new entry
                while (listBoxStore.Items.Count >= SettingsManager.MemoryLoggingRecordLimit)
                {
                    listBoxStore.Items.RemoveAt(0);
                }
            }

            listBoxStore.Items.Add(DataStore.GetLatestRecord().ToString());
            
            labelUpdated.Visible = true;

            labelRecordCount.Text = $"Records: {listBoxStore.Items.Count}";

            if (checkBoxAutoScroll.Checked)
            {
                ScrollToLatest();
            }
            
            //start a new background task to hide the label
            Task.Delay(500).ContinueWith(t => HideUpdatedLabel());
        }

        private void ScrollToLatest()
        {
            //Scroll to bottom
            int visibleItems = listBoxStore.ClientSize.Height / listBoxStore.ItemHeight;
            listBoxStore.TopIndex = Math.Max(listBoxStore.Items.Count - visibleItems + 1, 0);
        }

        private void HideUpdatedLabel()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(delegate () { HideUpdatedLabel(); }));
                return;
            }

            labelUpdated.Visible = false;
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
