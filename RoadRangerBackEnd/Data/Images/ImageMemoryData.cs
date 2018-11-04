using System.Collections.Generic;
using RoadRangerBackEnd.Images;

namespace RoadRangerBackEnd.Data.Images
{
    public class ImageMemoryData : IImageData
    {
        private static MemoryRepository repository = MemoryRepository.GetInstance();

        public List<Image> FindAll()
        {
            return MemoryRepository.images;
        }

        public Image FindById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Put(Image obj)
        {
            throw new System.NotImplementedException();
        }

        public void PutList(List<Image> obj)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
