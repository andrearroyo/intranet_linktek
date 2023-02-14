using Data_core;
using Microsoft.AspNetCore.Mvc;
using Models_core;

namespace API.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DenominacionController : Controller
    {
        private DenominacionDA db;

        public DenominacionController(IConfiguration config)
        {
            db = new DenominacionDA(config.GetConnectionString("intranet"));
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //return Ok(db.GetAllDenominacion());
            return Json(db.GetAllDenominacion());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDenominacionId(int id)
        {
            return Ok(db.GetDenominacionId(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Denominacion item)
        {
            if (item == null)
                return BadRequest();

            db.Create(item);
            return Created("Created", true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] Denominacion item, int id)
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
