﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AForge.Video;
using AForge.Video.DirectShow;

namespace Road_rangerVS
{
	public partial class Form1 : Form
	{
        private FilterInfoCollection VideoCaptureDevices;
        private VideoCaptureDevice FinalVideo;
		public Form1()
		{
			InitializeComponent();
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

        private void UploadButtonClick(object sender, EventArgs e)
        {
            string imagePath = filePath.Text;
			if (!File.Exists(imagePath))
			{
				MessageBox.Show("Wrong Image Path!");
			}
			else
			{
				Recognize(imagePath);
			}
        }

        // Analizuoja nuotrauką, esančią vietoje imagePath, ir parodo rezultatą konsolėje
        private async Task Recognize(string imagePath)
        {
            Recognizer recognizer = new OpenALPRRecognizer();
            string result = await recognizer.Recognize(imagePath);

            Parser parser = new OpenALPRParser();
			if (!parser.IsError(result))
			{
				List<ParsedCar> cars = parser.Parse(result);

				foreach (ParsedCar car in cars)
				{
					await car.Display();
				}

				if (cars.Count() == 0)
				{
					MessageBox.Show("Wrong Image!");
				}
			}
			else
			{
				MessageBox.Show("Wrong Image!");
			}
        }

        private void BrowseButtonClick(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files | *.png; *.jpg"; // failo tipai, kurie bus naudojami
            dialog.Multiselect = false; // true - galima pridėti daugiau negu viena failą, false - galima pridėti tik 1 failą
            if (dialog.ShowDialog() == DialogResult.OK) // jei vartotojas paspaudžia OK
            {
                String path = dialog.FileName; // gauna failo vardą
                filePath.Text = path;           // laukui filePath priskiriama path reikšmė
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            VideoCaptureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            foreach (FilterInfo VideoCaptureDevice in VideoCaptureDevices)
            {
                comboBox1.Items.Add(VideoCaptureDevice.Name);
            }

            comboBox1.SelectedIndex = 0;
            FinalVideo = new VideoCaptureDevice();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (FinalVideo.IsRunning == true) FinalVideo.Stop();

            FinalVideo = new VideoCaptureDevice(VideoCaptureDevices[comboBox1.SelectedIndex].MonikerString);
            FinalVideo.NewFrame += FinalVideo_NewFrame;
            FinalVideo.Start();
        }

        private void FinalVideo_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap video = (Bitmap)eventArgs.Frame.Clone();
            pictureBox2.Image = video;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (FinalVideo.IsRunning == true) FinalVideo.Stop();
        }
    }
}
