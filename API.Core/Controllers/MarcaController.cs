using Data_core;
using Microsoft.AspNetCore.Mvc;
using Models_core;

namespace API.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : Controller
    {
        private MarcaDA db;

        public MarcaController(IConfiguration config)
        {
            db = new MarcaDA(config.GetConnectionString("intranet"));
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(db.GetAllMarca());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMarcaId(int id)
        {
            return Ok(db.GetMarcaId(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Marca item)
        {
            if (item == null)
                return BadRequest();

            db.Create(item);
            return Created("Created", true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] Marca item, int id)
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
