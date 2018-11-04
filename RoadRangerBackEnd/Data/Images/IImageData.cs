
using System.Collections.Generic;
using RoadRangerBackEnd.Images;

namespace RoadRangerBackEnd.Data
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
