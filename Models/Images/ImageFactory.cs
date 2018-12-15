using Xamarin.Forms.Maps;

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

        public Image CreateImage(string id, string carId, long timestamp, string path, Position pos)
        {
            return new Image
            {
                Id = id,
                CarId = carId,
                Timestamp = timestamp,
                Path = path,
                Position = pos
            };
        }
    }
}
