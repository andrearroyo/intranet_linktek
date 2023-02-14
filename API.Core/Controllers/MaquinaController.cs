using Data_core;
using Microsoft.AspNetCore.Mvc;
using Models_core;

namespace API.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaquinaController : Controller
    {
        private MaquinaDA db;

        public MaquinaController(IConfiguration config)
        {
            db = new MaquinaDA(config.GetConnectionString("intranet"));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(db.GetAllMaquina());
        }
        [HttpGet("Remoto/{idSala}")]
        public async Task<IActionResult> GetAll(int idSala)
        {
            return Ok(db.GetAllMaquina(idSala));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(db.GetById(id));
        }

        [HttpGet("estado/{estado}")]
        public async Task<IActionResult> GetAllMaquinaStatus(int estado)
        {
            return Ok(db.GetAllMaquinaStatus(estado));
        }

        [HttpGet("maquina/{codMaq}")]
        public async Task<IActionResult> GetByCodMaq(string codMaq)
        {
            return Ok(db.GetByCodMaq(codMaq));
        }

        [HttpGet("BuscarMarca/{idMarca}")]
        public async Task<IActionResult> BuscarPorMarca(int idMarca)
        {
            return Ok(db.BuscarPorMarca(idMarca));
        }

        [HttpGet("BuscarTipoConexion/{idTipoConexion}")]
        public async Task<IActionResult> BuscarPorTipoConexion(int idTipoConexion)
        {
            return Ok(db.BuscarPorTipoConexion(idTipoConexion));
        }

        [HttpGet("Reporte/MaquinaMarca")]
        public async Task<IActionResult> MaquinasPorMarca()
        {
            return Ok(db.MaquinasPorMarca());
        }

        [HttpGet("Reporte/TipoConexion")]
        public async Task<IActionResult> MaquinasPorTipoConexion()
        {
            return Ok(db.MaquinasPorTipoConexion());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Maquina item)
        {
            db.Create(item);
            return Created("Created", true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] Maquina item, int id)
        {
            db.Update(item);
            return Created("Created", true);
        }

        [HttpPut("alterno")]
        public async Task<IActionResult> UpdateMaquina([FromBody] Maquina item)
        {
            db.UpdateMaquina(item);
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
