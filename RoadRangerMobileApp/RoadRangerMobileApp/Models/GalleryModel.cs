
using RoadRangerBackEnd.Data;
using RoadRangerBackEnd.Data.Cars;
using RoadRangerBackEnd.Data.Images;
using RoadRangerBackEnd.Search;

namespace Road_rangerVS.Models
{
	public class GalleryModel
	{
		private readonly ICapturedCarFinder finder = new CapturedCarFinder();
        private readonly ICarData carData = new CarMemoryData();
        private readonly IImageData imageData = new ImageMemoryData();
        public ICapturedCarFinder GetFinder()
		{
			return this.finder;
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
