using RoadRangerBackEnd.Cars;
using System.Collections.Generic;

namespace RoadRangerBackEnd.Data
{
    public interface ICarData
    {
        void Put(Car obj);
        void PutList(List<Car> obj);
        List<Car> FindAll();
        Car FindById(int id);
        bool Update(int id, Car obj);
        bool Remove(int id);
    }
}
