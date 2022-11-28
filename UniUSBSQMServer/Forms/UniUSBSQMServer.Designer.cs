namespace UniUSBSQMServer.Forms
{
    partial class UniUSBSQMServer
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UniUSBSQMServer));
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.serialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loggingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trendUnitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemVisitGithub = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemVisitWebsite = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemVisitYoutube = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusSerialState = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusSerialPoll = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelServerStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelClientCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusMemory = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.labelSerialInterval = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelSerialPortName = new System.Windows.Forms.Label();
            this.buttonSerialConnect = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.labelLastSerialResponse = new System.Windows.Forms.Label();
            this.groupBoxSerial = new System.Windows.Forms.GroupBox();
            this.labelSimulateRate = new System.Windows.Forms.Label();
            this.trackBarSimulateRate = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.labelServerPort = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelLastServerRequest = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonServerStart = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelLatestRawMag = new System.Windows.Forms.Label();
            this.labelLatestAvMag = new System.Windows.Forms.Label();
            this.labelLatestTemp = new System.Windows.Forms.Label();
            this.flowLayoutPanelLatestData = new System.Windows.Forms.FlowLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.labelBortle = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labelNELM = new System.Windows.Forms.Label();
            this.labelNELMColor = new System.Windows.Forms.Label();
            this.panelTrendContainer = new System.Windows.Forms.Panel();
            this.contextMenuStripMemory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemShowDataStore = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.clearMemoryRecordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripSerial = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewLatestResponsesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.sendCommandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ixUnitInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uxUnaveragedDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rxAveragedDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripMain.SuspendLayout();
            this.statusStripMain.SuspendLayout();
            this.groupBoxSerial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSimulateRate)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanelLatestData.SuspendLayout();
            this.contextMenuStripMemory.SuspendLayout();
            this.contextMenuStripSerial.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuConfig,
            this.toolStripMenuHelp});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.menuStripMain.Size = new System.Drawing.Size(1157, 31);
            this.menuStripMain.TabIndex = 0;
            this.menuStripMain.Text = "menuStripMain";
            // 
            // toolStripMenuConfig
            // 
            this.toolStripMenuConfig.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serialToolStripMenuItem,
            this.serverToolStripMenuItem,
            this.loggingToolStripMenuItem,
            this.trendUnitsToolStripMenuItem});
            this.toolStripMenuConfig.Name = "toolStripMenuConfig";
            this.toolStripMenuConfig.Size = new System.Drawing.Size(68, 25);
            this.toolStripMenuConfig.Text = "&Config";
            // 
            // serialToolStripMenuItem
            // 
            this.serialToolStripMenuItem.Name = "serialToolStripMenuItem";
            this.serialToolStripMenuItem.Size = new System.Drawing.Size(176, 26);
            this.serialToolStripMenuItem.Text = "Serial";
            this.serialToolStripMenuItem.Click += new System.EventHandler(this.SerialToolStripMenuSerial_Click);
            // 
            // serverToolStripMenuItem
            // 
            this.serverToolStripMenuItem.Name = "serverToolStripMenuItem";
            this.serverToolStripMenuItem.Size = new System.Drawing.Size(176, 26);
            this.serverToolStripMenuItem.Text = "Server";
            this.serverToolStripMenuItem.Click += new System.EventHandler(this.ServerToolStripMenuItem_Click);
            // 
            // loggingToolStripMenuItem
            // 
            this.loggingToolStripMenuItem.Name = "loggingToolStripMenuItem";
            this.loggingToolStripMenuItem.Size = new System.Drawing.Size(176, 26);
            this.loggingToolStripMenuItem.Text = "Logging";
            this.loggingToolStripMenuItem.Click += new System.EventHandler(this.LoggingToolStripMenuItem_Click);
            // 
            // trendUnitsToolStripMenuItem
            // 
            this.trendUnitsToolStripMenuItem.Name = "trendUnitsToolStripMenuItem";
            this.trendUnitsToolStripMenuItem.Size = new System.Drawing.Size(176, 26);
            this.trendUnitsToolStripMenuItem.Text = "Trend && Units";
            this.trendUnitsToolStripMenuItem.Click += new System.EventHandler(this.TrendUnitsToolStripMenuItem_Click);
            // 
            // toolStripMenuHelp
            // 
            this.toolStripMenuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemVisitGithub,
            this.toolStripMenuItemVisitWebsite,
            this.toolStripMenuItemVisitYoutube,
            this.toolStripSeparator1,
            this.aboutToolStripMenuItemAbout});
            this.toolStripMenuHelp.Name = "toolStripMenuHelp";
            this.toolStripMenuHelp.Size = new System.Drawing.Size(54, 25);
            this.toolStripMenuHelp.Text = "&Help";
            // 
            // toolStripMenuItemVisitGithub
            // 
            this.toolStripMenuItemVisitGithub.Name = "toolStripMenuItemVisitGithub";
            this.toolStripMenuItemVisitGithub.Size = new System.Drawing.Size(242, 26);
            this.toolStripMenuItemVisitGithub.Text = "Visit GitHub Repository";
            this.toolStripMenuItemVisitGithub.Click += new System.EventHandler(this.ToolStripMenuItemVisitGithub_Click);
            // 
            // toolStripMenuItemVisitWebsite
            // 
            this.toolStripMenuItemVisitWebsite.Name = "toolStripMenuItemVisitWebsite";
            this.toolStripMenuItemVisitWebsite.Size = new System.Drawing.Size(242, 26);
            this.toolStripMenuItemVisitWebsite.Text = "Visit Website";
            this.toolStripMenuItemVisitWebsite.Click += new System.EventHandler(this.ToolStripMenuItemVisitWebsite_Click);
            // 
            // toolStripMenuItemVisitYoutube
            // 
            this.toolStripMenuItemVisitYoutube.Name = "toolStripMenuItemVisitYoutube";
            this.toolStripMenuItemVisitYoutube.Size = new System.Drawing.Size(242, 26);
            this.toolStripMenuItemVisitYoutube.Text = "Visit YouTube Channel";
            this.toolStripMenuItemVisitYoutube.Click += new System.EventHandler(this.ToolStripMenuItemVisitYoutube_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(239, 6);
            // 
            // aboutToolStripMenuItemAbout
            // 
            this.aboutToolStripMenuItemAbout.Name = "aboutToolStripMenuItemAbout";
            this.aboutToolStripMenuItemAbout.Size = new System.Drawing.Size(242, 26);
            this.aboutToolStripMenuItemAbout.Text = "&About";
            this.aboutToolStripMenuItemAbout.Click += new System.EventHandler(this.AboutToolStripMenuItemAbout_Click);
            // 
            // statusStripMain
            // 
            this.statusStripMain.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.statusStripMain.GripMargin = new System.Windows.Forms.Padding(0);
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripStatusSerialState,
            this.toolStripStatusSerialPoll,
            this.toolStripStatusLabelServerStatus,
            this.toolStripStatusLabelClientCount,
            this.toolStripStatusMemory});
            this.statusStripMain.Location = new System.Drawing.Point(0, 531);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Padding = new System.Windows.Forms.Padding(1, 0, 18, 0);
            this.statusStripMain.Size = new System.Drawing.Size(1157, 30);
            this.statusStripMain.SizingGrip = false;
            this.statusStripMain.TabIndex = 1;
            this.statusStripMain.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(565, 25);
            this.toolStripStatusLabel.Spring = true;
            this.toolStripStatusLabel.Text = "Dave\'s Astrophotography";
            this.toolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusSerialState
            // 
            this.toolStripStatusSerialState.BackColor = System.Drawing.Color.MistyRose;
            this.toolStripStatusSerialState.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusSerialState.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.toolStripStatusSerialState.Name = "toolStripStatusSerialState";
            this.toolStripStatusSerialState.Size = new System.Drawing.Size(153, 25);
            this.toolStripStatusSerialState.Text = "Serial: Disconnected";
            // 
            // toolStripStatusSerialPoll
            // 
            this.toolStripStatusSerialPoll.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusSerialPoll.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.toolStripStatusSerialPoll.Name = "toolStripStatusSerialPoll";
            this.toolStripStatusSerialPoll.Size = new System.Drawing.Size(82, 25);
            this.toolStripStatusSerialPoll.Text = "Serial Poll";
            this.toolStripStatusSerialPoll.Click += new System.EventHandler(this.ToolStripStatusSerialPoll_Click);
            // 
            // toolStripStatusLabelServerStatus
            // 
            this.toolStripStatusLabelServerStatus.BackColor = System.Drawing.Color.MistyRose;
            this.toolStripStatusLabelServerStatus.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabelServerStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.toolStripStatusLabelServerStatus.Name = "toolStripStatusLabelServerStatus";
            this.toolStripStatusLabelServerStatus.Size = new System.Drawing.Size(123, 25);
            this.toolStripStatusLabelServerStatus.Text = "Server: Stopped";
            // 
            // toolStripStatusLabelClientCount
            // 
            this.toolStripStatusLabelClientCount.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabelClientCount.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.toolStripStatusLabelClientCount.Name = "toolStripStatusLabelClientCount";
            this.toolStripStatusLabelClientCount.Size = new System.Drawing.Size(126, 25);
            this.toolStripStatusLabelClientCount.Text = "Server: 0 Clients";
            // 
            // toolStripStatusMemory
            // 
            this.toolStripStatusMemory.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusMemory.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.toolStripStatusMemory.Name = "toolStripStatusMemory";
            this.toolStripStatusMemory.Size = new System.Drawing.Size(89, 25);
            this.toolStripStatusMemory.Text = "Memory: 0";
            this.toolStripStatusMemory.Click += new System.EventHandler(this.ToolStripStatusMemory_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Serial interval (s):";
            // 
            // labelSerialInterval
            // 
            this.labelSerialInterval.AutoSize = true;
            this.labelSerialInterval.Location = new System.Drawing.Point(154, 50);
            this.labelSerialInterval.Name = "labelSerialInterval";
            this.labelSerialInterval.Size = new System.Drawing.Size(19, 21);
            this.labelSerialInterval.TabIndex = 3;
            this.labelSerialInterval.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "Serial Name:";
            // 
            // labelSerialPortName
            // 
            this.labelSerialPortName.AutoSize = true;
            this.labelSerialPortName.Location = new System.Drawing.Point(153, 28);
            this.labelSerialPortName.Name = "labelSerialPortName";
            this.labelSerialPortName.Size = new System.Drawing.Size(53, 21);
            this.labelSerialPortName.TabIndex = 5;
            this.labelSerialPortName.Text = "COMx";
            // 
            // buttonSerialConnect
            // 
            this.buttonSerialConnect.Location = new System.Drawing.Point(233, 27);
            this.buttonSerialConnect.Name = "buttonSerialConnect";
            this.buttonSerialConnect.Size = new System.Drawing.Size(138, 41);
            this.buttonSerialConnect.TabIndex = 6;
            this.buttonSerialConnect.Text = "Connect";
            this.buttonSerialConnect.UseVisualStyleBackColor = true;
            this.buttonSerialConnect.Click += new System.EventHandler(this.ButtonSerialConnect_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 21);
            this.label3.TabIndex = 9;
            this.label3.Text = "Last Response Received:";
            // 
            // labelLastSerialResponse
            // 
            this.labelLastSerialResponse.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelLastSerialResponse.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelLastSerialResponse.Location = new System.Drawing.Point(190, 71);
            this.labelLastSerialResponse.Name = "labelLastSerialResponse";
            this.labelLastSerialResponse.Size = new System.Drawing.Size(418, 25);
            this.labelLastSerialResponse.TabIndex = 10;
            this.labelLastSerialResponse.Text = "waiting...";
            this.labelLastSerialResponse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBoxSerial
            // 
            this.groupBoxSerial.Controls.Add(this.labelSimulateRate);
            this.groupBoxSerial.Controls.Add(this.trackBarSimulateRate);
            this.groupBoxSerial.Controls.Add(this.label1);
            this.groupBoxSerial.Controls.Add(this.labelLastSerialResponse);
            this.groupBoxSerial.Controls.Add(this.labelSerialInterval);
            this.groupBoxSerial.Controls.Add(this.label3);
            this.groupBoxSerial.Controls.Add(this.label2);
            this.groupBoxSerial.Controls.Add(this.labelSerialPortName);
            this.groupBoxSerial.Controls.Add(this.buttonSerialConnect);
            this.groupBoxSerial.Location = new System.Drawing.Point(12, 34);
            this.groupBoxSerial.Name = "groupBoxSerial";
            this.groupBoxSerial.Size = new System.Drawing.Size(614, 106);
            this.groupBoxSerial.TabIndex = 12;
            this.groupBoxSerial.TabStop = false;
            // 
            // labelSimulateRate
            // 
            this.labelSimulateRate.Location = new System.Drawing.Point(377, 19);
            this.labelSimulateRate.Name = "labelSimulateRate";
            this.labelSimulateRate.Size = new System.Drawing.Size(231, 21);
            this.labelSimulateRate.TabIndex = 12;
            this.labelSimulateRate.Text = "Simulate Rate of Change (1-5)";
            this.labelSimulateRate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // trackBarSimulateRate
            // 
            this.trackBarSimulateRate.AutoSize = false;
            this.trackBarSimulateRate.LargeChange = 2;
            this.trackBarSimulateRate.Location = new System.Drawing.Point(377, 43);
            this.trackBarSimulateRate.Maximum = 5;
            this.trackBarSimulateRate.Minimum = 1;
            this.trackBarSimulateRate.Name = "trackBarSimulateRate";
            this.trackBarSimulateRate.Size = new System.Drawing.Size(231, 25);
            this.trackBarSimulateRate.TabIndex = 11;
            this.trackBarSimulateRate.Value = 1;
            this.trackBarSimulateRate.ValueChanged += new System.EventHandler(this.trackBarSimulateRate_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 21);
            this.label4.TabIndex = 13;
            this.label4.Text = "Server Port:";
            // 
            // labelServerPort
            // 
            this.labelServerPort.AutoSize = true;
            this.labelServerPort.Location = new System.Drawing.Point(103, 28);
            this.labelServerPort.Name = "labelServerPort";
            this.labelServerPort.Size = new System.Drawing.Size(46, 21);
            this.labelServerPort.TabIndex = 14;
            this.labelServerPort.Text = "1234";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelLastServerRequest);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.buttonServerStart);
            this.groupBox1.Controls.Add(this.labelServerPort);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(632, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(513, 106);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // labelLastServerRequest
            // 
            this.labelLastServerRequest.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelLastServerRequest.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelLastServerRequest.Location = new System.Drawing.Point(189, 71);
            this.labelLastServerRequest.Name = "labelLastServerRequest";
            this.labelLastServerRequest.Size = new System.Drawing.Size(318, 25);
            this.labelLastServerRequest.TabIndex = 12;
            this.labelLastServerRequest.Text = "waiting...";
            this.labelLastServerRequest.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(167, 21);
            this.label6.TabIndex = 12;
            this.label6.Text = "Last Request Received:";
            // 
            // buttonServerStart
            // 
            this.buttonServerStart.Enabled = false;
            this.buttonServerStart.Location = new System.Drawing.Point(189, 27);
            this.buttonServerStart.Name = "buttonServerStart";
            this.buttonServerStart.Size = new System.Drawing.Size(77, 41);
            this.buttonServerStart.TabIndex = 12;
            this.buttonServerStart.Text = "Start";
            this.buttonServerStart.UseVisualStyleBackColor = true;
            this.buttonServerStart.Click += new System.EventHandler(this.ButtonServerStart_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 21);
            this.label5.TabIndex = 16;
            this.label5.Text = "Latest Raw Reading:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(193, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(203, 21);
            this.label7.TabIndex = 17;
            this.label7.Text = "Latest Averaged Reading:";
            // 
            // labelLatestRawMag
            // 
            this.labelLatestRawMag.AutoSize = true;
            this.labelLatestRawMag.Location = new System.Drawing.Point(171, 0);
            this.labelLatestRawMag.Name = "labelLatestRawMag";
            this.labelLatestRawMag.Size = new System.Drawing.Size(16, 21);
            this.labelLatestRawMag.TabIndex = 18;
            this.labelLatestRawMag.Text = "-";
            // 
            // labelLatestAvMag
            // 
            this.labelLatestAvMag.AutoSize = true;
            this.labelLatestAvMag.Location = new System.Drawing.Point(402, 0);
            this.labelLatestAvMag.Name = "labelLatestAvMag";
            this.labelLatestAvMag.Size = new System.Drawing.Size(16, 21);
            this.labelLatestAvMag.TabIndex = 19;
            this.labelLatestAvMag.Text = "-";
            // 
            // labelLatestTemp
            // 
            this.labelLatestTemp.AutoSize = true;
            this.labelLatestTemp.Location = new System.Drawing.Point(541, 0);
            this.labelLatestTemp.Name = "labelLatestTemp";
            this.labelLatestTemp.Size = new System.Drawing.Size(16, 21);
            this.labelLatestTemp.TabIndex = 21;
            this.labelLatestTemp.Text = "-";
            // 
            // flowLayoutPanelLatestData
            // 
            this.flowLayoutPanelLatestData.AutoSize = true;
            this.flowLayoutPanelLatestData.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelLatestData.Controls.Add(this.label5);
            this.flowLayoutPanelLatestData.Controls.Add(this.labelLatestRawMag);
            this.flowLayoutPanelLatestData.Controls.Add(this.label7);
            this.flowLayoutPanelLatestData.Controls.Add(this.labelLatestAvMag);
            this.flowLayoutPanelLatestData.Controls.Add(this.label8);
            this.flowLayoutPanelLatestData.Controls.Add(this.labelLatestTemp);
            this.flowLayoutPanelLatestData.Controls.Add(this.label10);
            this.flowLayoutPanelLatestData.Controls.Add(this.labelBortle);
            this.flowLayoutPanelLatestData.Controls.Add(this.label9);
            this.flowLayoutPanelLatestData.Controls.Add(this.labelNELM);
            this.flowLayoutPanelLatestData.Controls.Add(this.labelNELMColor);
            this.flowLayoutPanelLatestData.Location = new System.Drawing.Point(12, 146);
            this.flowLayoutPanelLatestData.Name = "flowLayoutPanelLatestData";
            this.flowLayoutPanelLatestData.Size = new System.Drawing.Size(794, 21);
            this.flowLayoutPanelLatestData.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(424, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 21);
            this.label8.TabIndex = 22;
            this.label8.Text = "Temperature:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(563, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 21);
            this.label10.TabIndex = 27;
            this.label10.Text = "Bortle #:";
            // 
            // labelBortle
            // 
            this.labelBortle.AutoSize = true;
            this.labelBortle.Location = new System.Drawing.Point(642, 0);
            this.labelBortle.Name = "labelBortle";
            this.labelBortle.Size = new System.Drawing.Size(16, 21);
            this.labelBortle.TabIndex = 23;
            this.labelBortle.Text = "-";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(664, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 21);
            this.label9.TabIndex = 24;
            this.label9.Text = "NELM:";
            // 
            // labelNELM
            // 
            this.labelNELM.AutoSize = true;
            this.labelNELM.Location = new System.Drawing.Point(729, 0);
            this.labelNELM.Name = "labelNELM";
            this.labelNELM.Size = new System.Drawing.Size(16, 21);
            this.labelNELM.TabIndex = 25;
            this.labelNELM.Text = "-";
            // 
            // labelNELMColor
            // 
            this.labelNELMColor.BackColor = System.Drawing.Color.White;
            this.labelNELMColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelNELMColor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelNELMColor.Location = new System.Drawing.Point(751, 0);
            this.labelNELMColor.Name = "labelNELMColor";
            this.labelNELMColor.Size = new System.Drawing.Size(40, 21);
            this.labelNELMColor.TabIndex = 26;
            // 
            // panelTrendContainer
            // 
            this.panelTrendContainer.Location = new System.Drawing.Point(12, 173);
            this.panelTrendContainer.Name = "panelTrendContainer";
            this.panelTrendContainer.Size = new System.Drawing.Size(1133, 355);
            this.panelTrendContainer.TabIndex = 23;
            // 
            // contextMenuStripMemory
            // 
            this.contextMenuStripMemory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemShowDataStore,
            this.toolStripSeparator2,
            this.clearMemoryRecordsToolStripMenuItem});
            this.contextMenuStripMemory.Name = "contextMenuStrip1";
            this.contextMenuStripMemory.Size = new System.Drawing.Size(195, 54);
            // 
            // toolStripMenuItemShowDataStore
            // 
            this.toolStripMenuItemShowDataStore.Name = "toolStripMenuItemShowDataStore";
            this.toolStripMenuItemShowDataStore.Size = new System.Drawing.Size(194, 22);
            this.toolStripMenuItemShowDataStore.Text = "View Memory Data";
            this.toolStripMenuItemShowDataStore.Click += new System.EventHandler(this.ToolStripMenuItemShowDataStore_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(191, 6);
            // 
            // clearMemoryRecordsToolStripMenuItem
            // 
            this.clearMemoryRecordsToolStripMenuItem.Name = "clearMemoryRecordsToolStripMenuItem";
            this.clearMemoryRecordsToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.clearMemoryRecordsToolStripMenuItem.Text = "Clear Memory Records";
            this.clearMemoryRecordsToolStripMenuItem.Click += new System.EventHandler(this.ClearMemoryRecordsToolStripMenuItem_Click);
            // 
            // contextMenuStripSerial
            // 
            this.contextMenuStripSerial.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewLatestResponsesToolStripMenuItem,
            this.toolStripSeparator3,
            this.sendCommandToolStripMenuItem});
            this.contextMenuStripSerial.Name = "contextMenuStripSerial";
            this.contextMenuStripSerial.Size = new System.Drawing.Size(192, 54);
            // 
            // viewLatestResponsesToolStripMenuItem
            // 
            this.viewLatestResponsesToolStripMenuItem.Name = "viewLatestResponsesToolStripMenuItem";
            this.viewLatestResponsesToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.viewLatestResponsesToolStripMenuItem.Text = "View Latest Responses";
            this.viewLatestResponsesToolStripMenuItem.Click += new System.EventHandler(this.ViewLatestResponsesToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(188, 6);
            // 
            // sendCommandToolStripMenuItem
            // 
            this.sendCommandToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ixUnitInformationToolStripMenuItem,
            this.uxUnaveragedDataToolStripMenuItem,
            this.rxAveragedDataToolStripMenuItem});
            this.sendCommandToolStripMenuItem.Name = "sendCommandToolStripMenuItem";
            this.sendCommandToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.sendCommandToolStripMenuItem.Text = "Send Command";
            // 
            // ixUnitInformationToolStripMenuItem
            // 
            this.ixUnitInformationToolStripMenuItem.Enabled = false;
            this.ixUnitInformationToolStripMenuItem.Name = "ixUnitInformationToolStripMenuItem";
            this.ixUnitInformationToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.ixUnitInformationToolStripMenuItem.Text = "ix - Unit Information";
            this.ixUnitInformationToolStripMenuItem.Click += new System.EventHandler(this.IXUnitInformationToolStripMenuItem_Click);
            // 
            // uxUnaveragedDataToolStripMenuItem
            // 
            this.uxUnaveragedDataToolStripMenuItem.Enabled = false;
            this.uxUnaveragedDataToolStripMenuItem.Name = "uxUnaveragedDataToolStripMenuItem";
            this.uxUnaveragedDataToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.uxUnaveragedDataToolStripMenuItem.Text = "ux - Unaveraged Data";
            this.uxUnaveragedDataToolStripMenuItem.Click += new System.EventHandler(this.UXUnaveragedDataToolStripMenuItem_Click);
            // 
            // rxAveragedDataToolStripMenuItem
            // 
            this.rxAveragedDataToolStripMenuItem.Enabled = false;
            this.rxAveragedDataToolStripMenuItem.Name = "rxAveragedDataToolStripMenuItem";
            this.rxAveragedDataToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.rxAveragedDataToolStripMenuItem.Text = "rx - Averaged Data";
            this.rxAveragedDataToolStripMenuItem.Click += new System.EventHandler(this.RXAveragedDataToolStripMenuItem_Click);
            // 
            // UniUSBSQMServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1157, 561);
            this.Controls.Add(this.panelTrendContainer);
            this.Controls.Add(this.flowLayoutPanelLatestData);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxSerial);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.menuStripMain);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripMain;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1173, 600);
            this.Name = "UniUSBSQMServer";
            this.Text = "Unihedron USB SQM Meter Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UniUSBSQMServer_FormClosing);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.groupBoxSerial.ResumeLayout(false);
            this.groupBoxSerial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSimulateRate)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.flowLayoutPanelLatestData.ResumeLayout(false);
            this.flowLayoutPanelLatestData.PerformLayout();
            this.contextMenuStripMemory.ResumeLayout(false);
            this.contextMenuStripSerial.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStripMain;
        private ToolStripMenuItem toolStripMenuHelp;
        private ToolStripMenuItem aboutToolStripMenuItemAbout;
        private ToolStripSeparator toolStripSeparator1;
        private StatusStrip statusStripMain;
        private ToolStripStatusLabel toolStripStatusLabel;
        private ToolStripStatusLabel toolStripStatusSerialState;
        private ToolStripStatusLabel toolStripStatusLabelServerStatus;
        private ToolStripStatusLabel toolStripStatusLabelClientCount;
        private Label label1;
        private Label labelSerialInterval;
        private Label label2;
        private Label labelSerialPortName;
        private Button buttonSerialConnect;
        private ToolStripMenuItem toolStripMenuConfig;
        private ToolStripMenuItem serialToolStripMenuItem;
        private Label label3;
        private Label labelLastSerialResponse;
        private GroupBox groupBoxSerial;
        private ToolStripMenuItem serverToolStripMenuItem;
        private Label label4;
        private Label labelServerPort;
        private GroupBox groupBox1;
        private Button buttonServerStart;
        private Label label6;
        private Label labelLastServerRequest;
        private Label label5;
        private Label label7;
        private Label labelLatestRawMag;
        private Label labelLatestAvMag;
        private Label labelLatestTemp;
        private FlowLayoutPanel flowLayoutPanelLatestData;
        private Label label8;
        private Label labelBortle;
        private Label label9;
        private Label labelNELM;
        private Label labelNELMColor;
        private Label label10;
        private ToolStripStatusLabel toolStripStatusSerialPoll;
        private ToolStripMenuItem loggingToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItemVisitGithub;
        private ToolStripMenuItem toolStripMenuItemVisitWebsite;
        private ToolStripMenuItem toolStripMenuItemVisitYoutube;
        private Panel panelTrendContainer;
        private ToolStripStatusLabel toolStripStatusMemory;
        private ContextMenuStrip contextMenuStripMemory;
        private ToolStripMenuItem clearMemoryRecordsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem toolStripMenuItemShowDataStore;
        private ContextMenuStrip contextMenuStripSerial;
        private ToolStripMenuItem sendCommandToolStripMenuItem;
        private ToolStripMenuItem ixUnitInformationToolStripMenuItem;
        private ToolStripMenuItem uxUnaveragedDataToolStripMenuItem;
        private ToolStripMenuItem rxAveragedDataToolStripMenuItem;
        private ToolStripMenuItem viewLatestResponsesToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem trendUnitsToolStripMenuItem;
        private Label labelSimulateRate;
        private TrackBar trackBarSimulateRate;
    }
}