using Data_core;
using Microsoft.AspNetCore.Mvc;
using Models_core;

namespace API.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : Controller
    {
        private EventoDA db;

        public EventosController(IConfiguration config)
        {
            db = new EventoDA(config.GetConnectionString("intranet"));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEvento()
        {
            return Ok(db.GetAllEvento());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventoId(string id)
        {
            return Ok(db.GetEventoId(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Evento item)
        {
            if (item == null)
                return BadRequest();

            db.Create(item);
            return Created("Created", true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] Evento item, int id)
        {
            if (item == null)
                return BadRequest();

            item.id = id;
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
