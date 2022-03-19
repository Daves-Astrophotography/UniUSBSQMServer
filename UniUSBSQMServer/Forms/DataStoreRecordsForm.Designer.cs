namespace UniUSBSQMServer.Forms
{
    partial class DataStoreRecordsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelUpdated = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.listBoxStore = new System.Windows.Forms.ListBox();
            this.dataStoreDataPointBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelRecordCount = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBoxAutoScroll = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataStoreDataPointBindingSource)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelUpdated
            // 
            this.labelUpdated.AutoSize = true;
            this.labelUpdated.ForeColor = System.Drawing.Color.SpringGreen;
            this.labelUpdated.Location = new System.Drawing.Point(255, 0);
            this.labelUpdated.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelUpdated.Name = "labelUpdated";
            this.labelUpdated.Padding = new System.Windows.Forms.Padding(10, 1, 0, 0);
            this.labelUpdated.Size = new System.Drawing.Size(79, 22);
            this.labelUpdated.TabIndex = 6;
            this.labelUpdated.Text = "Updated";
            this.labelUpdated.Visible = false;
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(679, 326);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(4);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 38);
            this.buttonOK.TabIndex = 5;
            this.buttonOK.Text = "Ok";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // listBoxStore
            // 
            this.listBoxStore.FormattingEnabled = true;
            this.listBoxStore.ItemHeight = 21;
            this.listBoxStore.Location = new System.Drawing.Point(17, 18);
            this.listBoxStore.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.listBoxStore.Name = "listBoxStore";
            this.listBoxStore.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxStore.Size = new System.Drawing.Size(737, 298);
            this.listBoxStore.TabIndex = 4;
            // 
            // labelRecordCount
            // 
            this.labelRecordCount.AutoSize = true;
            this.labelRecordCount.Location = new System.Drawing.Point(165, 0);
            this.labelRecordCount.Name = "labelRecordCount";
            this.labelRecordCount.Padding = new System.Windows.Forms.Padding(10, 1, 0, 0);
            this.labelRecordCount.Size = new System.Drawing.Size(83, 22);
            this.labelRecordCount.TabIndex = 7;
            this.labelRecordCount.Text = "Records: ";
            this.labelRecordCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.checkBoxAutoScroll);
            this.flowLayoutPanel1.Controls.Add(this.labelRecordCount);
            this.flowLayoutPanel1.Controls.Add(this.labelUpdated);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(22, 326);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(500, 38);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // checkBoxAutoScroll
            // 
            this.checkBoxAutoScroll.AutoSize = true;
            this.checkBoxAutoScroll.Checked = true;
            this.checkBoxAutoScroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAutoScroll.Location = new System.Drawing.Point(0, 0);
            this.checkBoxAutoScroll.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxAutoScroll.Name = "checkBoxAutoScroll";
            this.checkBoxAutoScroll.Size = new System.Drawing.Size(162, 25);
            this.checkBoxAutoScroll.TabIndex = 8;
            this.checkBoxAutoScroll.Text = "Auto-Scroll To New";
            this.checkBoxAutoScroll.UseVisualStyleBackColor = true;
            // 
            // DataStoreRecordsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(768, 377);
            this.ControlBox = false;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.listBoxStore);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DataStoreRecordsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Memory Store";
            ((System.ComponentModel.ISupportInitialize)(this.dataStoreDataPointBindingSource)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Label labelUpdated;
        private Button buttonOK;
        private ListBox listBoxStore;
        private BindingSource dataStoreDataPointBindingSource;
        private Label labelRecordCount;
        private FlowLayoutPanel flowLayoutPanel1;
        private CheckBox checkBoxAutoScroll;
    }
}