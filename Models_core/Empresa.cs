using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models_core
{
    public class Empresa
    {
        public int idConsorcio { get; set; }
        public int idEmpresa { get; set; }
        public string nombre { get; set; }
        public string ruc { get; set; }
        public string direccion { get; set; }
        public int estado { get; set; }


        //Solo para join
        public string nombreConsorcio { get; set; }

        public Empresa()
        {
            this.idConsorcio = 0;
            this.idEmpresa = 0;
            this.nombre = "";
            this.ruc = "";
            this.direccion = "";
            this.estado = 1;
            this.nombreConsorcio = "";
        }
    }
}
