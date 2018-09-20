namespace Road_rangerVS
{
	partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.upload = new System.Windows.Forms.Button();
            this.browseImage = new System.Windows.Forms.Button();
            this.filePath = new System.Windows.Forms.Label();
            this.imageRecognition = new System.Windows.Forms.Button();
            this.returnButton = new System.Windows.Forms.Button();
            this.videoButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(372, 111);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(431, 75);
            this.label1.TabIndex = 0;
            this.label1.Text = "Road Ranger";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // upload
            // 
            this.upload.Location = new System.Drawing.Point(578, 241);
            this.upload.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.upload.Name = "upload";
            this.upload.Size = new System.Drawing.Size(154, 35);
            this.upload.TabIndex = 1;
            this.upload.Text = "Upload";
            this.upload.UseVisualStyleBackColor = true;
            this.upload.Click += new System.EventHandler(this.UploadButtonClick);
            // 
            // browseImage
            // 
            this.browseImage.Location = new System.Drawing.Point(420, 241);
            this.browseImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.browseImage.Name = "browseImage";
            this.browseImage.Size = new System.Drawing.Size(150, 35);
            this.browseImage.TabIndex = 2;
            this.browseImage.Text = "Browse Image";
            this.browseImage.UseVisualStyleBackColor = true;
            this.browseImage.Click += new System.EventHandler(this.BrowseButtonClick);
            // 
            // filePath
            // 
            this.filePath.AutoSize = true;
            this.filePath.Location = new System.Drawing.Point(416, 289);
            this.filePath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.filePath.Name = "filePath";
            this.filePath.Size = new System.Drawing.Size(0, 20);
            this.filePath.TabIndex = 3;
            this.filePath.Click += new System.EventHandler(this.label2_Click);
            // 
            // imageRecognition
            // 
            this.imageRecognition.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imageRecognition.Location = new System.Drawing.Point(420, 337);
            this.imageRecognition.Name = "imageRecognition";
            this.imageRecognition.Size = new System.Drawing.Size(312, 48);
            this.imageRecognition.TabIndex = 4;
            this.imageRecognition.Text = "Image";
            this.imageRecognition.UseVisualStyleBackColor = true;
            this.imageRecognition.Click += new System.EventHandler(this.imageRecognition_Click);
            // 
            // returnButton
            // 
            this.returnButton.Location = new System.Drawing.Point(420, 445);
            this.returnButton.Name = "returnButton";
            this.returnButton.Size = new System.Drawing.Size(312, 59);
            this.returnButton.TabIndex = 5;
            this.returnButton.Text = "Return";
            this.returnButton.UseVisualStyleBackColor = true;
            this.returnButton.Click += new System.EventHandler(this.returnButton_Click);
            // 
            // videoButton
            // 
            this.videoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.videoButton.Location = new System.Drawing.Point(420, 391);
            this.videoButton.Name = "videoButton";
            this.videoButton.Size = new System.Drawing.Size(312, 48);
            this.videoButton.TabIndex = 6;
            this.videoButton.Text = "Video";
            this.videoButton.UseVisualStyleBackColor = true;
            // 
            // exitButton
            // 
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Location = new System.Drawing.Point(420, 510);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(312, 48);
            this.exitButton.TabIndex = 7;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.videoButton);
            this.Controls.Add(this.returnButton);
            this.Controls.Add(this.imageRecognition);
            this.Controls.Add(this.filePath);
            this.Controls.Add(this.browseImage);
            this.Controls.Add(this.upload);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button upload;
        private System.Windows.Forms.Button browseImage;
        private System.Windows.Forms.Label filePath;
        private System.Windows.Forms.Button imageRecognition;
        private System.Windows.Forms.Button returnButton;
        private System.Windows.Forms.Button videoButton;
        private System.Windows.Forms.Button exitButton;
    }
}

