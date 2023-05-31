using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Service.IServices;

namespace SOAP1_29AV.Controllers
{
    [ApiController]
    [Route("login")]
    public class AuthController : Controller
    {
            private readonly IAuth _auth;

        public AuthController(IAuth auth)
        {
                _auth = auth;


        }
        [HttpPost]
        public IActionResult Login([FromBody] LoginPersona model)
        {
            // Lógica de autenticación aquí
            LoginPersona? isAuthenticated = _auth.Login(model.Email, model.Password);

            if (isAuthenticated != null)
                return Ok(isAuthenticated); // Retorna código de estado 200 (OK) en caso de éxito
     
            else
                return Unauthorized("Contraseña incorrecta"); // Retorna código de estado 401 (Unauthorized) en caso de credenciales incorrectas
      
        }
    }
}

