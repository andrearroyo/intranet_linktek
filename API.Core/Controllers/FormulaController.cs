using Data_core;
using Microsoft.AspNetCore.Mvc;
using Models_core;

namespace API.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormulaController : Controller
    {
        private FormulaDA db;

        public FormulaController(IConfiguration config)
        {
            db = new FormulaDA(config.GetConnectionString("intranet"));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(db.GetAllFormula());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAll(string id)
        {
            return Ok(db.GetFormulaId(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Formula item)
        {
            if (item == null)
                return BadRequest();

            db.Create(item);
            return Created("Created", true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] Formula item, int id)
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
