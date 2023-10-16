using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Services.Contracts
{
    public interface IUserService
    {
        IEnumerable<User>GetUsers(bool trackChanges);
        
        User GetUserByUserId(int userId,bool trackChanges);

        User CreateUser(User user);

        void UpdateUser(int courseId, Course course);

        void DeleteUser(int courseId, bool trackChanges);
    }
}
