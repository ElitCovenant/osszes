using KonyvtarBackEnd.Dto;
using KonyvtarBackEnd.Service.IEmailServices;
using Microsoft.AspNetCore.Mvc;

namespace KonyvtarBackEnd.Controllers
{
    [ApiController]
    [Route("Email")]
    public class EmailController : ControllerBase
    {

        public readonly IEmailService emailService;
        public EmailController(IEmailService emailService)
        {
            this.emailService = emailService;
        }
        [HttpPost]
        public async Task<IActionResult> SendEmail(EmailDto request)
        {
            try
            {
                emailService.SendEmail(request);
                return Ok("Emailküldés sikeresen megtörtént");
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }

        }
    }
}
