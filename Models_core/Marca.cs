using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models_core
{
    public class Marca
    {
        public int id { get; set; }
        public String nombre { get; set; }
        public String sigla { get; set; }
        public int estado { get; set; }
        public string imagen { get; set; }
        public DateTime ultimaActualizacion { get; set; }

        public Marca()
        {
            this.id = 1;
            this.nombre = "";
            this.sigla = "";
            this.estado = 1;
            this.imagen = "";
            this.ultimaActualizacion = DateTime.Now;
        }
    }
}
