using RoadRangerBackEnd.Users;
using System.Collections.Generic;

namespace RoadRangerBackEnd.Data.Users
{
    public class UserMemoryData : IUserData
    {
        private static MemoryRepository repository = MemoryRepository.GetInstance();

        public User FindById(int id)
        {
            foreach(User user in MemoryRepository.users)
            {
                if (user.Id == id) { return user; }
            }
            return null;
        }

        public List<User> GetAll()
        {
            return MemoryRepository.users;
        }

        public void Put(User obj)
        {
            MemoryRepository.users.Add(obj);
        }

        public void PutList(List<User> obj)
        {
            foreach(User user in obj)
            {
                MemoryRepository.users.Add(user);
            }
        }
        public bool Update(User obj)
        {
            for(int i = 0; i < MemoryRepository.users.Count; i++)
            {
                if(MemoryRepository.users[i].Id == obj.Id)
                {
                    MemoryRepository.users.RemoveAt(i);
                    MemoryRepository.users.Insert(i, obj);
                    return true;
                }
            }
            return false;
        }
        public int NewID()
        {
            int Id = MemoryRepository.users[0].Id;
            foreach(User user in MemoryRepository.users)
            {
                if(user.Id >= Id) { Id = user.Id; }
            }
            return ++Id;
        }
    }
}
