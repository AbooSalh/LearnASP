using ControllersExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControllersExample.Controllers
{
    [Route("home")]
    public class HomeController : Controller
    {
        [Route("method1")]
        public JsonResult Method1()
        {
            return new JsonResult(new Person());
        }
    }
}
