using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models_core
{
    public class Moneda
    {
        public int id { get; set; }
        public String nombre { get; set; }
        public String simbolo { get; set; }
        public String codIso { get; set; }
        public int estado { get; set; }
        public DateTime ultimaActualizacion { get; set; }

        public Moneda()
        {
            this.id = 1;
            this.nombre = "";
            this.simbolo = "";
            this.codIso = "";
            this.estado = 1;
            this.ultimaActualizacion = DateTime.Now;
        }
    }
}
