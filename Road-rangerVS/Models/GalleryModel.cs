using RoadRangerBackEnd.Data;

namespace Road_rangerVS.Models
{
	class GalleryModel
	{
		private readonly CapturedCarService service = new CapturedCarService();
        private readonly ICarData carData = new CarFileSystem();
        private readonly IImageData imageData = new ImageFileSystem();
        public CapturedCarService GetCarFinder()
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
