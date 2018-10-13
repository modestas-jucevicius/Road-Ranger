using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Road_rangerVS.Image
{
    class Image
    {
        public int id { get; set; }
        public string licensePlate { get; set; }
        public long timestamp { get; set; }
        public byte[] image { get; set; }
    }
}
