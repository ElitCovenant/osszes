using Microsoft.AspNetCore.Mvc;

namespace KonyvtarBackEnd.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
