using System;

namespace Road_rangerVS
{
	partial class MainForm
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
            this.title = new System.Windows.Forms.Label();
            this.upload = new System.Windows.Forms.Button();
            this.browseImage = new System.Windows.Forms.Button();
            this.filePath = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.reportButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.findYourCarButton = new System.Windows.Forms.Button();
            this.myHistory = new System.Windows.Forms.Button();
            this.cameraTopText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.title.Location = new System.Drawing.Point(863, 32);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(162, 29);
            this.title.TabIndex = 0;
            this.title.Text = "Road Ranger";
            this.title.Click += new System.EventHandler(this.label1_Click);
            // 
            // upload
            // 
            this.upload.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.upload.Location = new System.Drawing.Point(825, 150);
            this.upload.Name = "upload";
            this.upload.Size = new System.Drawing.Size(250, 35);
            this.upload.TabIndex = 1;
            this.upload.Text = "Upload";
            this.upload.UseVisualStyleBackColor = true;
            this.upload.Click += new System.EventHandler(this.uploadButtonClick);
            // 
            // browseImage
            // 
            this.browseImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.browseImage.Location = new System.Drawing.Point(825, 80);
            this.browseImage.Name = "browseImage";
            this.browseImage.Size = new System.Drawing.Size(250, 35);
            this.browseImage.TabIndex = 2;
            this.browseImage.Text = "Browse Image";
            this.browseImage.UseVisualStyleBackColor = true;
            this.browseImage.Click += new System.EventHandler(this.browseButtonClick);
            // 
            // filePath
            // 
            this.filePath.AutoSize = true;
            this.filePath.Location = new System.Drawing.Point(822, 118);
            this.filePath.Name = "filePath";
            this.filePath.Size = new System.Drawing.Size(16, 13);
            this.filePath.TabIndex = 3;
            this.filePath.Text = "...";
            this.filePath.Click += new System.EventHandler(this.label2_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.Black;
            this.pictureBox.Location = new System.Drawing.Point(12, 32);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(782, 514);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 5;
            this.pictureBox.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 579);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(250, 35);
            this.button1.TabIndex = 6;
            this.button1.Text = "&Camera On/Off";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.cameraClick);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 552);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(782, 21);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.selectCamera);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(268, 579);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(250, 35);
            this.button2.TabIndex = 8;
            this.button2.Text = "Capture VIew";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.captureClick);
            // 
            // reportButton
            // 
            this.reportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.reportButton.Location = new System.Drawing.Point(825, 238);
            this.reportButton.Margin = new System.Windows.Forms.Padding(2);
            this.reportButton.Name = "reportButton";
            this.reportButton.Size = new System.Drawing.Size(250, 35);
            this.reportButton.TabIndex = 9;
            this.reportButton.Text = "Report";
            this.reportButton.UseVisualStyleBackColor = true;
            this.reportButton.Click += new System.EventHandler(this.reportButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.exitButton.Location = new System.Drawing.Point(825, 575);
            this.exitButton.Margin = new System.Windows.Forms.Padding(2);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(250, 35);
            this.exitButton.TabIndex = 10;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // findYourCarButton
            // 
            this.findYourCarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.findYourCarButton.Location = new System.Drawing.Point(825, 278);
            this.findYourCarButton.Name = "findYourCarButton";
            this.findYourCarButton.Size = new System.Drawing.Size(250, 35);
            this.findYourCarButton.TabIndex = 11;
            this.findYourCarButton.Text = "Find Your Car";
            this.findYourCarButton.UseVisualStyleBackColor = true;
            this.findYourCarButton.Click += new System.EventHandler(this.findYourCarButton_Click);
            // 
            // myHistory
            // 
            this.myHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.myHistory.Location = new System.Drawing.Point(825, 319);
            this.myHistory.Name = "myHistory";
            this.myHistory.Size = new System.Drawing.Size(250, 35);
            this.myHistory.TabIndex = 12;
            this.myHistory.Text = "My History";
            this.myHistory.UseVisualStyleBackColor = true;
            this.myHistory.Click += new System.EventHandler(this.myHistory_Click);
            // 
            // cameraTopText
            // 
            this.cameraTopText.AutoSize = true;
            this.cameraTopText.Location = new System.Drawing.Point(12, 16);
            this.cameraTopText.Name = "cameraTopText";
            this.cameraTopText.Size = new System.Drawing.Size(33, 13);
            this.cameraTopText.TabIndex = 13;
            this.cameraTopText.Text = "View:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 621);
            this.Controls.Add(this.cameraTopText);
            this.Controls.Add(this.myHistory);
            this.Controls.Add(this.findYourCarButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.reportButton);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.filePath);
            this.Controls.Add(this.browseImage);
            this.Controls.Add(this.upload);
            this.Controls.Add(this.title);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormClosing);
            this.Load += new System.EventHandler(this.mainFormLoading);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Button upload;
        private System.Windows.Forms.Button browseImage;
        private System.Windows.Forms.Label filePath;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button reportButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button findYourCarButton;
        private System.Windows.Forms.Button myHistory;
        private System.Windows.Forms.Label cameraTopText;
    }
}

