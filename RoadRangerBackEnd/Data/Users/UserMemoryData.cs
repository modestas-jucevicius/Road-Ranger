using RoadRangerBackEnd.Users;
using System.Collections.Generic;

namespace RoadRangerBackEnd.Data.Users
{
    public class UserMemoryData : IUserData
    {
        private static MemoryRepository repository = MemoryRepository.GetInstance();

        public User FindById(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<User> GetAll()
        {
            return MemoryRepository.users;
        }

        public void Put(User obj)
        {
            throw new System.NotImplementedException();
        }

        public void PutList(List<User> obj)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(User obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
