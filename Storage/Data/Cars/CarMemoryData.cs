using Models.Cars;
using System.Collections.Generic;
using System.Linq;

namespace Storage.Data.Cars
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
           try
            {
               Car foundCar = MemoryRepository.cars.Single(car => car.Id == id);
                return foundCar;
            }
            catch(System.InvalidOperationException)
            {
                return null;
            }
        }

        public int NewID()
        {
            Car lastCar = MemoryRepository.cars.OrderBy(car => car.Id).Last();
            return ++lastCar.Id;
        }

        public void Put(Car obj)
        {
            MemoryRepository.cars.Add(obj);
        }

        public void PutList(System.Collections.Generic.List<Car> obj)
        {
            MemoryRepository.cars = (from car in obj
                                     select car).ToList();
        }

        public bool Remove(int id)
        {
            try
            {
                MemoryRepository.cars.RemoveAll((car) => car.Id == id);
                return true;
            }
            catch (System.InvalidOperationException)
            {
                return false;
            }

        }

        public bool Update(int id, Car obj)
        {
            try
            {
                foreach (var item in MemoryRepository.cars.Where(car => car.Id == id))
                {
                    item.IsReported = obj.IsReported;
                    item.Status = obj.Status;
                    item.UserId = obj.UserId;
                }
                return true;
            }
            catch (System.InvalidOperationException)
            {
                return false;
            }

        }

    }
}
