using Models.Images;
using System.Collections.Generic;
using System.Linq;

namespace Storage.Data.Images
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
            try
            {
                Image foundImage = MemoryRepository.images.Single(image => image.Id == id);
                return foundImage;
            }
            catch (System.InvalidOperationException)
            {
                return null;
            }
        }

        public int NewID()
        {
            Image lastImage = MemoryRepository.images.OrderBy(image => image.Id).Last();
            return ++lastImage.Id;
        }

        public void Put(Image obj)
        {
            MemoryRepository.images.Add(obj);
        }

        public void PutList(List<Image> obj)
        {
            MemoryRepository.images = (from image in obj
                                     select image).ToList();
        }

        public bool Remove(int id)
        {
            try
            {
                MemoryRepository.images.RemoveAll(image => image.Id == id);
                return true;
            }
            catch (System.InvalidOperationException)
            {
                return false;
            }
        }
    }
}
