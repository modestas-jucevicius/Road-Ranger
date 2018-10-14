using Newtonsoft.Json;
using Road_rangerVS.OutsideAPI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Road_rangerVS.Data
{
    public class FileSystem<T> : IData<T>
    {
        private string path;

        public FileSystem(int type)
        {
            if (type == 0)
            {
                path = System.Environment.CurrentDirectory + "/Users.txt";
            }
            else if (type == 1)
            {
                path = System.Environment.CurrentDirectory + "/Cars.txt";
            }
            else if (type == 2)
            {
                path = System.Environment.CurrentDirectory + "/Scoreboard.txt";
            }
            else
                path = System.Environment.CurrentDirectory + "/Images.txt";
        }

        //Sukuriamo failo location: RoadRanger/bin/Debug/Data.txt

        public void Put(T obj)
        {
            string stolen = obj.ToString();
            Console.WriteLine(stolen);
            string objSer = JsonConvert.SerializeObject(obj); // convert obj -> JSON format
            Console.WriteLine("Obj: " + objSer);
            File.AppendAllText(path, stolen);
        }

        public void PutList(List<T> obj)
        {

        }

        public bool Contains(T obj)
        {
            return false;
        }

        public List<T> FindAll()
        {
            return null;
        }

        public T FindOne()
        {
            throw new NotImplementedException();
        }

        public T FindById(int id)
        {
            throw new NotImplementedException();
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
