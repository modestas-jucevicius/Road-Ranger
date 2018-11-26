﻿using Models.Cars;
using System;
using System.Collections.Generic;
using System.IO;

namespace Storage.Data.Cars
{
    public class CarFileSystem : ICarData
    {
        private PrimitiveFileSystem primitiveFileSystem = new PrimitiveFileSystem();
        private FileSystemIndexer indexer = new FileSystemIndexer();
        private readonly string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\Storage\Cars.txt";
        public List<Car> FindAll()
        {
            List<Car> list = new List<Car>();
            List<String> strings = primitiveFileSystem.GetLines(path);
            string[] fields = null;

            foreach (string line in strings)
            {
                fields = line.Split(',');
                Car car = GetCarFromStringArray(fields);
                list.Add(car);
            }
            return list;
        }

        public Car FindById(int id)
        {
            List<String> strings = primitiveFileSystem.GetLines(path);

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
                return GetCarFromStringArray(fields);
            }
        }

        public void Put(Car obj)
        {
            obj.Id = indexer.GetLastId(path) + 1;
            File.AppendAllText(path, CarToCSVFormat(obj));
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
                if (strID.Equals(strOldText[0].ToString()))
                {
                    found = true;
                    fileData += CarToCSVFormat(obj) + Environment.NewLine;
                }
                else
                {
                    fileData += strOldText + Environment.NewLine;
                }
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
                if (strID.Equals(strOldText[0].ToString()))
                {
                    found = true;
                }
                else
                {
                    fileData += strOldText + Environment.NewLine;
                }
            }
            sr.Close();
            File.WriteAllText(path, fileData);
            return found;
        }

        private string CarToCSVFormat(Car car)
        {
            return car.Id + "," + car.UserId + "," + car.LicensePlate + "," + car.ColorName +
                 "," + car.MakeName + "," + car.Model + "," + car.BodyType + "," + car.Year + "," + car.IsReported +
                 "," + car.Status + Environment.NewLine;
        }

        private Car GetCarFromStringArray(string[] array)
        {
            return CarFactory.GetInstance().CreateCar(Int32.Parse(array[0]), Int32.Parse(array[1]), array[2],
                array[3], array[4], array[5],
                array[6], array[7], (CarStatus)Enum.Parse(typeof(CarStatus), array[9]), Convert.ToBoolean(array[8]));
        } 
    }
}