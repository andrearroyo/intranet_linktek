using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models_core
{
    public class PaqueteSistema
    {
        public int idPaqueteSistema { get; set; }
        public int idPaquete { get; set; }
        public int idSistema { get; set; }
        public int estado { get; set; }


        //para el join
        public string nombre_paquete { get; set; }
        public string nombre_sistema { get; set; }
        public string version_sistema { get; set; }

        public PaqueteSistema()
        {
            this.idPaqueteSistema = 0;
            this.idPaquete = 0;
            this.idSistema = 0;
            this.estado = 0;
            this.nombre_paquete = "";
            this.nombre_sistema = "";
            this.version_sistema = "";
        }
    }
}
