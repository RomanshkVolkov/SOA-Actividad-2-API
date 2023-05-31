using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Service.IServices;

namespace SOAP1_29AV.Controllers
{
    [ApiController]
    [Route("activos")]
    public class ActivosController : Controller
    {

        private readonly IActivo _activo;

        public ActivosController(IActivo activo)
        {
            _activo = activo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_activo.ObtenerLista());
        }

        [HttpPost]
        public IActionResult CrearActivo([FromBody] ActivoRequest request)
        {
            return Ok(_activo.CrearActivo(request));
        }

        [HttpPatch]
        public IActionResult EditarActivo([FromBody] UpdateActivoRequest request)
        {
            return Ok(_activo.EditarActivo(request));
        }

        [HttpGet]
        [Route("empleados")]
        public IActionResult EmpleadoLista()
        {
            return Ok(_activo.EmpleadoLista());
        }

    }
}
