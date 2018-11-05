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
            foreach(Car car in MemoryRepository.cars)
            {
                if(car.Id == id) { return car;}
            }
            return null;
        }

        public int NewID()
        {
            int Id = MemoryRepository.cars[0].Id;
            foreach(Car car in MemoryRepository.cars)
            {
                if(car.Id >= Id) { Id = car.Id;  }
            }
            return ++Id;
        }

        public void Put(Car obj)
        {
            MemoryRepository.cars.Add(obj);
        }

        public void PutList(System.Collections.Generic.List<Car> obj)
        {
            foreach(Car car in obj) { MemoryRepository.cars.Add(car); }
        }

        public bool Remove(int id)
        {
            foreach(Car car in MemoryRepository.cars)
            {
                if(car.Id == id)
                {
                    MemoryRepository.cars.Remove(car);
                    return true;
                }
            }
            return false;

        }

        public bool Update(int id, Car obj)
        {
            for(int i = 0; i < MemoryRepository.cars.Count; i++)
            {
                if(MemoryRepository.cars[i].Id == id)
                {
                    MemoryRepository.cars.RemoveAt(i);
                    MemoryRepository.cars.Insert(i, obj);
                    return true;
                }
            }
            return false;
        }

    }
}
