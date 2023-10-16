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

        public CourseManager(IRepositoryManager manager)
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
            _manager.User.DeleteUser(courseId, trackChanges);
            _manager.Save();
        }

        public User GetUserByUserId(int userId)
        {
            return _manager.User.GetUserByUserId(userId, trackChanges);
        }

        public IEnumerable<User> GetUser(bool trackChanges)
        {
            return _manager.User.GetUser(trackChanges);
        }

        public void UpdateUser(int userId, Course course)
        {
            _manager.User.Update(userId, course);
            _manager.Save();
        }
    }
}
