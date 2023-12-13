using Microsoft.AspNetCore.Mvc;

namespace OEMAP.Api.Controllers
{
    [ApiController]
    [Route("api/files")]
    public class FilesController : ControllerBase
    {
        [HttpPost("upload")]
        public async Task <IActionResult> Upload(IFormFile file)
        {
            var folder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads"); 
            if(!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            var path = Path.Combine(folder, file.FileName);
            
            using(var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return Ok(new
            {
                file = file.FileName,
                path = path,
                size = file.Length
            });
        }
    }
}
