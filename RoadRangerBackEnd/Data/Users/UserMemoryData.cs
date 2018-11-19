using RoadRangerBackEnd.Users;
using System.Collections.Generic;
using System.Linq;

namespace RoadRangerBackEnd.Data.Users
{
    public class UserMemoryData : IUserData
    {
        private static MemoryRepository repository = MemoryRepository.GetInstance();

        public User FindById(int id)
        {
            try
            {
                User foundUser = MemoryRepository.users.Single(user => user.Id == id);
                return foundUser;
            }
            catch (System.InvalidOperationException)
            {
                return null;
            }
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
            MemoryRepository.users = (from user in obj
                                     select user).ToList();
        }
        public bool Update(User obj)
        {
            try
            {
                foreach (var item in MemoryRepository.users.Where(user => user.Id == obj.Id))
                {
                    item.Name = obj.Name;
                    item.Password = obj.Password;
                    item.Score = obj.Score;
                    item.Username = obj.Username;
                    item.Boosts = obj.Boosts;
                }
                return true;
            }
            catch (System.InvalidOperationException)
            {
                return false;
            }
        }
        public int NewID()
        {
            User lastUser = MemoryRepository.users.OrderBy(user => user.Id).Last();
            return ++lastUser.Id;
        }
    }
}
