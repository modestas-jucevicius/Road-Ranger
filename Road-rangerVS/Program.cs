using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;
using System.Net.Http;
using System.Diagnostics;

namespace Road_rangerVS
{
	static class Program
	{

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
		static  void Main()
		{
            RecognitionTest();

            Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
        }

        static async Task RecognitionTest()
        {
            string imagePath = "vilnius-zeneva-su-volvo-xc60-5314ead086571.jpg";
            imagePath = Path.Combine(Environment.CurrentDirectory, @"images\", imagePath);
            Console.WriteLine("Full Path: {0}", imagePath);

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
            }
            else
                Console.WriteLine("Error message!");
            
        }
    }
}
