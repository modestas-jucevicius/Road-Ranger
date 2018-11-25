using Models.Images;
using System.Collections.Generic;

namespace Storage.Data
{
    public interface IImageData
    {
        void Put(Image obj);
        void PutList(List<Image> obj);
        List<Image> FindAll();
        Image FindById(int id);
        bool Remove(int id);
    }
}
