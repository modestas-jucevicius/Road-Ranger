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
