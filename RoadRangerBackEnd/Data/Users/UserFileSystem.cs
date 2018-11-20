using System;
using System.Collections.Generic;
using System.IO;
using RoadRangerBackEnd.Users;
using RoadRangerBackEnd.Authorization;

namespace RoadRangerBackEnd.Data
{
    public class UserFileSystem : IUserData
    {
		private static UserFileSystem instance;
		private PrimitiveFileSystem primitiveFileSystem = new PrimitiveFileSystem();
        private FileSystemIndexer indexer = new FileSystemIndexer();
        private readonly string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\Storage\Users.txt";
		private UserFileSystem() { }

		public static UserFileSystem GetInstance()
		{
			if (instance == null)
			{
				return instance = new UserFileSystem();
			}
			else
			{
				return instance;
			}
		}

        public List<User> GetAll()
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
            if (strings.Count != 0)
            { 
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
            File.AppendAllText(path, obj.ToString() + Environment.NewLine);
        }

        public void PutList(List<User> objects)
        {
            foreach (User obj in objects)
            {
                Put(obj);
            }
        }

        public bool Update(User user)
        {
			string strOldText;
            string[] fields = null;
            string fileData = "";
            bool found = false;
            StreamReader sr = File.OpenText(path);
            while ((strOldText = sr.ReadLine()) != null)
            {
                fields = strOldText.Split(',');
                int ID = Int32.Parse(fields[0]);
                if (ID == user.Id)
                {
                    found = true;
                    fileData += user.ToString() + Environment.NewLine;
                }
                else { fileData += strOldText + Environment.NewLine; }
            }
            sr.Close();
            File.WriteAllText(path, fileData);
            return found;
        }

        private string UserToCSVFormat(User user)
        {
            return user.Id + "," + user.Username + "," + user.Score + Environment.NewLine;
        }

        private User GetUserFromStringArray(String[] array)
        {
			User user = new User(Int32.Parse(array[0]), array[1], array[2]);
			user.Score = Int32.Parse(array[3]);
			user.setBoost30p(array[4] == "True");
			user.setBoost50p(array[5] == "True");
			user.setBoostDouble(array[6] == "True");
			return user;
        }
    }
}