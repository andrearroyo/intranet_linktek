using Data_core;
using Microsoft.AspNetCore.Mvc;
using Models_core;

namespace API.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedioJuegoController : Controller
    {
        private MedioJuegoDA db;

        public MedioJuegoController(IConfiguration config)
        {
            db = new MedioJuegoDA(config.GetConnectionString("intranet"));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(db.GetAllMedioJuego());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMedioJuegoId(string id)
        {
            return Ok(db.GetMedioJuegoId(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MedioJuego item)
        {
            if (item == null)
                return BadRequest();

            db.Create(item);
            return Created("Created", true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] MedioJuego item, int id)
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
