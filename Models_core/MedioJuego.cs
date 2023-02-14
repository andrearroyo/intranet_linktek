using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models_core
{
    public class MedioJuego
    {
        public int id { get; set; }
        public String nombre { get; set; }
        public int estado { get; set; }
        public DateTime ultimaActualizacion { get; set; }

        public MedioJuego()
        {
            this.id = 1;
            this.nombre = "";
            this.estado = 1;
            this.ultimaActualizacion = DateTime.Now;
        }
    }
}
