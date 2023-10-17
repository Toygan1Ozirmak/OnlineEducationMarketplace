using OnlineEducationMarketplace.Data.Contracts;
using OnlineEducationMarketplace.Entity.Entities;
using OnlineEducationMarketplace.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Services
{
    public class UserManager : IUserService 
    {
        private readonly IRepositoryManager _manager;

        public UserManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public User CreateUser(User user)
        {
            _manager.User.CreateUser(user);
            _manager.Save();
            return user;
        }

        public void DeleteUser(int userId, bool trackChanges)
        {
            _manager.User.GetUserByUserId(userId, trackChanges);
            _manager.Save();
        }

        public User GetUserByUserId(int userId, bool trackChanges)
        {
            return _manager.User.GetUserByUserId(userId, trackChanges);
        }

        public IEnumerable<User> GetAllUsers(bool trackChanges)
        {
            return _manager.User.GetAllUsers(trackChanges);
        }

        public void UpdateUser(int userId, User user, bool trackChanges)
        {
            _manager.User.GetUserByUserId(userId, trackChanges);
            _manager.User.UpdateUser(user);
            _manager.Save();
        }
    }
}
