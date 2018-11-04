using RoadRangerBackEnd.Cars;
using System.Collections.Generic;

namespace RoadRangerBackEnd.Data
{
    public interface IUserCarData
    {
        void Put(UserCar obj);
        void PutList(List<UserCar> obj);
        List<UserCar> FindAll();
        UserCar FindById(int id);
        bool Update(int id, UserCar obj);
        bool Remove(int id);
    }
}
