using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models_core
{
    public class Juego
    {
        public int id { get; set; }
        public int idmarca { get; set; }
        public String nombre { get; set; }
        public String sigla { get; set; }
        public int estado { get; set; }
        public DateTime ultimaActualizacion { get; set; }

        public Juego()
        {
            this.id = 1;
            this.idmarca = 1;
            this.nombre = "";
            this.sigla = "";
            this.estado = 1;
            this.ultimaActualizacion = DateTime.Now;
        }
    }
}
