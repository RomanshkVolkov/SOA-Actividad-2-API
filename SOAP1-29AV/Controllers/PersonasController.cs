using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Service.IServices;

namespace SOAP1_29AV.Controllers
{
    [ApiController]
    [Route("persona")]
    public class PersonasController : Controller
    {

        private readonly IPersona _persona;

        public PersonasController(IPersona persona)
        {
            _persona = persona;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_persona.GetEmpleados());
        }
       
        [HttpPost]
        public IActionResult CreatePerson([FromBody] CreatePersonRequest request)
        {
            return Ok(_persona.CreatePerson(request));
        }

        [HttpPatch]
        public IActionResult UpdatePerson([FromBody] UpdatePersonRequest request)
        {
            return Ok(_persona.UpdatePerson(request));
        }

        [HttpDelete]
        public IActionResult DeletePerson([FromQuery] int id)
        {
            return Ok(_persona.DeletePerson(id));
        }
    }

}
