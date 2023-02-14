using Data_core;
using Microsoft.AspNetCore.Mvc;
using Models_core;

namespace API.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicenciaController : Controller
    {
        private LicenciaDA db;

        public LicenciaController(IConfiguration config)
        {
            db = new LicenciaDA(config.GetConnectionString("intranet"));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(db.GetAll());
        }

        [HttpGet("{idPaquete}/{idSala}")]
        public async Task<IActionResult> GetByIDs(int idPaquete, int idSala)
        {
            return Ok(db.GetByIDs(idPaquete, idSala));
        }

        [HttpGet("GetLicenciaRemota/{idSala}/{fecha}")]
        public async Task<IActionResult> GetLicenciaRemota(int idSala, string fecha)
        {
            return Ok(db.GetLicenciaRemota(idSala, fecha));
        }

        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetAllByStatus(int status)
        {
            return Ok(db.GetAllByStatus(status));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Licencia item)
        {
            if (item == null)
                return BadRequest();

            db.Insert(item);
            return Created("Created", true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] Licencia item, int id)
        {
            if (item == null)
                return BadRequest();

            item.idLicencia = id;
            db.Update(item);
            return Created("updated", true);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            db.Delete(id);
            return NoContent();
        }
    }
}
