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
    public partial class LatestMessagesForm : Form
    {
        public LatestMessagesForm()
        {
            InitializeComponent();

            listBoxLatest.Items.Clear();
            listBoxLatest.DataSource = new BindingSource(SQMLatestMessageReading.GetAllMessages(),null);

            SerialManager.Instance.SerialDataReceived += Instance_SerialDataReceived;
        }

        private void Instance_SerialDataReceived(object? sender, SerialManagerDataReceivedEventArgs e)
        {

            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(delegate () { Instance_SerialDataReceived(sender, e); }));
                return;
            }

            listBoxLatest.DataSource = new BindingSource(SQMLatestMessageReading.GetAllMessages(), null);
            labelUpdated.Visible = true;
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

            labelUpdated.Visible=false;
        }


        private void ButtonOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
