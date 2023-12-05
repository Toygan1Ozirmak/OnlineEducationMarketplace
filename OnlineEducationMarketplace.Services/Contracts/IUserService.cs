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
        Task <IEnumerable<UserDto>>GetAllUsersAsync(bool trackChanges);

        Task <UserDto> GetUserByUserIdAsync(int userId,bool trackChanges);

        Task <UserDto> CreateUserAsync(UserDtoForInsertion user);

        Task UpdateUserAsync(int userId, UserDtoForUpdate userDto, bool trackChanges);

        Task DeleteUserAsync(int userId, bool trackChanges);
    }
}
