using Microsoft.AspNetCore.Mvc;

namespace OEMAP.Api.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
