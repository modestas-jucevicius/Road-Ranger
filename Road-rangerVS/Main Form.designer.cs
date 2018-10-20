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
            this.exitButton = new System.Windows.Forms.Button();
            this.cameraTopText = new System.Windows.Forms.Label();
            this.tab = new System.Windows.Forms.TabControl();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.tabReport = new System.Windows.Forms.TabPage();
            this.subjectText = new System.Windows.Forms.TextBox();
            this.subjectLabel = new System.Windows.Forms.Label();
            this.sendButton = new System.Windows.Forms.Button();
            this.textEmail = new System.Windows.Forms.TextBox();
            this.tabFindCar = new System.Windows.Forms.TabPage();
            this.licensePlate = new System.Windows.Forms.Label();
            this.findPictureBox = new System.Windows.Forms.PictureBox();
            this.findListView = new System.Windows.Forms.ListView();
            this.columnFind1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnFind2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnFind3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnFind4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.inputText = new System.Windows.Forms.TextBox();
            this.search = new System.Windows.Forms.Button();
            this.tabMyGallery = new System.Windows.Forms.TabPage();
            this.refreshButton = new System.Windows.Forms.Button();
            this.galleryListView = new System.Windows.Forms.ListView();
            this.column1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.galleryPictureBox = new System.Windows.Forms.PictureBox();
            this.removeButton = new System.Windows.Forms.Button();
            this.reportButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.tab.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabReport.SuspendLayout();
            this.tabFindCar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.findPictureBox)).BeginInit();
            this.tabMyGallery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.galleryPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.title.Location = new System.Drawing.Point(854, 25);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(162, 29);
            this.title.TabIndex = 0;
            this.title.Text = "Road Ranger";
            // 
            // upload
            // 
            this.upload.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.upload.Location = new System.Drawing.Point(816, 149);
            this.upload.Name = "upload";
            this.upload.Size = new System.Drawing.Size(250, 35);
            this.upload.TabIndex = 1;
            this.upload.Text = "Upload";
            this.upload.UseVisualStyleBackColor = true;
            this.upload.Click += new System.EventHandler(this.UploadButtonClick);
            // 
            // browseImage
            // 
            this.browseImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.browseImage.Location = new System.Drawing.Point(816, 84);
            this.browseImage.Name = "browseImage";
            this.browseImage.Size = new System.Drawing.Size(250, 35);
            this.browseImage.TabIndex = 2;
            this.browseImage.Text = "Browse Image";
            this.browseImage.UseVisualStyleBackColor = true;
            this.browseImage.Click += new System.EventHandler(this.BrowseButtonClick);
            // 
            // filePath
            // 
            this.filePath.AutoSize = true;
            this.filePath.Location = new System.Drawing.Point(813, 122);
            this.filePath.Name = "filePath";
            this.filePath.Size = new System.Drawing.Size(16, 13);
            this.filePath.TabIndex = 3;
            this.filePath.Text = "...";
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.Black;
            this.pictureBox.Location = new System.Drawing.Point(9, 25);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(782, 514);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 5;
            this.pictureBox.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 576);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(250, 35);
            this.button1.TabIndex = 6;
            this.button1.Text = "&Camera On/Off";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.CameraClick);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(9, 545);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(782, 21);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.SelectCamera);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(265, 576);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(271, 35);
            this.button2.TabIndex = 8;
            this.button2.Text = "Capture VIew";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.CaptureClick);
            // 
            // exitButton
            // 
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.exitButton.Location = new System.Drawing.Point(850, 660);
            this.exitButton.Margin = new System.Windows.Forms.Padding(2);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(250, 35);
            this.exitButton.TabIndex = 10;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.ExitButtonClick);
            // 
            // cameraTopText
            // 
            this.cameraTopText.AutoSize = true;
            this.cameraTopText.Location = new System.Drawing.Point(6, 3);
            this.cameraTopText.Name = "cameraTopText";
            this.cameraTopText.Size = new System.Drawing.Size(33, 13);
            this.cameraTopText.TabIndex = 13;
            this.cameraTopText.Text = "View:";
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tabMain);
            this.tab.Controls.Add(this.tabReport);
            this.tab.Controls.Add(this.tabFindCar);
            this.tab.Controls.Add(this.tabMyGallery);
            this.tab.Location = new System.Drawing.Point(9, 12);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(1091, 643);
            this.tab.TabIndex = 14;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.cameraTopText);
            this.tabMain.Controls.Add(this.pictureBox);
            this.tabMain.Controls.Add(this.comboBox1);
            this.tabMain.Controls.Add(this.title);
            this.tabMain.Controls.Add(this.upload);
            this.tabMain.Controls.Add(this.filePath);
            this.tabMain.Controls.Add(this.button1);
            this.tabMain.Controls.Add(this.browseImage);
            this.tabMain.Controls.Add(this.button2);
            this.tabMain.Location = new System.Drawing.Point(4, 22);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabMain.Size = new System.Drawing.Size(1083, 617);
            this.tabMain.TabIndex = 0;
            this.tabMain.Text = "Main";
            this.tabMain.UseVisualStyleBackColor = true;
            // 
            // tabReport
            // 
            this.tabReport.Controls.Add(this.subjectText);
            this.tabReport.Controls.Add(this.subjectLabel);
            this.tabReport.Controls.Add(this.sendButton);
            this.tabReport.Controls.Add(this.textEmail);
            this.tabReport.Location = new System.Drawing.Point(4, 22);
            this.tabReport.Name = "tabReport";
            this.tabReport.Padding = new System.Windows.Forms.Padding(3);
            this.tabReport.Size = new System.Drawing.Size(1083, 617);
            this.tabReport.TabIndex = 1;
            this.tabReport.Text = "Report";
            this.tabReport.UseVisualStyleBackColor = true;
            // 
            // subjectText
            // 
            this.subjectText.Location = new System.Drawing.Point(8, 44);
            this.subjectText.Margin = new System.Windows.Forms.Padding(2);
            this.subjectText.Multiline = true;
            this.subjectText.Name = "subjectText";
            this.subjectText.Size = new System.Drawing.Size(390, 27);
            this.subjectText.TabIndex = 9;
            // 
            // subjectLabel
            // 
            this.subjectLabel.AutoSize = true;
            this.subjectLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.subjectLabel.Location = new System.Drawing.Point(5, 20);
            this.subjectLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.subjectLabel.Name = "subjectLabel";
            this.subjectLabel.Size = new System.Drawing.Size(46, 13);
            this.subjectLabel.TabIndex = 8;
            this.subjectLabel.Text = "Subject:";
            // 
            // sendButton
            // 
            this.sendButton.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendButton.Location = new System.Drawing.Point(8, 273);
            this.sendButton.Margin = new System.Windows.Forms.Padding(2);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(390, 35);
            this.sendButton.TabIndex = 7;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.SendButtonClick);
            // 
            // textEmail
            // 
            this.textEmail.Location = new System.Drawing.Point(8, 75);
            this.textEmail.Margin = new System.Windows.Forms.Padding(2);
            this.textEmail.Multiline = true;
            this.textEmail.Name = "textEmail";
            this.textEmail.Size = new System.Drawing.Size(390, 194);
            this.textEmail.TabIndex = 6;
            // 
            // tabFindCar
            // 
            this.tabFindCar.Controls.Add(this.licensePlate);
            this.tabFindCar.Controls.Add(this.findPictureBox);
            this.tabFindCar.Controls.Add(this.findListView);
            this.tabFindCar.Controls.Add(this.inputText);
            this.tabFindCar.Controls.Add(this.search);
            this.tabFindCar.Location = new System.Drawing.Point(4, 22);
            this.tabFindCar.Name = "tabFindCar";
            this.tabFindCar.Padding = new System.Windows.Forms.Padding(3);
            this.tabFindCar.Size = new System.Drawing.Size(1083, 617);
            this.tabFindCar.TabIndex = 2;
            this.tabFindCar.Text = "Find Car";
            this.tabFindCar.UseVisualStyleBackColor = true;
            // 
            // licensePlate
            // 
            this.licensePlate.AutoSize = true;
            this.licensePlate.Location = new System.Drawing.Point(712, 13);
            this.licensePlate.Name = "licensePlate";
            this.licensePlate.Size = new System.Drawing.Size(73, 13);
            this.licensePlate.TabIndex = 9;
            this.licensePlate.Text = "License plate:";
            // 
            // findPictureBox
            // 
            this.findPictureBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.findPictureBox.Location = new System.Drawing.Point(6, 6);
            this.findPictureBox.Name = "findPictureBox";
            this.findPictureBox.Size = new System.Drawing.Size(703, 488);
            this.findPictureBox.TabIndex = 6;
            this.findPictureBox.TabStop = false;
            // 
            // findListView
            // 
            this.findListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnFind1,
            this.columnFind2,
            this.columnFind3,
            this.columnFind4});
            this.findListView.FullRowSelect = true;
            this.findListView.Location = new System.Drawing.Point(715, 67);
            this.findListView.Name = "findListView";
            this.findListView.Size = new System.Drawing.Size(350, 427);
            this.findListView.TabIndex = 8;
            this.findListView.UseCompatibleStateImageBehavior = false;
            this.findListView.SelectedIndexChanged += new System.EventHandler(this.FindListViewSelectedIndexChanged);
            // 
            // columnFind1
            // 
            this.columnFind1.Text = "ID";
            // 
            // columnFind2
            // 
            this.columnFind2.Text = "License Plate";
            this.columnFind2.Width = 120;
            // 
            // columnFind3
            // 
            this.columnFind3.Text = "Status";
            this.columnFind3.Width = 120;
            // 
            // columnFind4
            // 
            this.columnFind4.Text = "Date";
            this.columnFind4.Width = 150;
            // 
            // inputText
            // 
            this.inputText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.inputText.Location = new System.Drawing.Point(715, 29);
            this.inputText.Name = "inputText";
            this.inputText.Size = new System.Drawing.Size(269, 22);
            this.inputText.TabIndex = 7;
            // 
            // search
            // 
            this.search.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.search.Location = new System.Drawing.Point(990, 28);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(75, 23);
            this.search.TabIndex = 5;
            this.search.Text = "Search";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.SearchClick);
            // 
            // tabMyGallery
            // 
            this.tabMyGallery.Controls.Add(this.refreshButton);
            this.tabMyGallery.Controls.Add(this.galleryListView);
            this.tabMyGallery.Controls.Add(this.galleryPictureBox);
            this.tabMyGallery.Controls.Add(this.removeButton);
            this.tabMyGallery.Controls.Add(this.reportButton);
            this.tabMyGallery.Location = new System.Drawing.Point(4, 22);
            this.tabMyGallery.Name = "tabMyGallery";
            this.tabMyGallery.Padding = new System.Windows.Forms.Padding(3);
            this.tabMyGallery.Size = new System.Drawing.Size(1083, 617);
            this.tabMyGallery.TabIndex = 3;
            this.tabMyGallery.Text = "My Gallery";
            this.tabMyGallery.UseVisualStyleBackColor = true;
            // 
            // refreshButton
            // 
            this.refreshButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.refreshButton.Location = new System.Drawing.Point(715, 6);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(125, 23);
            this.refreshButton.TabIndex = 12;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.RefreshButtonClick);
            // 
            // galleryListView
            // 
            this.galleryListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column1,
            this.column2,
            this.column3,
            this.column4});
            this.galleryListView.FullRowSelect = true;
            this.galleryListView.Location = new System.Drawing.Point(715, 35);
            this.galleryListView.Name = "galleryListView";
            this.galleryListView.Size = new System.Drawing.Size(350, 434);
            this.galleryListView.TabIndex = 11;
            this.galleryListView.UseCompatibleStateImageBehavior = false;
            this.galleryListView.SelectedIndexChanged += new System.EventHandler(this.GalleryListViewSelectedIndexChanged);
            // 
            // column1
            // 
            this.column1.Tag = "ID";
            this.column1.Text = "ID";
            // 
            // column2
            // 
            this.column2.Tag = "License Plate";
            this.column2.Text = "License Plate";
            this.column2.Width = 120;
            // 
            // column3
            // 
            this.column3.Tag = "Status";
            this.column3.Text = "Status";
            this.column3.Width = 120;
            // 
            // column4
            // 
            this.column4.Tag = "Date";
            this.column4.Text = "Date";
            this.column4.Width = 150;
            // 
            // galleryPictureBox
            // 
            this.galleryPictureBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.galleryPictureBox.Location = new System.Drawing.Point(6, 6);
            this.galleryPictureBox.Name = "galleryPictureBox";
            this.galleryPictureBox.Size = new System.Drawing.Size(703, 488);
            this.galleryPictureBox.TabIndex = 10;
            this.galleryPictureBox.TabStop = false;
            // 
            // removeButton
            // 
            this.removeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.removeButton.Location = new System.Drawing.Point(809, 475);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(125, 23);
            this.removeButton.TabIndex = 9;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.RemoveButtonClick);
            // 
            // reportButton
            // 
            this.reportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.reportButton.Location = new System.Drawing.Point(940, 475);
            this.reportButton.Name = "reportButton";
            this.reportButton.Size = new System.Drawing.Size(125, 23);
            this.reportButton.TabIndex = 8;
            this.reportButton.Text = "Report";
            this.reportButton.UseVisualStyleBackColor = true;
            this.reportButton.Click += new System.EventHandler(this.ReportButtonClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 700);
            this.Controls.Add(this.tab);
            this.Controls.Add(this.exitButton);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormClosing);
            this.Load += new System.EventHandler(this.MainFormLoading);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.tab.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabMain.PerformLayout();
            this.tabReport.ResumeLayout(false);
            this.tabReport.PerformLayout();
            this.tabFindCar.ResumeLayout(false);
            this.tabFindCar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.findPictureBox)).EndInit();
            this.tabMyGallery.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.galleryPictureBox)).EndInit();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label cameraTopText;
        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage tabMain;
        private System.Windows.Forms.TabPage tabReport;
        private System.Windows.Forms.TabPage tabFindCar;
        private System.Windows.Forms.TabPage tabMyGallery;
        private System.Windows.Forms.TextBox subjectText;
        private System.Windows.Forms.Label subjectLabel;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.TextBox textEmail;
        private System.Windows.Forms.Label licensePlate;
        private System.Windows.Forms.PictureBox findPictureBox;
        private System.Windows.Forms.ListView findListView;
        private System.Windows.Forms.TextBox inputText;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.ListView galleryListView;
        private System.Windows.Forms.PictureBox galleryPictureBox;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button reportButton;
        private System.Windows.Forms.ColumnHeader column1;
        private System.Windows.Forms.ColumnHeader column2;
        private System.Windows.Forms.ColumnHeader column3;
        private System.Windows.Forms.ColumnHeader column4;
        private System.Windows.Forms.ColumnHeader columnFind1;
        private System.Windows.Forms.ColumnHeader columnFind2;
        private System.Windows.Forms.ColumnHeader columnFind3;
        private System.Windows.Forms.ColumnHeader columnFind4;
        private System.Windows.Forms.Button refreshButton;
    }
}

