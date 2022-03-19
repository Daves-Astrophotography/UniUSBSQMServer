namespace UniUSBSQMServer.Forms
{
    partial class ConfigTrendForm
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.numericUpDownRangeMin = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownRangeMax = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxRange = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.colorDialogPicker = new System.Windows.Forms.ColorDialog();
            this.groupBoxSeries = new System.Windows.Forms.GroupBox();
            this.comboBoxTempUnits = new System.Windows.Forms.ComboBox();
            this.labelNELMColor = new System.Windows.Forms.Label();
            this.labelTempColor = new System.Windows.Forms.Label();
            this.labelAvgMPasColor = new System.Windows.Forms.Label();
            this.labelRawMPasColor = new System.Windows.Forms.Label();
            this.checkBoxNELM = new System.Windows.Forms.CheckBox();
            this.checkBoxTemp = new System.Windows.Forms.CheckBox();
            this.checkBoxAvgMPas = new System.Windows.Forms.CheckBox();
            this.checkBoxRawMPas = new System.Windows.Forms.CheckBox();
            this.buttonSetDefaults = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRangeMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRangeMax)).BeginInit();
            this.groupBoxRange.SuspendLayout();
            this.groupBoxSeries.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(127, 271);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 38);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(211, 271);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 38);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "Ok";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // numericUpDownRangeMin
            // 
            this.numericUpDownRangeMin.Location = new System.Drawing.Point(132, 57);
            this.numericUpDownRangeMin.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.numericUpDownRangeMin.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numericUpDownRangeMin.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownRangeMin.Name = "numericUpDownRangeMin";
            this.numericUpDownRangeMin.Size = new System.Drawing.Size(61, 29);
            this.numericUpDownRangeMin.TabIndex = 11;
            // 
            // numericUpDownRangeMax
            // 
            this.numericUpDownRangeMax.Location = new System.Drawing.Point(132, 23);
            this.numericUpDownRangeMax.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.numericUpDownRangeMax.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.numericUpDownRangeMax.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numericUpDownRangeMax.Name = "numericUpDownRangeMax";
            this.numericUpDownRangeMax.Size = new System.Drawing.Size(61, 29);
            this.numericUpDownRangeMax.TabIndex = 30;
            this.numericUpDownRangeMax.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 21);
            this.label2.TabIndex = 12;
            this.label2.Text = "Maximum:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 21);
            this.label1.TabIndex = 13;
            this.label1.Text = "Minimum:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBoxRange
            // 
            this.groupBoxRange.Controls.Add(this.label4);
            this.groupBoxRange.Controls.Add(this.label3);
            this.groupBoxRange.Controls.Add(this.label2);
            this.groupBoxRange.Controls.Add(this.numericUpDownRangeMin);
            this.groupBoxRange.Controls.Add(this.label1);
            this.groupBoxRange.Controls.Add(this.numericUpDownRangeMax);
            this.groupBoxRange.Location = new System.Drawing.Point(12, 12);
            this.groupBoxRange.Name = "groupBoxRange";
            this.groupBoxRange.Size = new System.Drawing.Size(274, 100);
            this.groupBoxRange.TabIndex = 31;
            this.groupBoxRange.TabStop = false;
            this.groupBoxRange.Text = "Trend Range";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(202, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 17);
            this.label4.TabIndex = 32;
            this.label4.Text = "-100 to 0";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(202, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 17);
            this.label3.TabIndex = 31;
            this.label3.Text = "25 to 150";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBoxSeries
            // 
            this.groupBoxSeries.Controls.Add(this.comboBoxTempUnits);
            this.groupBoxSeries.Controls.Add(this.labelNELMColor);
            this.groupBoxSeries.Controls.Add(this.labelTempColor);
            this.groupBoxSeries.Controls.Add(this.labelAvgMPasColor);
            this.groupBoxSeries.Controls.Add(this.labelRawMPasColor);
            this.groupBoxSeries.Controls.Add(this.checkBoxNELM);
            this.groupBoxSeries.Controls.Add(this.checkBoxTemp);
            this.groupBoxSeries.Controls.Add(this.checkBoxAvgMPas);
            this.groupBoxSeries.Controls.Add(this.checkBoxRawMPas);
            this.groupBoxSeries.Location = new System.Drawing.Point(12, 118);
            this.groupBoxSeries.Name = "groupBoxSeries";
            this.groupBoxSeries.Size = new System.Drawing.Size(274, 147);
            this.groupBoxSeries.TabIndex = 32;
            this.groupBoxSeries.TabStop = false;
            this.groupBoxSeries.Text = "Data Series";
            // 
            // comboBoxTempUnits
            // 
            this.comboBoxTempUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTempUnits.FormattingEnabled = true;
            this.comboBoxTempUnits.Location = new System.Drawing.Point(195, 84);
            this.comboBoxTempUnits.Name = "comboBoxTempUnits";
            this.comboBoxTempUnits.Size = new System.Drawing.Size(65, 29);
            this.comboBoxTempUnits.TabIndex = 8;
            // 
            // labelNELMColor
            // 
            this.labelNELMColor.BackColor = System.Drawing.Color.Lime;
            this.labelNELMColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelNELMColor.Location = new System.Drawing.Point(132, 115);
            this.labelNELMColor.Name = "labelNELMColor";
            this.labelNELMColor.Size = new System.Drawing.Size(38, 25);
            this.labelNELMColor.TabIndex = 7;
            this.labelNELMColor.Click += new System.EventHandler(this.LabelNELMColor_Click);
            // 
            // labelTempColor
            // 
            this.labelTempColor.BackColor = System.Drawing.Color.Yellow;
            this.labelTempColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelTempColor.Location = new System.Drawing.Point(132, 86);
            this.labelTempColor.Name = "labelTempColor";
            this.labelTempColor.Size = new System.Drawing.Size(38, 25);
            this.labelTempColor.TabIndex = 6;
            this.labelTempColor.Click += new System.EventHandler(this.LabelTempColor_Click);
            // 
            // labelAvgMPasColor
            // 
            this.labelAvgMPasColor.BackColor = System.Drawing.Color.Blue;
            this.labelAvgMPasColor.Location = new System.Drawing.Point(132, 57);
            this.labelAvgMPasColor.Name = "labelAvgMPasColor";
            this.labelAvgMPasColor.Size = new System.Drawing.Size(38, 25);
            this.labelAvgMPasColor.TabIndex = 5;
            this.labelAvgMPasColor.Click += new System.EventHandler(this.LabelAvgMPasColor_Click);
            // 
            // labelRawMPasColor
            // 
            this.labelRawMPasColor.BackColor = System.Drawing.Color.Red;
            this.labelRawMPasColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelRawMPasColor.Location = new System.Drawing.Point(132, 28);
            this.labelRawMPasColor.Name = "labelRawMPasColor";
            this.labelRawMPasColor.Size = new System.Drawing.Size(38, 25);
            this.labelRawMPasColor.TabIndex = 4;
            this.labelRawMPasColor.Click += new System.EventHandler(this.LabelRawMPasColor_Click);
            // 
            // checkBoxNELM
            // 
            this.checkBoxNELM.AutoSize = true;
            this.checkBoxNELM.Checked = true;
            this.checkBoxNELM.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxNELM.Location = new System.Drawing.Point(6, 115);
            this.checkBoxNELM.Name = "checkBoxNELM";
            this.checkBoxNELM.Size = new System.Drawing.Size(71, 25);
            this.checkBoxNELM.TabIndex = 3;
            this.checkBoxNELM.Text = "NELM";
            this.checkBoxNELM.UseVisualStyleBackColor = true;
            // 
            // checkBoxTemp
            // 
            this.checkBoxTemp.AutoSize = true;
            this.checkBoxTemp.Checked = true;
            this.checkBoxTemp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxTemp.Location = new System.Drawing.Point(6, 86);
            this.checkBoxTemp.Name = "checkBoxTemp";
            this.checkBoxTemp.Size = new System.Drawing.Size(116, 25);
            this.checkBoxTemp.TabIndex = 2;
            this.checkBoxTemp.Text = "Temperature";
            this.checkBoxTemp.UseVisualStyleBackColor = true;
            // 
            // checkBoxAvgMPas
            // 
            this.checkBoxAvgMPas.AutoSize = true;
            this.checkBoxAvgMPas.Checked = true;
            this.checkBoxAvgMPas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAvgMPas.Location = new System.Drawing.Point(6, 57);
            this.checkBoxAvgMPas.Name = "checkBoxAvgMPas";
            this.checkBoxAvgMPas.Size = new System.Drawing.Size(97, 25);
            this.checkBoxAvgMPas.TabIndex = 1;
            this.checkBoxAvgMPas.Text = "Avg MPas";
            this.checkBoxAvgMPas.UseVisualStyleBackColor = true;
            // 
            // checkBoxRawMPas
            // 
            this.checkBoxRawMPas.AutoSize = true;
            this.checkBoxRawMPas.Checked = true;
            this.checkBoxRawMPas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxRawMPas.Location = new System.Drawing.Point(6, 28);
            this.checkBoxRawMPas.Name = "checkBoxRawMPas";
            this.checkBoxRawMPas.Size = new System.Drawing.Size(100, 25);
            this.checkBoxRawMPas.TabIndex = 0;
            this.checkBoxRawMPas.Text = "Raw MPas";
            this.checkBoxRawMPas.UseVisualStyleBackColor = true;
            // 
            // buttonSetDefaults
            // 
            this.buttonSetDefaults.Location = new System.Drawing.Point(12, 271);
            this.buttonSetDefaults.Name = "buttonSetDefaults";
            this.buttonSetDefaults.Size = new System.Drawing.Size(75, 38);
            this.buttonSetDefaults.TabIndex = 33;
            this.buttonSetDefaults.Text = "Defaults";
            this.buttonSetDefaults.UseVisualStyleBackColor = true;
            this.buttonSetDefaults.Click += new System.EventHandler(this.ButtonSetDefaults_Click);
            // 
            // ConfigTrendForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(298, 317);
            this.ControlBox = false;
            this.Controls.Add(this.buttonSetDefaults);
            this.Controls.Add(this.groupBoxSeries);
            this.Controls.Add(this.groupBoxRange);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ConfigTrendForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configure Trend & Units";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRangeMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRangeMax)).EndInit();
            this.groupBoxRange.ResumeLayout(false);
            this.groupBoxRange.PerformLayout();
            this.groupBoxSeries.ResumeLayout(false);
            this.groupBoxSeries.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button buttonCancel;
        private Button buttonOK;
        private NumericUpDown numericUpDownRangeMin;
        private NumericUpDown numericUpDownRangeMax;
        private Label label2;
        private Label label1;
        private GroupBox groupBoxRange;
        private ColorDialog colorDialogPicker;
        private GroupBox groupBoxSeries;
        private ComboBox comboBoxTempUnits;
        private Label labelNELMColor;
        private Label labelTempColor;
        private Label labelAvgMPasColor;
        private Label labelRawMPasColor;
        private CheckBox checkBoxNELM;
        private CheckBox checkBoxTemp;
        private CheckBox checkBoxAvgMPas;
        private CheckBox checkBoxRawMPas;
        private Label label4;
        private Label label3;
        private Button buttonSetDefaults;
    }
}