using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Road_rangerVS.Images
{
    public class Image
    {
        public int id { get; set; }
        public string licensePlate { get; set; }
        public long timestamp { get; set; }
        public byte[] image { get; set; }

        public Image(String[] fields)
        {
            id = Int32.Parse(fields[0]);
            licensePlate = fields[1];
            timestamp = long.Parse(fields[2]);
            image = Encoding.ASCII.GetBytes(fields[3]);
        }
        override public string ToString()
        {
            string line = id + "," + licensePlate + "," + timestamp +
                "," + image + Environment.NewLine;
            return line;
        }
    }
}
