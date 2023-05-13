using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace OneDaily.Controllers
{
    public class TestPostController : Controller
    {
        [HttpGet("testpost")]
        public IActionResult Index()
        {
            var file = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "testpost.html");
            return PhysicalFile(file, "text/html");
        }
    }
}
