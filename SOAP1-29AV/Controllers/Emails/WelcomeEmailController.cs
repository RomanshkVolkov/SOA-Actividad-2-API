using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Service.IServices;
using System.Web;

namespace SOAP1_29AV.Controllers.Emails
{
    [ApiController]
    [Route("[controller]")]
    public class WelcomeEmailController : Controller
    {
        private readonly IEmailService _emailService;
        private readonly IWebHostEnvironment _webHostEnvironment;



        public WelcomeEmailController(IEmailService emailService, IWebHostEnvironment webHostEnvironment)
        {
            _emailService = emailService;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpGet]
        public IActionResult Index()
        {
            string filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Controllers/Emails/Views/WelcomeEmployeesView.html");

            _emailService.SendEmail(filePath);
            return Ok("Correos Enviados correctamente");
        }
    }
}
