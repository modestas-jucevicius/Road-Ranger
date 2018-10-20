using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Road_rangerVS.Users;

namespace Road_rangerVS.Data
{
    class UserFileSystem : IUserData
    {
        private PrimitiveFileSystem primitiveFileSystem = new PrimitiveFileSystem();
        private FileSystemIndexer indexer = new FileSystemIndexer();
        private string path = System.Environment.CurrentDirectory + @"\Storage\Users.txt";
        public List<User> FindAll()
        {
            List<User> list = new List<User>();
            List<String> strings = primitiveFileSystem.GetLines(path);

            string[] fields = null;
            foreach (string line in strings)
            {
                fields = line.Split(',');
                list.Add(GetUserFromStringArray(fields));
            }
            return list;
        }

        public User FindById(int id)
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
            if (rado == false) { return default(User); }
            else
            {
                return GetUserFromStringArray(fields);
            }
        }

        public void Put(User obj)
        {
            obj.Id = indexer.GetLastId(path) + 1;
            File.AppendAllText(path, obj.ToString());
        }

        public void PutList(List<User> objects)
        {
            foreach (User obj in objects)
            {
                Put(obj);
            }
        }

        public bool Update(int id, User obj)
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

        private string UserToCSVFormat(User user)
        {
            return user.Id + "," + user.Username + "," + user.Name + "," + user.GetScore() + Environment.NewLine;
        }

        private User GetUserFromStringArray(String[] array)
        {
            return new User(Int32.Parse(array[0]), array[1], array[2], array[3], Int32.Parse(array[4]));
        }
    }
}