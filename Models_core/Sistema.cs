using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models_core
{
    public class Sistema
    {
        public int idSistema { get; set; }
        public string nombre { get; set; }
        public string version { get; set; }
        public DateTime fecha_compilado { get; set; }
        public int numero_registros { get; set; }
        public int estado { get; set; }

        public Sistema()
        {
            this.idSistema = 0;
            this.nombre = "";
            this.version = "";
            this.fecha_compilado = DateTime.Now;
            this.numero_registros = 0;
            this.estado = -1;
        }
    }
}
