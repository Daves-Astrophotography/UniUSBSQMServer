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
    public partial class DataStoreRecordsForm : Form
    {
        public DataStoreRecordsForm()
        {
            InitializeComponent();

            listBoxStore.Items.Clear();
            listBoxStore.DataSource = new BindingSource(DataStore.GetAllData(),null);

            labelRecordCount.Text = $"Records: {listBoxStore.Items.Count}";    

            DataStore.Store.DataStoreRecordAdded += Store_DataStoreRecordAdded;
            DataStore.Store.DataStoreCleared += Store_DataStoreCleared;
        }

        private void Store_DataStoreCleared(object? sender, EventArgs e)
        {
            labelRecordCount.Text = $"Records: {listBoxStore.Items.Count}";
        }

        private void Store_DataStoreRecordAdded(object? sender, EventArgs e)
        {

            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(delegate () { Store_DataStoreRecordAdded(sender, e); }));
                return;
            }

            listBoxStore.DataSource = new BindingSource(DataStore.GetAllData(), null);
            labelUpdated.Visible = true;

            labelRecordCount.Text = $"Records: {listBoxStore.Items.Count}";

            if (checkBoxAutoScroll.Checked)
            {
                //Scroll to bottom
                int visibleItems = listBoxStore.ClientSize.Height / listBoxStore.ItemHeight;
                listBoxStore.TopIndex = Math.Max(listBoxStore.Items.Count - visibleItems + 1, 0);
            }
            

            //start a new background task to hide the label
            Task.Delay(500).ContinueWith(t => HideUpdatedLabel());
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
