
using RoadRangerBackEnd.Data;
using RoadRangerBackEnd.Search;

namespace Road_rangerVS.Models
{
	class GalleryModel
	{
		private readonly ICapturedCarFinder finder = new CapturedCarFinder();
        private readonly ICarData carData = new CarFileSystem();
        private readonly IImageData imageData = new ImageFileSystem();
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
