namespace Road_rangerVS
{
    partial class ReportForm
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
            this.addressBox = new System.Windows.Forms.TextBox();
            this.toEmail = new System.Windows.Forms.Label();
            this.textEmail = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.subjectLabel = new System.Windows.Forms.Label();
            this.subjectText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // addressBox
            // 
            this.addressBox.Location = new System.Drawing.Point(118, 81);
            this.addressBox.Multiline = true;
            this.addressBox.Name = "addressBox";
            this.addressBox.Size = new System.Drawing.Size(416, 37);
            this.addressBox.TabIndex = 0;
            // 
            // toEmail
            // 
            this.toEmail.AutoSize = true;
            this.toEmail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toEmail.Location = new System.Drawing.Point(112, 46);
            this.toEmail.Name = "toEmail";
            this.toEmail.Size = new System.Drawing.Size(133, 32);
            this.toEmail.TabIndex = 1;
            this.toEmail.Text = "To address:";
            // 
            // textEmail
            // 
            this.textEmail.Location = new System.Drawing.Point(118, 219);
            this.textEmail.Multiline = true;
            this.textEmail.Name = "textEmail";
            this.textEmail.Size = new System.Drawing.Size(416, 297);
            this.textEmail.TabIndex = 2;
            this.textEmail.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // sendButton
            // 
            this.sendButton.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendButton.Location = new System.Drawing.Point(440, 545);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(94, 34);
            this.sendButton.TabIndex = 3;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // subjectLabel
            // 
            this.subjectLabel.AutoSize = true;
            this.subjectLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subjectLabel.Location = new System.Drawing.Point(112, 121);
            this.subjectLabel.Name = "subjectLabel";
            this.subjectLabel.Size = new System.Drawing.Size(99, 32);
            this.subjectLabel.TabIndex = 4;
            this.subjectLabel.Text = "Subject:";
            // 
            // subjectText
            // 
            this.subjectText.Location = new System.Drawing.Point(118, 156);
            this.subjectText.Multiline = true;
            this.subjectText.Name = "subjectText";
            this.subjectText.Size = new System.Drawing.Size(416, 39);
            this.subjectText.TabIndex = 5;
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 628);
            this.Controls.Add(this.subjectText);
            this.Controls.Add(this.subjectLabel);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.textEmail);
            this.Controls.Add(this.toEmail);
            this.Controls.Add(this.addressBox);
            this.Name = "ReportForm";
            this.Text = "ReportForm";
            this.Load += new System.EventHandler(this.ReportForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox addressBox;
        private System.Windows.Forms.Label toEmail;
        private System.Windows.Forms.TextBox textEmail;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Label subjectLabel;
        private System.Windows.Forms.TextBox subjectText;
    }
}