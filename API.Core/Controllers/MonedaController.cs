using Data_core;
using Microsoft.AspNetCore.Mvc;
using Models_core;

namespace API.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonedaController : Controller
    {
        private MonedaDA db;

        public MonedaController(IConfiguration config)
        {
            db = new MonedaDA(config.GetConnectionString("intranet"));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(db.GetAllMoneda());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMonedaId(string id)
        {
            return Ok(db.GetMonedaId(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Moneda item)
        {
            if (item == null)
                return BadRequest();

            db.Create(item);
            return Created("Created", true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] Moneda item, int id)
        {
            if (item == null)
                return BadRequest();

            item.id = id;
            db.Update(item);
            return Created("Created", true);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            db.Delete(id);
            return NoContent();
        }
    }
}
