using Microsoft.AspNetCore.Mvc;

namespace KonyvtarBackEnd.Controllers
{
    [ApiController]
    [Route("/Konyv")]
    public class KonyvController : ControllerBase
    {
        public IActionResult Index()
        {
            return null;
        }
    }
}
