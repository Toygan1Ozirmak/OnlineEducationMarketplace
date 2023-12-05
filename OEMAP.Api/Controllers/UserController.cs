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
        public async Task <IActionResult> GetAllUsersAsync()
        {

            var users = await _manager.UserService.GetAllUsersAsync(false);
            return Ok(users);



        }

        [HttpGet("GetUserByUserId/{userId:int}")]
        public async Task <IActionResult> GetUserByUserIdAsync([FromRoute(Name = "userId")] int userId)
        {

            var user = await _manager
            .UserService
            .GetUserByUserIdAsync(userId, false);



            return Ok(user);



        }

        //[ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost("Create")]
        public async Task <IActionResult> CreateUserAsync([FromBody] UserDtoForInsertion userDto)
        {


            //if (userDto is null)
            //    return BadRequest(); //400

            await _manager.UserService.CreateUserAsync(userDto);

            return StatusCode(201, userDto);


        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("Update/{userId:int}")]
        public async Task <IActionResult> UpdateUserAsync([FromRoute(Name = "userId")] int userId,
            [FromBody] UserDtoForUpdate userDto)
        {


            //if (userDto is null)
            //    throw new UserBadHttpRequestException(userId); //400


            await _manager.UserService.UpdateUserAsync(userId, userDto, true);
            return NoContent(); //204


        }

        [HttpDelete("Delete/{userId:int}")]
        public async Task <IActionResult> DeleteUserAsync([FromRoute(Name = "userId")] int userId)
        {


            await _manager.UserService.DeleteUserAsync(userId, false);
            return NoContent();


        }

        [HttpPatch("PartiallyUpdate/{userId:int}")]
        public async Task <IActionResult> PartiallyUpdateUserAsync([FromRoute(Name = "userId")] int userId,
            [FromBody] JsonPatchDocument<UserDto> userPatch)
        {

            //check entity

            var userDto = await _manager
                .UserService
                .GetUserByUserIdAsync(userId, true);

            userPatch.ApplyTo(userDto);
            await _manager.UserService.UpdateUserAsync(userId, 
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