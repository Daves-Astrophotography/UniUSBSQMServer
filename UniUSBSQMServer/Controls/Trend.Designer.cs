namespace UniUSBSQMServer
{
    partial class Trend
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBoxRawMPAS = new System.Windows.Forms.CheckBox();
            this.checkBoxAvgMPAS = new System.Windows.Forms.CheckBox();
            this.checkBoxTemp = new System.Windows.Forms.CheckBox();
            this.checkBoxNELM = new System.Windows.Forms.CheckBox();
            this.buttonRunStop = new System.Windows.Forms.Button();
            this.pictureBoxTrend = new System.Windows.Forms.PictureBox();
            this.horizontalTrendScroll = new System.Windows.Forms.HScrollBar();
            this.labelMax = new System.Windows.Forms.Label();
            this.labelMid = new System.Windows.Forms.Label();
            this.labelMin = new System.Windows.Forms.Label();
            this.labelValue34 = new System.Windows.Forms.Label();
            this.labelValue14 = new System.Windows.Forms.Label();
            this.pictureBoxPens = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTrend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPens)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.checkBoxRawMPAS);
            this.flowLayoutPanel1.Controls.Add(this.checkBoxAvgMPAS);
            this.flowLayoutPanel1.Controls.Add(this.checkBoxTemp);
            this.flowLayoutPanel1.Controls.Add(this.checkBoxNELM);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(613, 20);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // checkBoxRawMPAS
            // 
            this.checkBoxRawMPAS.AutoSize = true;
            this.checkBoxRawMPAS.Checked = true;
            this.checkBoxRawMPAS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxRawMPAS.ForeColor = System.Drawing.Color.Red;
            this.checkBoxRawMPAS.Location = new System.Drawing.Point(3, 3);
            this.checkBoxRawMPAS.Name = "checkBoxRawMPAS";
            this.checkBoxRawMPAS.Size = new System.Drawing.Size(82, 19);
            this.checkBoxRawMPAS.TabIndex = 0;
            this.checkBoxRawMPAS.Text = "Raw MPAS";
            this.checkBoxRawMPAS.UseVisualStyleBackColor = true;
            // 
            // checkBoxAvgMPAS
            // 
            this.checkBoxAvgMPAS.AutoSize = true;
            this.checkBoxAvgMPAS.Checked = true;
            this.checkBoxAvgMPAS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAvgMPAS.ForeColor = System.Drawing.Color.Blue;
            this.checkBoxAvgMPAS.Location = new System.Drawing.Point(91, 3);
            this.checkBoxAvgMPAS.Name = "checkBoxAvgMPAS";
            this.checkBoxAvgMPAS.Size = new System.Drawing.Size(81, 19);
            this.checkBoxAvgMPAS.TabIndex = 1;
            this.checkBoxAvgMPAS.Text = "Avg MPAS";
            this.checkBoxAvgMPAS.UseVisualStyleBackColor = true;
            // 
            // checkBoxTemp
            // 
            this.checkBoxTemp.AutoSize = true;
            this.checkBoxTemp.Checked = true;
            this.checkBoxTemp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxTemp.ForeColor = System.Drawing.Color.Yellow;
            this.checkBoxTemp.Location = new System.Drawing.Point(178, 3);
            this.checkBoxTemp.Name = "checkBoxTemp";
            this.checkBoxTemp.Size = new System.Drawing.Size(55, 19);
            this.checkBoxTemp.TabIndex = 2;
            this.checkBoxTemp.Text = "Temp";
            this.checkBoxTemp.UseVisualStyleBackColor = true;
            // 
            // checkBoxNELM
            // 
            this.checkBoxNELM.AutoSize = true;
            this.checkBoxNELM.Checked = true;
            this.checkBoxNELM.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxNELM.ForeColor = System.Drawing.Color.Lime;
            this.checkBoxNELM.Location = new System.Drawing.Point(239, 3);
            this.checkBoxNELM.Name = "checkBoxNELM";
            this.checkBoxNELM.Size = new System.Drawing.Size(58, 19);
            this.checkBoxNELM.TabIndex = 3;
            this.checkBoxNELM.Text = "NELM";
            this.checkBoxNELM.UseVisualStyleBackColor = true;
            // 
            // buttonRunStop
            // 
            this.buttonRunStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRunStop.FlatAppearance.BorderSize = 0;
            this.buttonRunStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRunStop.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonRunStop.Location = new System.Drawing.Point(637, 0);
            this.buttonRunStop.Margin = new System.Windows.Forms.Padding(0);
            this.buttonRunStop.Name = "buttonRunStop";
            this.buttonRunStop.Size = new System.Drawing.Size(20, 20);
            this.buttonRunStop.TabIndex = 4;
            this.buttonRunStop.Text = "Pause";
            this.buttonRunStop.UseMnemonic = false;
            this.buttonRunStop.UseVisualStyleBackColor = true;
            this.buttonRunStop.Visible = false;
            this.buttonRunStop.Click += new System.EventHandler(this.ButtonRunStop_Click);
            // 
            // pictureBoxTrend
            // 
            this.pictureBoxTrend.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBoxTrend.Location = new System.Drawing.Point(58, 21);
            this.pictureBoxTrend.Name = "pictureBoxTrend";
            this.pictureBoxTrend.Size = new System.Drawing.Size(52, 168);
            this.pictureBoxTrend.TabIndex = 1;
            this.pictureBoxTrend.TabStop = false;
            // 
            // horizontalTrendScroll
            // 
            this.horizontalTrendScroll.Enabled = false;
            this.horizontalTrendScroll.Location = new System.Drawing.Point(0, 199);
            this.horizontalTrendScroll.Name = "horizontalTrendScroll";
            this.horizontalTrendScroll.Size = new System.Drawing.Size(676, 20);
            this.horizontalTrendScroll.TabIndex = 2;
            this.horizontalTrendScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HorizontalTrendScroll_Scroll);
            // 
            // labelMax
            // 
            this.labelMax.AutoSize = true;
            this.labelMax.ForeColor = System.Drawing.Color.Black;
            this.labelMax.Location = new System.Drawing.Point(3, 26);
            this.labelMax.Margin = new System.Windows.Forms.Padding(0);
            this.labelMax.Name = "labelMax";
            this.labelMax.Size = new System.Drawing.Size(25, 15);
            this.labelMax.TabIndex = 3;
            this.labelMax.Text = "100";
            this.labelMax.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.labelMax.Visible = false;
            // 
            // labelMid
            // 
            this.labelMid.AutoSize = true;
            this.labelMid.ForeColor = System.Drawing.Color.Black;
            this.labelMid.Location = new System.Drawing.Point(3, 101);
            this.labelMid.Margin = new System.Windows.Forms.Padding(0);
            this.labelMid.Name = "labelMid";
            this.labelMid.Size = new System.Drawing.Size(19, 15);
            this.labelMid.TabIndex = 4;
            this.labelMid.Text = "50";
            this.labelMid.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelMid.Visible = false;
            // 
            // labelMin
            // 
            this.labelMin.AutoSize = true;
            this.labelMin.ForeColor = System.Drawing.Color.Black;
            this.labelMin.Location = new System.Drawing.Point(3, 179);
            this.labelMin.Margin = new System.Windows.Forms.Padding(0);
            this.labelMin.Name = "labelMin";
            this.labelMin.Size = new System.Drawing.Size(13, 15);
            this.labelMin.TabIndex = 5;
            this.labelMin.Text = "0";
            this.labelMin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelMin.Visible = false;
            // 
            // labelValue34
            // 
            this.labelValue34.AutoSize = true;
            this.labelValue34.ForeColor = System.Drawing.Color.Black;
            this.labelValue34.Location = new System.Drawing.Point(3, 63);
            this.labelValue34.Margin = new System.Windows.Forms.Padding(0);
            this.labelValue34.Name = "labelValue34";
            this.labelValue34.Size = new System.Drawing.Size(19, 15);
            this.labelValue34.TabIndex = 6;
            this.labelValue34.Text = "75";
            this.labelValue34.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelValue34.Visible = false;
            // 
            // labelValue14
            // 
            this.labelValue14.AutoSize = true;
            this.labelValue14.ForeColor = System.Drawing.Color.Black;
            this.labelValue14.Location = new System.Drawing.Point(3, 142);
            this.labelValue14.Margin = new System.Windows.Forms.Padding(0);
            this.labelValue14.Name = "labelValue14";
            this.labelValue14.Size = new System.Drawing.Size(19, 15);
            this.labelValue14.TabIndex = 7;
            this.labelValue14.Text = "25";
            this.labelValue14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelValue14.Visible = false;
            // 
            // pictureBoxPens
            // 
            this.pictureBoxPens.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBoxPens.Location = new System.Drawing.Point(239, 21);
            this.pictureBoxPens.Name = "pictureBoxPens";
            this.pictureBoxPens.Size = new System.Drawing.Size(16, 168);
            this.pictureBoxPens.TabIndex = 8;
            this.pictureBoxPens.TabStop = false;
            // 
            // Trend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pictureBoxPens);
            this.Controls.Add(this.labelValue14);
            this.Controls.Add(this.labelValue34);
            this.Controls.Add(this.labelMin);
            this.Controls.Add(this.labelMid);
            this.Controls.Add(this.buttonRunStop);
            this.Controls.Add(this.labelMax);
            this.Controls.Add(this.horizontalTrendScroll);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.pictureBoxTrend);
            this.DoubleBuffered = true;
            this.Name = "Trend";
            this.Size = new System.Drawing.Size(674, 241);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.Trend_Layout);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTrend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPens)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private CheckBox checkBoxRawMPAS;
        private CheckBox checkBoxAvgMPAS;
        private CheckBox checkBoxTemp;
        private CheckBox checkBoxNELM;
        private PictureBox pictureBoxTrend;
        private HScrollBar horizontalTrendScroll;
        private Label labelMax;
        private Label labelMid;
        private Label labelMin;
        private Label labelValue34;
        private Label labelValue14;
        private Button buttonRunStop;
        private PictureBox pictureBoxPens;
    }
}
