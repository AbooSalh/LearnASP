using Microsoft.AspNetCore.Mvc;
using ModelBindingExample.Models;

namespace ModelBindingExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("bookstore/{bookid?}/{isloggedin?}")]

        public IActionResult Index(int? bookid, bool? isloggedin , [FromBody] Book book)
        {
            return Json(new
            {
                BookId = bookid,
                IsLoggedIn = isloggedin,
                Book = book
            });
        }
    }
}
