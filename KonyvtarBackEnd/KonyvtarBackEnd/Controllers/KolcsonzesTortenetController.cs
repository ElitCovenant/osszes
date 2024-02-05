using Microsoft.AspNetCore.Mvc;

namespace KonyvtarBackEnd.Controllers
{
    [ApiController]
    [Route("/Kolcsonzestortenet")]
    public class KolcsonzesTortenetController : ControllerBase
    {
        public IActionResult Index()
        {
            return null;
        }
    }
}
