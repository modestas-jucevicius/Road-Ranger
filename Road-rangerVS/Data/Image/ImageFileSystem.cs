using System;
using System.Collections.Generic;
using System.IO;
using Road_rangerVS.Images;

namespace Road_rangerVS.Data
{
    class ImageFileSystem : IImageData
    {
        private PrimitiveFileSystem primitiveFileSystem = new PrimitiveFileSystem();
        private FileSystemIndexer indexer = new FileSystemIndexer();
        private string path = System.Environment.CurrentDirectory + @"\Storage\Images.txt";
        public List<Image> FindAll()
        {
            List<Image> list = new List<Image>();
            List<String> strings = primitiveFileSystem.GetLines(path);

            string[] fields = null;
                
            foreach (string line in strings)
            {
                fields = line.Split(',');
                list.Add(GetImageFromStringArray(fields));
            }
            return list;
        }

        public Image FindById(int id)
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
            if (rado == false) { return default(Image); }
            else
            {
                return GetImageFromStringArray(fields);
            }
        }

        public void Put(Image obj)
        {
            obj.Id = indexer.GetLastId(path) + 1;
            File.AppendAllText(path, ImageToCSVFormat(obj));
        }

        public void PutList(List<Image> objects)
        {
            foreach (Image obj in objects)
            {
                this.Put(obj);
            }
        }
        public bool Remove(int id)
        {
            Image image = this.FindById(id);
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
            //File.Delete(image.path);
            return found;
        }

        private string ImageToCSVFormat(Image image)
        {
            return image.Id + "," + image.CarId + "," + image.Timestamp +
                "," + image.Path + Environment.NewLine;
        }

        private Image GetImageFromStringArray(String[] array)
        {
            return new Image(Int32.Parse(array[0]), Int32.Parse(array[1]),
                        long.Parse(array[2]), array[3]);
        }
    }
}
