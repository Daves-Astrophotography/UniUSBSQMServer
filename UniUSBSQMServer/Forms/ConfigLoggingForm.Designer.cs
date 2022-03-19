namespace UniUSBSQMServer
{
    partial class ConfigLoggingForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownInterval = new System.Windows.Forms.NumericUpDown();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxMemoryLogging = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.radioButtonNoLimitRecords = new System.Windows.Forms.RadioButton();
            this.radioButtonMaxRecordsNumber = new System.Windows.Forms.RadioButton();
            this.labelEstimateMemoryDuration = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownRecords = new System.Windows.Forms.NumericUpDown();
            this.groupBoxFileLogging = new System.Windows.Forms.GroupBox();
            this.buttonOpenDefaultPath = new System.Windows.Forms.Button();
            this.buttonOpenCustomPath = new System.Windows.Forms.Button();
            this.buttonSelectFolder = new System.Windows.Forms.Button();
            this.labelFilePath = new System.Windows.Forms.Label();
            this.radioButtonCustomPath = new System.Windows.Forms.RadioButton();
            this.radioButtonDefaultPath = new System.Windows.Forms.RadioButton();
            this.checkBoxFileLogging = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).BeginInit();
            this.groupBoxMemoryLogging.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRecords)).BeginInit();
            this.groupBoxFileLogging.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 21);
            this.label2.TabIndex = 9;
            this.label2.Text = "Data Log Interval (s):";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericUpDownInterval
            // 
            this.numericUpDownInterval.Location = new System.Drawing.Point(173, 29);
            this.numericUpDownInterval.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDownInterval.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.numericUpDownInterval.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownInterval.Name = "numericUpDownInterval";
            this.numericUpDownInterval.Size = new System.Drawing.Size(144, 29);
            this.numericUpDownInterval.TabIndex = 0;
            this.numericUpDownInterval.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDownInterval.ValueChanged += new System.EventHandler(this.NumericUpDownInterval_ValueChanged);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(839, 416);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 38);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(942, 416);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 38);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "Ok";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(173, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(670, 21);
            this.label1.TabIndex = 10;
            this.label1.Text = "How frequently to log a data point. This should be same as or longer than the ser" +
    "ial polling rate.";
            // 
            // groupBoxMemoryLogging
            // 
            this.groupBoxMemoryLogging.Controls.Add(this.label6);
            this.groupBoxMemoryLogging.Controls.Add(this.label5);
            this.groupBoxMemoryLogging.Controls.Add(this.radioButtonNoLimitRecords);
            this.groupBoxMemoryLogging.Controls.Add(this.radioButtonMaxRecordsNumber);
            this.groupBoxMemoryLogging.Controls.Add(this.labelEstimateMemoryDuration);
            this.groupBoxMemoryLogging.Controls.Add(this.label4);
            this.groupBoxMemoryLogging.Controls.Add(this.numericUpDownRecords);
            this.groupBoxMemoryLogging.Controls.Add(this.numericUpDownInterval);
            this.groupBoxMemoryLogging.Controls.Add(this.label1);
            this.groupBoxMemoryLogging.Controls.Add(this.label2);
            this.groupBoxMemoryLogging.Location = new System.Drawing.Point(12, 12);
            this.groupBoxMemoryLogging.Name = "groupBoxMemoryLogging";
            this.groupBoxMemoryLogging.Size = new System.Drawing.Size(1005, 192);
            this.groupBoxMemoryLogging.TabIndex = 11;
            this.groupBoxMemoryLogging.TabStop = false;
            this.groupBoxMemoryLogging.Text = "In Memory Data Logging";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(324, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(157, 21);
            this.label6.TabIndex = 16;
            this.label6.Text = "(min: 10 max: 10000)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(324, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 21);
            this.label5.TabIndex = 15;
            this.label5.Text = "(min: 10 max: 3600)";
            // 
            // radioButtonNoLimitRecords
            // 
            this.radioButtonNoLimitRecords.AutoSize = true;
            this.radioButtonNoLimitRecords.Checked = true;
            this.radioButtonNoLimitRecords.Location = new System.Drawing.Point(6, 154);
            this.radioButtonNoLimitRecords.Name = "radioButtonNoLimitRecords";
            this.radioButtonNoLimitRecords.Size = new System.Drawing.Size(88, 25);
            this.radioButtonNoLimitRecords.TabIndex = 3;
            this.radioButtonNoLimitRecords.TabStop = true;
            this.radioButtonNoLimitRecords.Text = "No Limit";
            this.radioButtonNoLimitRecords.UseVisualStyleBackColor = true;
            // 
            // radioButtonMaxRecordsNumber
            // 
            this.radioButtonMaxRecordsNumber.AutoSize = true;
            this.radioButtonMaxRecordsNumber.Location = new System.Drawing.Point(6, 98);
            this.radioButtonMaxRecordsNumber.Name = "radioButtonMaxRecordsNumber";
            this.radioButtonMaxRecordsNumber.Size = new System.Drawing.Size(158, 25);
            this.radioButtonMaxRecordsNumber.TabIndex = 2;
            this.radioButtonMaxRecordsNumber.Text = "Maximum Records";
            this.radioButtonMaxRecordsNumber.UseVisualStyleBackColor = true;
            // 
            // labelEstimateMemoryDuration
            // 
            this.labelEstimateMemoryDuration.AutoSize = true;
            this.labelEstimateMemoryDuration.Location = new System.Drawing.Point(487, 100);
            this.labelEstimateMemoryDuration.Name = "labelEstimateMemoryDuration";
            this.labelEstimateMemoryDuration.Size = new System.Drawing.Size(99, 21);
            this.labelEstimateMemoryDuration.TabIndex = 14;
            this.labelEstimateMemoryDuration.Text = "est. duration.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(173, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(458, 21);
            this.label4.TabIndex = 13;
            this.label4.Text = "How much data to retain in memory, old data will be pushed out.";
            // 
            // numericUpDownRecords
            // 
            this.numericUpDownRecords.Location = new System.Drawing.Point(173, 98);
            this.numericUpDownRecords.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDownRecords.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownRecords.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownRecords.Name = "numericUpDownRecords";
            this.numericUpDownRecords.Size = new System.Drawing.Size(144, 29);
            this.numericUpDownRecords.TabIndex = 1;
            this.numericUpDownRecords.Value = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDownRecords.ValueChanged += new System.EventHandler(this.NumericUpDownRecords_ValueChanged);
            // 
            // groupBoxFileLogging
            // 
            this.groupBoxFileLogging.Controls.Add(this.buttonOpenDefaultPath);
            this.groupBoxFileLogging.Controls.Add(this.buttonOpenCustomPath);
            this.groupBoxFileLogging.Controls.Add(this.buttonSelectFolder);
            this.groupBoxFileLogging.Controls.Add(this.labelFilePath);
            this.groupBoxFileLogging.Controls.Add(this.radioButtonCustomPath);
            this.groupBoxFileLogging.Controls.Add(this.radioButtonDefaultPath);
            this.groupBoxFileLogging.Controls.Add(this.checkBoxFileLogging);
            this.groupBoxFileLogging.Controls.Add(this.label3);
            this.groupBoxFileLogging.Location = new System.Drawing.Point(12, 210);
            this.groupBoxFileLogging.Name = "groupBoxFileLogging";
            this.groupBoxFileLogging.Size = new System.Drawing.Size(1005, 200);
            this.groupBoxFileLogging.TabIndex = 12;
            this.groupBoxFileLogging.TabStop = false;
            this.groupBoxFileLogging.Text = "File Data Logging";
            // 
            // buttonOpenDefaultPath
            // 
            this.buttonOpenDefaultPath.Location = new System.Drawing.Point(858, 52);
            this.buttonOpenDefaultPath.Name = "buttonOpenDefaultPath";
            this.buttonOpenDefaultPath.Size = new System.Drawing.Size(141, 38);
            this.buttonOpenDefaultPath.TabIndex = 23;
            this.buttonOpenDefaultPath.Text = "Open Default";
            this.buttonOpenDefaultPath.UseVisualStyleBackColor = true;
            this.buttonOpenDefaultPath.Click += new System.EventHandler(this.ButtonOpenDefaultPath_Click);
            // 
            // buttonOpenCustomPath
            // 
            this.buttonOpenCustomPath.Location = new System.Drawing.Point(858, 144);
            this.buttonOpenCustomPath.Name = "buttonOpenCustomPath";
            this.buttonOpenCustomPath.Size = new System.Drawing.Size(141, 38);
            this.buttonOpenCustomPath.TabIndex = 22;
            this.buttonOpenCustomPath.Text = "Open Custom";
            this.buttonOpenCustomPath.UseVisualStyleBackColor = true;
            this.buttonOpenCustomPath.Click += new System.EventHandler(this.ButtonOpenCustomPath_Click);
            // 
            // buttonSelectFolder
            // 
            this.buttonSelectFolder.Location = new System.Drawing.Point(23, 142);
            this.buttonSelectFolder.Name = "buttonSelectFolder";
            this.buttonSelectFolder.Size = new System.Drawing.Size(141, 38);
            this.buttonSelectFolder.TabIndex = 3;
            this.buttonSelectFolder.Text = "Select Folder";
            this.buttonSelectFolder.UseVisualStyleBackColor = true;
            this.buttonSelectFolder.Click += new System.EventHandler(this.ButtonSelectFolder_Click);
            // 
            // labelFilePath
            // 
            this.labelFilePath.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelFilePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelFilePath.Location = new System.Drawing.Point(14, 118);
            this.labelFilePath.Name = "labelFilePath";
            this.labelFilePath.Size = new System.Drawing.Size(985, 23);
            this.labelFilePath.TabIndex = 21;
            this.labelFilePath.Text = "Default custom folder is \'application folder\'/logs.";
            this.labelFilePath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // radioButtonCustomPath
            // 
            this.radioButtonCustomPath.AutoSize = true;
            this.radioButtonCustomPath.Location = new System.Drawing.Point(14, 90);
            this.radioButtonCustomPath.Name = "radioButtonCustomPath";
            this.radioButtonCustomPath.Size = new System.Drawing.Size(117, 25);
            this.radioButtonCustomPath.TabIndex = 2;
            this.radioButtonCustomPath.Text = "Custom path";
            this.radioButtonCustomPath.UseVisualStyleBackColor = true;
            // 
            // radioButtonDefaultPath
            // 
            this.radioButtonDefaultPath.AutoSize = true;
            this.radioButtonDefaultPath.Checked = true;
            this.radioButtonDefaultPath.Location = new System.Drawing.Point(14, 59);
            this.radioButtonDefaultPath.Name = "radioButtonDefaultPath";
            this.radioButtonDefaultPath.Size = new System.Drawing.Size(113, 25);
            this.radioButtonDefaultPath.TabIndex = 1;
            this.radioButtonDefaultPath.TabStop = true;
            this.radioButtonDefaultPath.Text = "Default path";
            this.radioButtonDefaultPath.UseVisualStyleBackColor = true;
            // 
            // checkBoxFileLogging
            // 
            this.checkBoxFileLogging.AutoSize = true;
            this.checkBoxFileLogging.Location = new System.Drawing.Point(14, 28);
            this.checkBoxFileLogging.Name = "checkBoxFileLogging";
            this.checkBoxFileLogging.Size = new System.Drawing.Size(84, 25);
            this.checkBoxFileLogging.TabIndex = 0;
            this.checkBoxFileLogging.Text = "Enabled";
            this.checkBoxFileLogging.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(190, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(291, 21);
            this.label3.TabIndex = 17;
            this.label3.Text = "Default folder is \'application folder\'/logs.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ConfigLoggingForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(1029, 465);
            this.ControlBox = false;
            this.Controls.Add(this.groupBoxFileLogging);
            this.Controls.Add(this.groupBoxMemoryLogging);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ConfigLoggingForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configure Logging";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).EndInit();
            this.groupBoxMemoryLogging.ResumeLayout(false);
            this.groupBoxMemoryLogging.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRecords)).EndInit();
            this.groupBoxFileLogging.ResumeLayout(false);
            this.groupBoxFileLogging.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Label label2;
        private NumericUpDown numericUpDownInterval;
        private Button buttonCancel;
        private Button buttonOK;
        private Label label1;
        private GroupBox groupBoxMemoryLogging;
        private RadioButton radioButtonNoLimitRecords;
        private RadioButton radioButtonMaxRecordsNumber;
        private Label labelEstimateMemoryDuration;
        private Label label4;
        private NumericUpDown numericUpDownRecords;
        private GroupBox groupBoxFileLogging;
        private Button buttonSelectFolder;
        private Label labelFilePath;
        private RadioButton radioButtonCustomPath;
        private RadioButton radioButtonDefaultPath;
        private CheckBox checkBoxFileLogging;
        private Label label3;
        private Label label6;
        private Label label5;
        private Button buttonOpenDefaultPath;
        private Button buttonOpenCustomPath;
    }
}