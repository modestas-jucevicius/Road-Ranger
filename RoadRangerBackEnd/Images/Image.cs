
namespace RoadRangerBackEnd.Images
{
    public class Image
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public long Timestamp { get; set; }
        public string Path { get; set; }
        public byte[] Picture { get; set; }

        public Image(int carId, long timestamp, string path)
        {
            this.CarId = carId;
            this.Timestamp = timestamp;
            this.Path = path;
        }

        public Image(int carId, long timestamp, byte[] picture)
        {
            this.CarId = carId;
            this.Timestamp = timestamp;
            this.Picture = picture;
        }

        public Image(int id, int carId, long timestamp, string path) : this(carId, timestamp, path)
        {
            this.Id = id;
        }

        public Image(int id, int carId, long timestamp, byte[] picture) : this(carId, timestamp, picture)
        {
            this.Id = id;
        }
    }
}
