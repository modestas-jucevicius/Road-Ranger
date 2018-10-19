using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Road_rangerVS.Recognition;

namespace Road_rangerVS.Data
{
    class CarFileSystem : ICarData
    {
        private PrimitiveFileSystem PrimitiveFileSystem = new PrimitiveFileSystem();
        private FileSystemIndexer indexer = new FileSystemIndexer();
        private string path = System.Environment.CurrentDirectory + "/Storage/Cars.txt";
        public List<Car> FindAll()
        {
            List<Car> list = new List<Car>();
            List<String> strings = PrimitiveFileSystem.GetLines(path);
            string[] fields = null;
               
            foreach (string line in strings)
            {
                fields = line.Split(',');
                Car car = new Car(fields);
                list.Add(car);
            }
            return list;
        }

        public Car FindById(int id)
        {
            List<String> strings = PrimitiveFileSystem.GetLines(path);

            string[] fields = null;
            bool rado = false;
            foreach (string line in strings)
            {
                fields = line.Split(',');
                int ID = Int32.Parse(fields[0]);
                if (ID == id)
                {
                    rado = true;
                    break;
                }
            }
            if (rado == false)
            {
                return default(Car);
            }
            else
            {
                return new Car(fields);
            }
        }

        public void Put(Car obj)
        {
            obj.id = indexer.GetLastId(path) + 1;
            File.AppendAllText(path, obj.ToString());
        }

        public void PutList(List<Car> objects)
        {
            foreach (Car obj in objects)
            {
                this.Put(obj);
            }
        }

        public bool Update(int id, Car obj)
        {
            string strID = id.ToString();
            string strOldText;
            string fileData = "";
            bool found = false;
            StreamReader sr = File.OpenText(path);
            while ((strOldText = sr.ReadLine()) != null)
            {
                if (String.Equals(strOldText[0], strID))
                {
                    found = true;
                    fileData += obj.ToString() + Environment.NewLine;
                }
                else { fileData += strOldText + Environment.NewLine; }
            }
            sr.Close();
            File.WriteAllText(path, fileData);
            return found;
        }

        public bool Remove(int id)
        {
            string strID = id.ToString();
            string strOldText;
            string fileData = "";
            bool found = false;
            StreamReader sr = File.OpenText(path);
            while ((strOldText = sr.ReadLine()) != null)
            {
                if (String.Equals(strOldText[0], strID)) { found = true; }
                else{ fileData += strOldText + Environment.NewLine;}
            }
            sr.Close();
            File.WriteAllText(path, fileData);
            return found;
        }
    }
}
