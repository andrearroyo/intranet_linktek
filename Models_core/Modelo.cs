using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models_core
{
    public class Modelo
    {
        public int id { get; set; }
        public int idMarca { get; set; }
        public String nombre { get; set; }
        public String sigla { get; set; }
        public int estado { get; set; }
        public DateTime ultimaActualizacion { get; set; }

        public String marca { get; set; }

        public Modelo()
        {
            this.id = 1;
            this.idMarca = 1;
            this.nombre = "";
            this.sigla = "";
            this.estado = 1;
            this.ultimaActualizacion = DateTime.Now;
            this.marca = "";
        }
    }
}
