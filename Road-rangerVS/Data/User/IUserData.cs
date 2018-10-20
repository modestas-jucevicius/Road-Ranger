
using Road_rangerVS.Users;
using System.Collections.Generic;

namespace Road_rangerVS.Data
{
    interface IUserData
    {
        void Put(User obj);
        void PutList(List<User> obj);
        List<User> FindAll(); // gauti visas eilutes
        User FindById(int id);
        bool Update(int id, User obj);
    }
}
