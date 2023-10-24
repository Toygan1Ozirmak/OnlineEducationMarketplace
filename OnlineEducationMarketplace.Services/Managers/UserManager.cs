using OnlineEducationMarketplace.Data.Contracts;
using OnlineEducationMarketplace.Entity.Entities;
using OnlineEducationMarketplace.Entity.Exceptions;
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
            //check entity
            var entity = _manager.User.GetUserByUserId(userId, trackChanges);
            if (entity is null)
            {
                throw new CourseNotFoundException(userId);
            }
            _manager.User.DeleteUser(entity);
            _manager.Save();
        }

        public User GetUserByUserId(int userId, bool trackChanges)
        {
            var user  = _manager.User.GetUserByUserId(userId, trackChanges);
            if (user is null)
            {
                throw new CourseNotFoundException(userId);
            }
            return user;
        }

        public IEnumerable<User> GetAllUsers(bool trackChanges)
        {
            return _manager.User.GetAllUsers(trackChanges);
        }

        public void UpdateUser(int userId, User user, bool trackChanges)
        {
            //check entity
            var entity = _manager.User.GetUserByUserId(userId, trackChanges);
            if(entity is null)
                throw new UserNotFoundException(userId);

            entity.FirstName = user.FirstName;
            entity.LastName = user.LastName;
            entity.Email = user.Email;
            entity.Password = user.Password;
            entity.UserName = user.UserName;
            entity.RoleId = user.RoleId;
            entity.UserBio = user.UserBio;
            entity.Reviews = user.Reviews;
            entity.CourseEnrollments = user.CourseEnrollments;

            _manager.User.UpdateUser(user);
            _manager.Save();
        }
    }
}
