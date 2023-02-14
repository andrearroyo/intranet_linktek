using Data_core;
using Microsoft.AspNetCore.Mvc;
using Models_core;

namespace API.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaqueteSistemaController : Controller
    {
        private PaqueteSistemaDA db;

        public PaqueteSistemaController(IConfiguration config)
        {
            db = new PaqueteSistemaDA(config.GetConnectionString("intranet"));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(db.GetAll());
        }

        [HttpGet("PaqueteSistema")]
        public async Task<IActionResult> GetAllPaqueteSistema()
        {
            return Json(db.GetAllPaqueteSistema());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            return Ok(db.GetByID(id));
        }

        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetAllByStatus(int status)
        {
            return Ok(db.GetAllByStatus(status));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PaqueteSistema item)
        {
            if (item == null)
                return BadRequest();

            db.Insert(item);
            return Created("Created", true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] PaqueteSistema item, int id)
        {
            if (item == null)
                return BadRequest();

            item.idPaqueteSistema = id;
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
