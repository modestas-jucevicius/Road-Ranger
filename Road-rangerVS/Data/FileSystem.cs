using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Road_rangerVS.Data
{
    class FileSystem : IData
    {
        private static string path = System.Environment.CurrentDirectory + "/Data.txt";
        //Sukuriamo failo location: RoadRanger/bin/Debug/Data.txt

        public void putData(ParsedCar parsedCar, bool state)
        {
            if (state)
            {
                string stolen = parsedCar.getID() + ". STOLEN" + DateTime.UtcNow.ToString()
                + " " + parsedCar.registrationNumber + " " + parsedCar.makeModel + " "
                + parsedCar.model + Environment.NewLine; 
                File.AppendAllText(path,stolen);
            }
            else
            {
                string notStolen = parsedCar.getID() +". NOT STOLEN " + DateTime.UtcNow.ToString()
                    +  " " + parsedCar.registrationNumber + " " + parsedCar.makeModel + " "
                + parsedCar.model + Environment.NewLine;
                File.AppendAllText(path, notStolen);
            }
        }
       /* public void closeFile()
        {
            file.Close();
        }
        public void openFile()
        {
            file = new StreamWriter("C://Users//pjach//Documents//Road-Ranger//Road-rangerVS//Data.txt");
        }
        */
    }
}
