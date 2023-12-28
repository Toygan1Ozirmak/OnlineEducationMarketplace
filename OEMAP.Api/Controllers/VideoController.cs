using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace OEMAP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly string videoFilePath = "PathToYourVideo/video.mp4";

        [HttpGet]
        public IActionResult Get()
        {
            // Video dosyasını oku
            var videoFileStream = new FileStream(videoFilePath, FileMode.Open, FileAccess.Read);

            // Video dosyasını döndür
            return File(videoFileStream, "video/mp4");
        }
    }
}
