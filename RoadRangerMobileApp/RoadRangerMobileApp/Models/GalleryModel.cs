using RoadRangerBackEnd.Data;
using RoadRangerBackEnd.Data.Cars;
using RoadRangerBackEnd.Data.Images;

namespace Road_rangerVS.Models
{
	public class GalleryModel
	{
		private readonly CapturedCarService service = new CapturedCarService();
        private readonly ICarData carData = new CarMemoryData();
        private readonly IImageData imageData = new ImageMemoryData();

        public CapturedCarService GetCarService()
		{
			return this.service;
		}

        public bool RemoveCarById(int id)
        {
            return this.carData.Remove(id);
        }

        public bool RemoveImageById(int id)
        {
            return this.imageData.Remove(id);
        }
    }
}
