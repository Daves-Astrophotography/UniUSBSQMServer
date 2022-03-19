namespace UniUSBSQMServer.Forms
{
    partial class LatestMessagesForm
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
            this.listBoxLatest = new System.Windows.Forms.ListBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.labelUpdated = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxLatest
            // 
            this.listBoxLatest.FormattingEnabled = true;
            this.listBoxLatest.ItemHeight = 21;
            this.listBoxLatest.Location = new System.Drawing.Point(13, 13);
            this.listBoxLatest.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxLatest.Name = "listBoxLatest";
            this.listBoxLatest.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxLatest.Size = new System.Drawing.Size(531, 88);
            this.listBoxLatest.TabIndex = 0;
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(465, 108);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 38);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "Ok";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // labelUpdated
            // 
            this.labelUpdated.AutoSize = true;
            this.labelUpdated.ForeColor = System.Drawing.Color.SpringGreen;
            this.labelUpdated.Location = new System.Drawing.Point(13, 117);
            this.labelUpdated.Name = "labelUpdated";
            this.labelUpdated.Size = new System.Drawing.Size(69, 21);
            this.labelUpdated.TabIndex = 3;
            this.labelUpdated.Text = "Updated";
            this.labelUpdated.Visible = false;
            // 
            // LatestMessagesForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.CancelButton = this.buttonOK;
            this.ClientSize = new System.Drawing.Size(552, 158);
            this.ControlBox = false;
            this.Controls.Add(this.labelUpdated);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.listBoxLatest);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LatestMessagesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Latest Serial Messages";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox listBoxLatest;
        private Button buttonOK;
        private Label labelUpdated;
    }
}