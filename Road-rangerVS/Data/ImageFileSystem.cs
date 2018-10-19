﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Road_rangerVS.Images;

namespace Road_rangerVS.Data
{
    class ImageFileSystem : IImageData
    {
        private string path = System.Environment.CurrentDirectory + "/Storage/Images.txt";
        private PrimitiveFileSystem primitiveFileSystem = new PrimitiveFileSystem();
        private FileSystemIndexer indexer = new FileSystemIndexer();
        public List<Image> FindAll()
        {
            List<Image> list = new List<Image>();
            List<String> strings = primitiveFileSystem.GetLines(path);

            string[] fields = null;
                
            foreach (string line in strings)
            {
                fields = line.Split(',');
                list.Add(new Image(fields));
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
                return new Image(fields);
            }
        }

        public void Put(Image obj)
        {
            obj.id = indexer.GetLastId(path) + 1;
            File.AppendAllText(path, obj.ToString());
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
            string strID = id.ToString();
            string strOldText;
            string fileData = "";
            bool found = false;
            StreamReader sr = File.OpenText(path);
            while ((strOldText = sr.ReadLine()) != null)
            {
                if (String.Equals(strOldText[0], strID)) { found = true; }
                else { fileData += strOldText + Environment.NewLine; }
            }
            sr.Close();
            File.WriteAllText(path, fileData);
            String imagePath = System.Environment.CurrentDirectory + "/Images/" + id + ".jpg";
            if (File.Exists(imagePath)) { File.Delete(imagePath); }
            return found;
        }
    }
}
