using System;
using System.Collections.Generic;
using System.IO;

namespace Storage.Data
{
    public class PrimitiveFileSystem
    {
        public List<String> GetLines(string path) //Grąžins null, jei failo nėra arba jis tuščias
        {
            List<String> stringLines = new List<string>();
            String line;
            if (File.Exists(path))
            {
                StreamReader stream = new StreamReader(path);
                while (!stream.EndOfStream)
                {
                    line = stream.ReadLine();
                    stringLines.Add(line);
                }
                stream.Close();
                return stringLines;
            }
            else
            {
                throw new FileException("File doesn't exist.");
            }
        }
    }

    class FileException : Exception
    {
        public FileException(string message) : base(message)
        {
        }
    }
}
