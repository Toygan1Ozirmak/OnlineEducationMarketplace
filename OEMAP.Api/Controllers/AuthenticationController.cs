using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;
using OnlineEducationMarketplace.Entity.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using OnlineEducationMarketplace.Entity.Entities;
using OnlineEducationMarketplace.Services.Contracts;
using System.Diagnostics.Eventing.Reader;
using static OnlineEducationMarketplace.Entity.Exceptions.BadHttpRequestException;
using OEMAP.Api.ActionFilters;
using Microsoft.AspNetCore.Authorization;

namespace OEMAP.Api.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/authentication")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IServiceManager _service;
        public AuthenticationController(IServiceManager service)
        {
            _service = service;
        }

        [HttpPost("register")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]

        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistrationDto)
        {
            var result = await _service
                .AuthenticationService
                .RegisterUser(userForRegistrationDto);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }

            return StatusCode(201);
        }

        [HttpPost("login")]
        //[ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
        {
            try
            {
                // Uncomment the next line if you want to use the ValidationFilterAttribute
                // This assumes the ValidateUser method throws an exception on validation failure
                await _service.AuthenticationService.ValidateUser(user);

                if (!await _service.AuthenticationService.ValidateUser(user))
                {
                    return Unauthorized("Invalid username or password"); //401
                }

                return Ok(new
                {
                    Token = await _service.AuthenticationService.CreateToken()
                });
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                Console.Error.WriteLine($"Authentication error: {ex.Message}");
                return BadRequest("Authentication failed"); // You might want to return a different status code here
            }
        }

    }


}

       