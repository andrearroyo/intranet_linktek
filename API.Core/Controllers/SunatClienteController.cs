using Data_core;
using Microsoft.AspNetCore.Mvc;
using Models_core;

namespace API.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SunatClienteController : Controller
    {
        private SunatClienteDA db;

        public SunatClienteController(IConfiguration config)
        {
            db = new SunatClienteDA(config.GetConnectionString("intranet"));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(db.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            return Ok(db.GetByID(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SunatClientes item)
        {
            db.Insert(item);
            return Created("Created", true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] SunatClientes item, int id)
        {
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
