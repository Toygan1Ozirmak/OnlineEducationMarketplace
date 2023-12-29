using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace OEMAP.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class S3Controller : ControllerBase
    {
        // İstediğiniz video URL'sini buraya sabit olarak tanımlayabilirsiniz.
        private const string CustomVideoUrl = "https://toygantestbucket.s3.eu-central-1.amazonaws.com/machine-learning.mp4";

        [HttpGet]
        [Route("GetVideo")]
        public IActionResult GetVideo()
        {
            try
            {
                // S3'den gelen URL'yi döndür
                return Ok(CustomVideoUrl);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
