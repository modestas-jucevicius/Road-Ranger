using Newtonsoft.Json;
using Road_rangerVS.OutsideAPI;
using Road_rangerVS.Recognition;
using Road_rangerVS.Images;
using Road_rangerVS.Users;
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
        public int type;

        public FileSystem(int type)
        {
            this.type = type;
            if (type == 0)
            {
                path = System.Environment.CurrentDirectory + "/Users.txt";
            }
            else if (type == 1)
            {
                path = System.Environment.CurrentDirectory + "/Cars.txt";
            }
            else
                path = System.Environment.CurrentDirectory + "/Images.txt";
        }

        //Sukuriamo failo location: RoadRanger/bin/Debug

        public void Put(T obj)
        {
            if(obj is Car) {File.AppendAllText(path, obj.ToString());}
            else if (obj is User) {File.AppendAllText(path, obj.ToString());}
            else { File.AppendAllText(path, obj.ToString());}
        }
        public void PutList(List<T> objects)
        {
            foreach(T obj in objects) { Put(obj); }
        }
        public List<T> FindAll() //Grąžins null, jei failo nėra arba jis tuščias
        {
            List<T> list = new List<T>();
            List<String> strings = getLines();
            if(strings == null) { return null; } 
            else
            {
                string[] fields = null;
                if (type == 0)
                {
                    foreach (string line in strings)
                    {
                        fields = line.Split(',');
                        User user = new User(fields);
                        list.Add((T)Convert.ChangeType(user, typeof(T)));
                    }
                    return list;
                }
                else if (type == 1)
                {
                    foreach (string line in strings)
                    {
                        fields = line.Split(',');
                        Car car = new Car(fields);
                        list.Add((T)Convert.ChangeType(car, typeof(T)));
                    }
                    return list;
                }
                else
                {
                    foreach (string line in strings)
                    {
                        fields = line.Split(',');
                        Image image = new Image(fields);
                        list.Add((T)Convert.ChangeType(image, typeof(T)));
                    }
                    return list;
                }
            }
            
        }

        public T FindById(int id) //Grąžins null, jei nepavyko rast
        {
            List<String> strings = getLines();
            if (strings == null) { return default(T); }
            else
            {
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
                if (rado == false) { return default(T); }
                else
                {
                    if (type == 0)
                    {
                        User user = new User(fields);
                        return (T)Convert.ChangeType(user, typeof(T));
                    }
                    else if (type == 1)
                    {
                        Car car = new Car(fields);
                        return (T)Convert.ChangeType(car, typeof(T));
                    }
                    else
                    {
                        Image image = new Image(fields);
                        return (T)Convert.ChangeType(image, typeof(T));
                    }
                }

            }
        }
        public List<String> getLines() //Grąžins null, jei failo nėra arba jis tuščias
        {
            List<String> stringLines = new List<string>();
            String line;
            if (File.Exists(path) && new FileInfo(path).Length > 0)
            {
                StreamReader stream = new StreamReader(path);
                while (!stream.EndOfStream)
                {
                    line = stream.ReadLine();
                    stringLines.Add(line);
                }
                return stringLines;
            }
            else return null;
            
        }
    }
}
