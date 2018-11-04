using RoadRangerBackEnd.Cars;
using System.Collections.Generic;

namespace RoadRangerBackEnd.Data.Cars
{
    public class CarMemoryData : ICarData
    {
        private static MemoryRepository repository = MemoryRepository.GetInstance();

        public List<Car> FindAll()
        {
            return MemoryRepository.cars;
        }

        public Car FindById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Put(Car obj)
        {
            throw new System.NotImplementedException();
        }

        public void PutList(System.Collections.Generic.List<Car> obj)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(int id, Car obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
