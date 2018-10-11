using Road_rangerVS.OutsideAPI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Road_rangerVS.Data
{
    class FileSystem<T> : IData<T>
    {
        private static string path = System.Environment.CurrentDirectory + "/Data.txt";

        public List<T> FindAll()
        {
            throw new NotImplementedException();
        }

        public T FindOne()
        {
            throw new NotImplementedException();
        }

        //Sukuriamo failo location: RoadRanger/bin/Debug/Data.txt

        public void Put(T obj)
        {
            string stolen = obj.ToString(); // convert obj -> JSON format
            Console.WriteLine(stolen);
            File.AppendAllText(path, stolen);
        }

        public void PutList(T obj)
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
