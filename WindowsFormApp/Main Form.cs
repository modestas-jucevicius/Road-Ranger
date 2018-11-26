﻿using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using AForge.Video;
using System.Collections.Generic;
using WindowsFormApp.Views;
using WindowsFormApp.Presenters;
using Services.Validation;
//using Storage.Data;
using Models.Cars;
using Services.Statistic.Statistics;
using Services.Statistic;
using Models.Images;

namespace WindowsFormApp
{
	public partial class MainForm : Form, IMainView, IReportView, ISearchView, IGalleryView
    {
		private MainPresenter mainPresenter;
        private ReportPresenter reportPresenter;
        private FindPresenter findPresenter;
        private GalleryPresenter galleryPresenter;
        private int id = 0;

        public MainForm()
        {
            InitializeComponent();
            mainPresenter = new MainPresenter(scoreLabel);
            reportPresenter = new ReportPresenter();
            findPresenter = new FindPresenter();
            galleryPresenter = new GalleryPresenter(id);
            this.findListView.View = View.Details;
            this.galleryListView.View = View.Details;
        }

        public string Path
        {
            get
            {
                return filePath.Text;
            }
            set
            {
                filePath.Text = value;
            }
        }

        public System.Drawing.Image Frame
        {
            get
            {
                return pictureBox.Image;
            }
            set
            {
                pictureBox.Image = value;
            }
        }

        public string Subject
        {
            get
            {
                return subjectText.Text;
            }
            set
            {
                subjectText.Text = value;
            }
        }

        public string Message
        {
            get
            {
                return textEmail.Text;
            }
            set
            {
                textEmail.Text = value;
            }
        }

        string ISearchView.LicensePlate
        {
            get
            {
                return inputText.Text;
            }
            set
            {
                inputText.Text = value;
            }
        }

        Bitmap ISearchView.Image
        {
            get
            {
                return new Bitmap(findPictureBox.Image);
            }
            set
            {
                findPictureBox.Image = value;
                findPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        public ListViewItem FoundCar
        {
            get
            {
                return new ListViewItem();
            }
            set
            {
                this.findListView.Items.Add(value);
            }
        }

        Bitmap IGalleryView.Image
        {
            get
            {
                return new Bitmap(galleryPictureBox.Image);
            }
            set
            {
                galleryPictureBox.Image = value;
                galleryPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        public ListViewItem Car
        {
            get
            {
                return new ListViewItem();
            }
            set
            {
                this.galleryListView.Items.Add(value);
            }
        }

        public bool EnableReport
        {
            get
            {
                return reportButton.Enabled;
            }
            set
            {
                reportButton.Enabled = value;
            }
        }

        private async void UploadButtonClick(object sender, EventArgs e)
        {
			if (!File.Exists(filePath.Text))
			{
				MessageBox.Show("Wrong Image Path!");
			}
			else
			{
				await mainPresenter.GetCarInfo(filePath.Text);
			}
        }

        private void BrowseButtonClick(object sender, EventArgs e)
        {
            this.mainPresenter.Browse(this);
        }

        private void MainFormLoading(object sender, EventArgs e)
        {
			//comboBox1.Items.AddRange(mainPresenter.LoadDevices().ToArray());
			//comboBox1.SelectedIndex = 0; // By default pasirinktas bus pirmas objektas comboBox'e
		}

        private void SelectCamera(object sender, EventArgs e)
        {

        }

        private void CameraClick(object sender, EventArgs e)
        {
            this.mainPresenter.CameraClick(comboBox1.SelectedIndex, NewFrame);
		}

		private void NewFrame(object sender, NewFrameEventArgs eventArgs)
		{
			mainPresenter.NewFrame(this, eventArgs);
		}

		private void CaptureClick(object sender, EventArgs e)
        {

            this.mainPresenter.SaveFrameImage(this);
        }

        private void MainFormClosing(object sender, FormClosingEventArgs e)
        {
            mainPresenter.CloseForm(); //Išjungus programą išsijungs ir kamera.
        }

        private void ExitButtonClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SendButtonClick(object sender, EventArgs e)
        {
            this.reportPresenter.SendMail(this);
        }

        private void SearchClick(object sender, EventArgs e)
        {
            ITextValidator validator = new LicensePlateValidator();
            if (validator.IsValid(inputText.Text))
            {
                this.findListView.Items.Clear();
                findPresenter.Search(this);
            }
            else
            {
                MessageBox.Show("Car license plate is not valid! License plate should be AAA000 or AA000 format.");
            }
        }

        private void RemoveButtonClick(object sender, EventArgs e)
        {
            try
            {
                int id = Int32.Parse(galleryListView.SelectedItems[0].SubItems[0].Text);
                this.ShowRemoveMessage(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ShowRemoveMessage(int id)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to remove car?", "Remove message", MessageBoxButtons.YesNo);
            if (result.Equals(DialogResult.Yes))
            {
                this.galleryListView.Items.Clear();
                this.galleryPresenter.RemoveByIndex(this, id);
            }
        }

        private void ReportButtonClick(object sender, EventArgs e)
        {
            try
            {
                int id = Int32.Parse(galleryListView.SelectedItems[0].SubItems[0].Text);
                ShowReportMessage(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ShowReportMessage(int id)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to report car?", "Report message", MessageBoxButtons.YesNo);
            if (result.Equals(DialogResult.Yes))
            {
                this.galleryPresenter.ReportByIndex(this, id);
            }
        }

        private void GalleryListViewSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int id = Int32.Parse(galleryListView.SelectedItems[0].SubItems[0].Text);
                this.galleryPresenter.SelectByIndex(this, id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void FindListViewSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int id = Int32.Parse(findListView.SelectedItems[0].SubItems[0].Text);
                this.findPresenter.SelectByIndex(this, id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void RefreshButtonClick(object sender, EventArgs e)
        {
            this.galleryListView.Items.Clear();
            this.galleryPresenter.ShowGallery(this);
        }
    }
}