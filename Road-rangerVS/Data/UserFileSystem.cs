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
        private string path = System.Environment.CurrentDirectory + "/Storage/Users.txt";
        private PrimitiveFileSystem primitiveFileSystem = new PrimitiveFileSystem();
        private FileSystemIndexer indexer = new FileSystemIndexer();
        public List<User> FindAll()
        {
            List<User> list = new List<User>();
            List<String> strings = primitiveFileSystem.GetLines(path);

            string[] fields = null;
            foreach (string line in strings)
            {
                fields = line.Split(',');
                list.Add(new User(fields));
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
                return new User(fields);
            }
        }

        public void Put(User obj)
        {
            obj.id = indexer.GetLastId(path) + 1;
            File.AppendAllText(path, obj.ToString());
        }

        public void PutList(List<User> objects)
        {
            foreach (User obj in objects)
            {
                Put(obj);
            }
        }

        public User Update(int id, User obj)
        {
            throw new NotImplementedException();
        }
    }
}
