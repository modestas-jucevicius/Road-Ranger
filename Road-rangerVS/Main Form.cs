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
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

        private void UploadButtonClick(object sender, EventArgs e)
        {
            string imagePath = filePath.Text;
            if (!File.Exists(imagePath))
                MessageBox.Show("Wrong Image Path!");
            else
                Recognize(imagePath);
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
                    car.Display();
                }

                if (cars.Count() == 0)
                    MessageBox.Show("Wrong Image!");
            }
            else
                MessageBox.Show("Wrong Image!");
        }

        private void BrowseButtonClick(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files | *.png; *.jpg"; // file types, that will be allowed to upload
            dialog.Multiselect = false; // allow/deny user to upload more than one file at a time
            if (dialog.ShowDialog() == DialogResult.OK) // if user clicked OK
            {
                String path = dialog.FileName; // get name of file
                filePath.Text = path;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
