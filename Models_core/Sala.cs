using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models_core
{
    public class Sala
    {
        public int idConsorcio { get; set; }
        public int idEmpresa { get; set; }
        public int idSala { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string ubigeo { get; set; }
        public int estado { get; set; }
        public string autogenerado { get; set; }
        public string llave { get; set; }

        //para join
        public string nombreConsorcio{ get; set; }
        public string nombreEmpresa { get; set; }

        public Sala()
        {
            this.idConsorcio = 0;
            this.idEmpresa = 0;
            this.idSala = 0;
            this.nombre = "";
            this.direccion = "";
            this.ubigeo = "";
            this.estado = -1;
            this.autogenerado = "";
            this.llave = "";
            this.nombreConsorcio = "";
            this.nombreEmpresa = "";
        }
    }
}
