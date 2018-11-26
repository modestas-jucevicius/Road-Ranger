namespace Models.Images
{
    public class ImageFactory
    {
        private static ImageFactory instance = null;

        public static ImageFactory GetInstance()
        {
            if (instance == null)
            {
                instance = new ImageFactory();
            }
            return instance;
        }

        private ImageFactory()
        {
        }

        public Image CreateImage(Image image)
        {
            return new Image
            {
                Id = image.Id,
                CarId = image.CarId,
                Timestamp = image.Timestamp,
                Picture = image.Picture
            };
        }

        public Image CreateImage(int id, int carId, long timestamp, byte[] picture)
        {
            return new Image
            {
                Id = id,
                CarId = carId,
                Timestamp = timestamp,
                Picture = picture
            };
        }

        public Image CreateImage(int id, int carId, long timestamp, string path)
        {
            return new Image
            {
                Id = id,
                CarId = carId,
                Timestamp = timestamp,
                Path = path
            };
        }
    }
}
