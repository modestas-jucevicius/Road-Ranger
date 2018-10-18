﻿using System;
using System.Text;

namespace Road_rangerVS.Images
{
    public class Image
    {
        public int id { get; set; }
        public int carId { get; set; }
        public long timestamp { get; set; }
        public string path { get; set; }

        public Image(int carId, long timestamp, string path)
        {
            this.carId = carId;
            this.timestamp = timestamp;
            this.path = path;
        }

        public Image(String[] fields)
        {
            id = Int32.Parse(fields[0]);
            carId = Int32.Parse(fields[1]);
            timestamp = long.Parse(fields[2]);
            path = fields[3];
        }
        override public string ToString()
        {
            string line = id + "," + carId + "," + timestamp +
                "," + path + Environment.NewLine; 
            return line;
        }
    }
}
