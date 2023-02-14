using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models_core
{
    public class Denominacion
    {
        public int id { get; set; }
        public int idmoneda { get; set; }
        public decimal valor { get; set; }
        public int estado { get; set; }
        public DateTime ultimaActualizacion { get; set; }

        public Denominacion()
        {
            this.id = 1;
            this.idmoneda = 1;
            this.valor = 0;
            this.estado = 1;
            this.ultimaActualizacion = DateTime.Now;
        }
    }
}
