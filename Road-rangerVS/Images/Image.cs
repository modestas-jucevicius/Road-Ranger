using System;
using System.Text;

namespace Road_rangerVS.Images
{
    public class Image
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public long Timestamp { get; set; }
        public string Path { get; set; }

        public Image(int carId, long timestamp, string path)
        {
            this.CarId = carId;
            this.Timestamp = timestamp;
            this.Path = path;
        }

        public Image(int id, int carId, long timestamp, string path) : this(carId, timestamp, path)
        {
            this.Id = id;
        }

    }
}
