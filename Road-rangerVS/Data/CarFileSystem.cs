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

        public Car Update(int id, Car obj)
        {
            throw new NotImplementedException();
        }
    }
}
