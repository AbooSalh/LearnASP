using Microsoft.AspNetCore.Mvc;

namespace EnviromentExample.Controllers
{
    public class HomeController(IWebHostEnvironment webHostEnvironment) : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            ViewBag.EnvironmentName = webHostEnvironment.EnvironmentName;
            return View();
        }
    }
}
