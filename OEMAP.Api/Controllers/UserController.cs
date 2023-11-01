using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using OnlineEducationMarketplace.Entity.Entities;
using OnlineEducationMarketplace.Entity.Exceptions;
using OnlineEducationMarketplace.Services.Contracts;
using System.Diagnostics.Eventing.Reader;
using static OnlineEducationMarketplace.Entity.Exceptions.BadHttpRequestException;

namespace OEMAP.Api.Controllers
{
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


        [HttpPost("Create")]
        public IActionResult CreateUser([FromBody] User user)
        {


            if (user is null)
                throw new CreateUserBadHttpRequestException(user); //400

            _manager.UserService.CreateUser(user);

            return StatusCode(201, user);


        }

        [HttpPut("Update/{userId:int}")]
        public IActionResult UpdateUser([FromRoute(Name = "userId")] int userId,
            [FromBody] User user)
        {


            if (user is null)
                throw new UserBadHttpRequestException(userId); //400


            _manager.UserService.UpdateUser(userId, user, true);
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
            [FromBody] JsonPatchDocument<User> userPatch)
        {

            //check entity

            var entity = _manager
                .UserService
                .GetUserByUserId(userId, true);

            userPatch.ApplyTo(entity);
            _manager.UserService.UpdateUser(userId, entity, true);

            return NoContent(); //204


        }

    }
}