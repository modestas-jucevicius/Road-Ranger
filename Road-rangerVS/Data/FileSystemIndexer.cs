using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Road_rangerVS.Data
{
    class FileSystemIndexer
    {
        private static PrimitiveFileSystem primitiveFileSystem = new PrimitiveFileSystem();
        public int GetLastId(string path)
        {
            int lastId = 0;
            List<String> strings = primitiveFileSystem.GetLines(path);
            string[] fields = null;
            foreach (string line in strings)
            {
                fields = line.Split(',');
                int id = Int32.Parse(fields[0]);
                if (lastId < id)
                    lastId = id;
            }
            return lastId;
        }
    }
}
