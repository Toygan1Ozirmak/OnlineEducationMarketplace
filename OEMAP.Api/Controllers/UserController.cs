using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using OnlineEducationMarketplace.Entity.Entities;
using OnlineEducationMarketplace.Services.Contracts;
using System.Diagnostics.Eventing.Reader;

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

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
                var users = _manager.UserService.GetAllUsers(false);
                return Ok(users);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpGet("{userId:int}")]
        public IActionResult GetUserByUserId([FromRoute(Name = "userId")] int userId)
        {
            try
            {
                var user = _manager
                .UserService
                .GetUserByUserId(userId, false);

                if (user is null)
                    return NotFound(); //404

                return Ok(user);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        [HttpPost()]
        public IActionResult CreateUser([FromBody] User user)
        {
            try
            {

                if (user is null)
                    return BadRequest(); //400

                _manager.UserService.CreateUser(user);

                return StatusCode(201, user);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{userId:int")]
        public IActionResult UpdateCourse([FromRoute(Name = "userId")] int userId,
            [FromBody] User user)
        {
            try
            {

                if (user is null)
                    return BadRequest(); //400

                //check user

                var entity = _manager
                    .UserService
                    .GetUserByUserId(userId, true);

                if (entity is null)
                    return NotFound(); //404

                //check id

                if (userId != user.UserId)
                    return BadRequest(); //400


                _manager.UserService.UpdateUser(userId, user, true);
                return NoContent(); //204

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{userId:int")]
        public IActionResult DeleteUser([FromRoute(Name = "userId")] int userId)
        {
            try
            {
                var entity = _manager
                    .UserService
                    .GetUserByUserId(userId, false);
                if (entity is null)
                    return NotFound(new
                    {
                        statusCode = 404,
                        message = $"User with userId:{userId} could not found"
                    }); //404

                _manager.UserService.DeleteUser(userId, false);
                return NoContent();

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPatch("{userId:int")]
        public IActionResult PartiallyUpdateUser([FromRoute(Name = "userId")] int userId,
            [FromBody] JsonPatchDocument<User> userPatch)
        {
            try
            {
                //check entity

                var entity = _manager
                    .UserService
                    .GetUserByUserId(userId, true);

                if (entity is null)
                    return NotFound(); //404

                userPatch.ApplyTo(entity);
                _manager.UserService.UpdateUser(userId, entity, true);

                return NoContent(); //204
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
