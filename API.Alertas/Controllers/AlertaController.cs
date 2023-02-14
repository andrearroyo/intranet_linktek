using Data.Alertas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models_Alertas;

namespace API.Alertas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlertaController : ControllerBase
    {
		private AlertaDA db;

		public AlertaController(IConfiguration config)
		{
			db = new AlertaDA(config.GetConnectionString("conexionSql"));
		}

		[HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(db.GetAll());
        }

        [HttpGet("sala/{sala}")]
        public async Task<IActionResult> GetAllSala(int sala)
        {
            return Ok(db.GetAllSala(sala));
        }

		[HttpGet("sala/{sala}/{fecha}")]
		public async Task<IActionResult> GetAllSalaFecha(int sala, string fecha)
		{
            string[] date = fecha.Split("-");
            DateTime fechaConsulta = new DateTime(Convert.ToInt32(date[2].ToString()), Convert.ToInt32(date[1].ToString()), Convert.ToInt32(date[0].ToString()));
			return Ok(db.GetAllSalaFecha(sala, fechaConsulta));
		}

		[HttpGet("tipo/{tipo}")]
		public async Task<IActionResult> GetAllTipo(int tipo)
		{
			return Ok(db.GetAllTipo(tipo));
		}

		[HttpGet("tipo_sala/{tipo}/{sala}")]
		public async Task<IActionResult> GetAllTipoSala(int tipo, int sala)
		{
			return Ok(db.GetAllTipoSala(tipo, sala));
		}

		[HttpGet("tipo_fecha/{tipo}/{fecha}")]
		public async Task<IActionResult> GetAllTipoFecha(int tipo, string fecha)
		{
			string[] date = fecha.Split("-");
			DateTime fechaConsulta = new DateTime(Convert.ToInt32(date[2].ToString()), Convert.ToInt32(date[1].ToString()), Convert.ToInt32(date[0].ToString()));
			return Ok(db.GetAllTipoFecha(tipo, fechaConsulta));
		}

		[HttpGet("tipo_sala_fecha/{tipo}/{sala}/{fecha}")]
		public async Task<IActionResult> GetAllTipoSalaFecha(int tipo, int sala, string fecha)
		{
			string[] date = fecha.Split("-");
			DateTime fechaConsulta = new DateTime(Convert.ToInt32(date[2].ToString()), Convert.ToInt32(date[1].ToString()), Convert.ToInt32(date[0].ToString()));
			return Ok(db.GetAllTipoSalaFecha(tipo, sala, fechaConsulta));
		}

		[HttpGet("sistema/{sistema}")]
		public async Task<IActionResult> GetAllSistema(int sistema)
		{
			return Ok(db.GetAllTipo(sistema));
		}
		[HttpGet("sistema_fecha/{sistema}/{fecha}")]
		public async Task<IActionResult> GetAllSistemaFecha(int sistema, string fecha)
		{
			string[] date = fecha.Split("-");
			DateTime fechaConsulta = new DateTime(Convert.ToInt32(date[2].ToString()), Convert.ToInt32(date[1].ToString()), Convert.ToInt32(date[0].ToString()));
			return Ok(db.GetAllSistemaFecha(sistema, fechaConsulta));
		}

		[HttpGet("sala_sistema/{sala}/{sistema}")]
		public async Task<IActionResult> GetAllSalaSistema(int sala, int sistema)
		{
			return Ok(db.GetAllSalaSistema(sala, sistema));
		}

		[HttpGet("sala_sistema_fecha/{sala}/{sistema}/{fecha}")]
		public async Task<IActionResult> GetAllSalaSistemaFecha(int sala, int sistema, string fecha)
		{
			string[] date = fecha.Split("-");
			DateTime fechaConsulta = new DateTime(Convert.ToInt32(date[2].ToString()), Convert.ToInt32(date[1].ToString()), Convert.ToInt32(date[0].ToString()), Convert.ToInt32(date[3].ToString()), Convert.ToInt32(date[4].ToString()), Convert.ToInt32(date[5].ToString()));
			return Ok(db.GetAllSalaSistemaFecha(sala, sistema, fechaConsulta));
		}

        [HttpPost]
        public async Task<IActionResult> Create(Alerta item)
        {
            if (item == null)
                return BadRequest();
            var rpta =  db.Create(item);
            return Created("Created", rpta);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Alerta item, int id)
        {
            if (item == null)
                return BadRequest();
            item.id = id;
			var rpta = db.Update(item);
            return Created("Updated", rpta);
        }
    }
}
