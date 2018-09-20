using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Road_rangerVS
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
            browseImage.Visible = false;
            upload.Visible = false;
            returnButton.Visible = false;
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

        private void imageRecognition_Click(object sender, EventArgs e)
        {
            browseImage.Visible = true;
            upload.Visible = true;              //Atidaro nuotraukos įkėlimo meniu skiltį
            returnButton.Visible = true;
            videoButton.Visible = false;

        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            browseImage.Visible = false;
            upload.Visible = false;
            returnButton.Visible = false;  //Grįžta į meniu; paslepia iššokusius mygtukus
            videoButton.Visible = true;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();      //Uždaro programą
        }
    }
}
