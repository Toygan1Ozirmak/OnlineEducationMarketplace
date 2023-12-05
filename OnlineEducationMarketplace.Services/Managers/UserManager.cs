using AutoMapper;
using OnlineEducationMarketplace.Data.Contracts;
using OnlineEducationMarketplace.Entity.DTOs;
using OnlineEducationMarketplace.Entity.Entities;
using OnlineEducationMarketplace.Entity.Exceptions;
using OnlineEducationMarketplace.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OnlineEducationMarketplace.Entity.Exceptions.NotFoundException;

namespace OnlineEducationMarketplace.Services
{
    public class UserManager : IUserService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public UserManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task <UserDto> CreateUserAsync(UserDtoForInsertion userDto)
        {
            var entity = _mapper.Map<User>(userDto);
            _manager.User.CreateUser(entity);
            await _manager.SaveAsync();
            return _mapper.Map<UserDto>(entity);

        }

        public async Task DeleteUserAsync(int userId, bool trackChanges)
        {
            //check entity
            var entity = await _manager.User.GetUserByUserIdAsync(userId, trackChanges);
            if (entity is null)
            {
                throw new UserNotFoundException(userId);
            }
            _manager.User.DeleteUser(entity);
            await _manager.SaveAsync();
        }

        public async Task <UserDto> GetUserByUserIdAsync(int userId, bool trackChanges)
        {
            var user = await _manager.User.GetUserByUserIdAsync(userId, trackChanges);
            if (user is null)
            {
                throw new UserNotFoundException(userId);
            }
            return _mapper.Map<UserDto>(user);

        }

        public async Task <IEnumerable<UserDto>> GetAllUsersAsync(bool trackChanges)
        {
            var users = await _manager.User.GetAllUsersAsync(trackChanges);
            return _mapper.Map<IEnumerable<UserDto>>(users);

        }

        public async Task UpdateUserAsync(int userId, UserDtoForUpdate userDto, bool trackChanges)
        {
            //check entity
            var entity = await _manager.User.GetUserByUserIdAsync(userId, trackChanges);
            if (entity is null)
            {
                throw new UserNotFoundException(userId);
            }



            entity = _mapper.Map<User>(userDto);
            _manager.User.Update(entity);//updateuser-update
            await _manager.SaveAsync();

        }
    }
}