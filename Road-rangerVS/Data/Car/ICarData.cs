using Road_rangerVS.Recognition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Road_rangerVS.Data
{
    interface ICarData
    {
        void Put(Car obj);
        void PutList(List<Car> obj);
        List<Car> FindAll(); // gauti visas eilutes
        Car FindById(int id);
        bool Update(int id, Car obj);
        bool Remove(int id);
    }
}
