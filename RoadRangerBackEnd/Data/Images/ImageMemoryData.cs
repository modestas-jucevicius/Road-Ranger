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
            foreach(Image image in MemoryRepository.images)
            {
                if (image.Id == id) { return image; }
            }
            return null;
        }

        public int NewID()
        {
            int Id = MemoryRepository.images[0].Id;
            foreach(Image image in MemoryRepository.images)
            {
                if(image.Id >= Id) { Id = image.Id; }
            }
            return ++Id;
        }

        public void Put(Image obj)
        {
            MemoryRepository.images.Add(obj);
        }

        public void PutList(List<Image> obj)
        {
            foreach(Image image in obj) { MemoryRepository.images.Add(image); }
        }

        public bool Remove(int id)
        {
            foreach(Image image in MemoryRepository.images)
            {
                if(image.Id == id)
                {
                    MemoryRepository.images.Remove(image);
                    return true;
                }
            }
            return false;
        }
    }
}
