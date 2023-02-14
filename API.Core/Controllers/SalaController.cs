﻿using Data_core;
using Microsoft.AspNetCore.Mvc;
using Models_core;

namespace API.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaController : Controller
    {
        private SalaDA db;

        public SalaController(IConfiguration config)
        {
            db = new SalaDA(config.GetConnectionString("intranet"));
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
        [HttpGet("remoto/{autogenerado}")]
        public async Task<IActionResult> GetByID(string autogenerado)
        {
            return Ok(db.GetRemoto(autogenerado));
        }

        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetAllByStatus(int status)
        {
            return Ok(db.GetAllByStatus(status));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Sala item)
        {
            if (item == null)
                return BadRequest();

            db.Insert(item);
            return Created("Created", true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] Sala item, int id)
        {
            if (item == null)
                return BadRequest();

            item.idSala = id;
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
