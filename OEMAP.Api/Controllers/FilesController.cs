using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace OEMAP.Api.Controllers
{
    [ApiController]
    [Route("api/files")]
    public class FilesController : ControllerBase
    {
        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            // Manuel olarak dosyanın kaydedileceği dizini belirtin.
            var customPath = @"C:\Users\toyga\source\repos\OnlineEducationMarketplace\FRONTEND\ClientApp\src\Uploads";
            var folder = Path.Combine(customPath);

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            var path = Path.Combine(folder, file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
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
