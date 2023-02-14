using Data_core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models_core;

namespace API.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModeloController : Controller
    {
        private ModeloDA db;

        public ModeloController(IConfiguration config)
        {
            db = new ModeloDA(config.GetConnectionString("intranet"));
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(db.GetAllModelo());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetModeloId(string id)
        {
            return Ok(db.GetModeloId(id));
        }

        [HttpGet("marca/{id}")]
        public async Task<IActionResult> GetAllModeloByMarca(string id)
        {
            return Ok(db.GetAllModeloByMarca(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Modelo item)
        {
            if (item == null)
                return BadRequest();

            db.Create(item);
            return Created("Created", true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] Modelo item, int id)
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
