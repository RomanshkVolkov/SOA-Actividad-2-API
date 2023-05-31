using Microsoft.AspNetCore.Mvc;
using Service.IServices;

namespace SOAP1_29AV.Controllers
{
    [ApiController]
    [Route("empleados")]
    public class EmpleadoController : Controller
    {
        private readonly IPersona _persona;

        public EmpleadoController(IPersona persona)
        {
            _persona = persona;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_persona.GetEmpleados());
        }

        [HttpGet]
        [Route("activos")]
        public IActionResult GetEmpleadosActivos()
        {
            return Ok(_persona.GetEmpleadosActivos());
        }
    }
}
