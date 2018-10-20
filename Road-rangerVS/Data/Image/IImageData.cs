
using System.Collections.Generic;
using Road_rangerVS.Images;

namespace Road_rangerVS.Data
{
    interface IImageData
    {
        void Put(Image obj);
        void PutList(List<Image> obj);
        List<Image> FindAll();
        Image FindById(int id);
        bool Remove(int id);
    }
}
