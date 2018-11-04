using RoadRangerBackEnd.Cars;
using System.Collections.Generic;
<<<<<<< HEAD:RoadRangerBackEnd/Data/Cars/ICarData.cs
=======
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Road_rangerVS.Cars;
>>>>>>> 14143fd53e9df87f9d61baa2872c61231ac6452d:Road-rangerVS/Data/Car/ICarData.cs

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
