using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoraController : ControllerBase
    {

        protected class Horas
        {
            public DateTime fecha { get; set; }
            public int dia { get; set; }
            public int mes { get; set; }
            public int año { get; set; }
            public int hora { get; set; }
            public int minuto { get; set; }
            public int segundo { get; set; }
            public string tt { get; set; }
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            DateTime fecha = DateTime.Now;

            Horas _item = new Horas()
            {
                fecha = fecha,
                dia = fecha.Day,
                mes = fecha.Month,
                año = fecha.Year,
                hora = fecha.Hour,
                minuto = fecha.Minute,
                segundo = fecha.Second,
                tt = fecha.ToString("tt")
            };

            return Ok(_item);
        }
    }
}
