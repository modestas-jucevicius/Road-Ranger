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
        void PutList(T obj);
        List<T> FindAll(); // gauti visas eilutes + naudoti default parametrus
        T FindOne(); // gauti tik viena - pirmaja teisinga eilute
        
    }
}
