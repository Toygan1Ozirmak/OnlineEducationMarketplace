using OnlineEducationMarketplace.Entity.DTOs;
using OnlineEducationMarketplace.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Services.Contracts
{
    public interface IUserService
    {
        IEnumerable<UserDto>GetAllUsers(bool trackChanges);

        UserDto GetUserByUserId(int userId,bool trackChanges);

        UserDto CreateUser(UserDtoForInsertion user);

        void UpdateUser(int userId, UserDtoForUpdate userDto, bool trackChanges);

        void DeleteUser(int userId, bool trackChanges);
    }
}
