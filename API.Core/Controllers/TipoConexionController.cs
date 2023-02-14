using Data_core;
using Microsoft.AspNetCore.Mvc;
using Models_core;

namespace API.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoConexionController : Controller
    {
        private TipoConexionDA db;

        public TipoConexionController(IConfiguration config)
        {
            db = new TipoConexionDA(config.GetConnectionString("intranet"));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTipoConexion()
        {
            return Ok(db.GetAllTipoConexion());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAll(string id)
        {
            return Ok(db.GetTipoMaquinaId(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TipoConexion item)
        {
            if (item == null)
                return BadRequest();

            db.Create(item);
            return Created("Created", true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] TipoConexion item, int id)
        {
            if (item == null)
                return BadRequest();

            item.idTipoConexion = id;
            db.Update(item);
            return Created("Created", true);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            db.Delete(id);
            return NoContent();
        }
    }
}
