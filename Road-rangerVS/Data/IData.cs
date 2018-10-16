using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Road_rangerVS
{
    interface IData<T>
    {
        void Put(T obj);
        void PutList(List<T> obj);
        List<T> FindAll(); // gauti visas eilutes
        T FindById(int id);
    }
}
