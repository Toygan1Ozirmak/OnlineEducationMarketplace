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
                throw new UserNotFoundException(userId);
            }
            _manager.User.DeleteUser(entity);
            _manager.Save();
        }

        public User GetUserByUserId(int userId, bool trackChanges)
        {
            var user  = _manager.User.GetUserByUserId(userId, trackChanges);
            if (user is null)
            {
                throw new UserNotFoundException(userId);
            }
            return user;
        }

        public IEnumerable<UserDto> GetAllUsers(bool trackChanges)
        {
            var users = _manager.User.GetAllUsers(trackChanges);
            return _mapper.Map<IEnumerable<UserDto>>(users);

        }

            public void UpdateUser(int userId, UserDtoForUpdate userDto, bool trackChanges)
        {
            //check entity
            var entity = _manager.User.GetUserByUserId(userId, trackChanges);
            if(entity is null)
                throw new UserNotFoundException(userId);

            //entity.FirstName = user.FirstName;
            //entity.LastName = user.LastName;
            //entity.Email = user.Email;
            //entity.Password = user.Password;
            //entity.UserName = user.UserName;
            //entity.RoleId = user.RoleId;
            //entity.UserBio = user.UserBio;
            //entity.Reviews = user.Reviews;
            //entity.CourseEnrollments = user.CourseEnrollments;
            entity = _mapper.Map<User>(userDto);
            _manager.User.UpdateUser(entity);
            _manager.Save();
        }
    }
}
