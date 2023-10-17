using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEducationMarketplace.Services.Contracts;

namespace OEMAP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public CourseController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult GetAllCourses() 
        {
            var courses = _manager.CourseService.GetAllCourses(false);
        
        }
    }
}
