using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Alertas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VerificarController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Verificar()
        {
            return Ok("Servicio Funcionando");
        }
    }
}
