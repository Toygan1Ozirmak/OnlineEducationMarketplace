using DocumentFormat.OpenXml.Vml.Office;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using OEMAP.Api.ActionFilters;
using OnlineEducationMarketplace.Entity.DTOs;
using OnlineEducationMarketplace.Entity.Entities;
using OnlineEducationMarketplace.Entity.Exceptions;
using OnlineEducationMarketplace.Services.Contracts;
using System.Diagnostics.Eventing.Reader;
using static OnlineEducationMarketplace.Entity.Exceptions.BadHttpRequestException;

namespace OEMAP.Api.Controllers
{
    [Authorize]
    [ServiceFilter(typeof(LogFilterAttribute))]
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public UserController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
        {

            var users = _manager.UserService.GetAllUsers(false);
            return Ok(users);



        }

        [HttpGet("GetUserByUserId/{userId:int}")]
        public IActionResult GetUserByUserId([FromRoute(Name = "userId")] int userId)
        {

            var user = _manager
            .UserService
            .GetUserByUserId(userId, false);



            return Ok(user);



        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost("Create")]
        public IActionResult CreateUser([FromBody] UserDtoForInsertion userDto)
        {


            //if (userDto is null)
            //    return BadRequest(); //400

            _manager.UserService.CreateUser(userDto);

            return StatusCode(201, userDto);


        }
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("Update/{userId:int}")]
        public IActionResult UpdateUser([FromRoute(Name = "userId")] int userId,
            [FromBody] UserDtoForUpdate userDto)
        {


            //if (userDto is null)
            //    throw new UserBadHttpRequestException(userId); //400


            _manager.UserService.UpdateUser(userId, userDto, true);
            return NoContent(); //204


        }

        [HttpDelete("Delete/{userId:int}")]
        public IActionResult DeleteUser([FromRoute(Name = "userId")] int userId)
        {


            _manager.UserService.DeleteUser(userId, false);
            return NoContent();


        }

        [HttpPatch("PartiallyUpdate/{userId:int}")]
        public IActionResult PartiallyUpdateUser([FromRoute(Name = "userId")] int userId,
            [FromBody] JsonPatchDocument<UserDto> userPatch)
        {

            //check entity

            var userDto = _manager
                .UserService
                .GetUserByUserId(userId, true);

            userPatch.ApplyTo(userDto);
            _manager.UserService.UpdateUser(userId, 
                new UserDtoForUpdate()
                {
                    UserId = userDto.UserId, 
                    FirstName = userDto.FirstName, 
                    LastName = userDto.LastName, 
                    Email = userDto.Email, 
                    Password = userDto.Password, 
                    UserName = userDto.UserName,    
                    RoleId = userDto.RoleId, 
                    UserBio = userDto.UserBio
                }, true);
            return NoContent(); //204


        }

    }
}