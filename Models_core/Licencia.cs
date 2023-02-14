using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models_core
{
    public class Licencia
    {
        public int idLicencia { get; set; }
        public int idSala { get; set; }
        public int idPaquete { get; set; }
        public int idSistema { get; set; }
        public DateTime fecha_inic { get; set; }
        public DateTime fecha_fin { get; set; }
        public DateTime fecha_plazo { get; set; }
        public string cantidad_dias { get; set; }
        public string cantidad_free { get; set; }
        public int estado { get; set; }
        public int tipo { get; set; }

        //join
        public string nombrePaquete { get; set; }
        public string nombreSala{ get; set; }
        public string mensaje { get; set; }

        public Licencia()
        {
            this.idLicencia = 0;
            this.idSala = 0;
            this.idPaquete = 0;
            this.idSistema = 0;
            this.fecha_inic = DateTime.Now;
            this.fecha_fin = DateTime.Now.AddDays(30);
            this.cantidad_dias = "30";
            this.cantidad_free = "5";
            this.estado = 1;
            this.tipo = 1;
            this.nombrePaquete = "--";
            this.nombreSala = "--";
            this.mensaje = "--";
        }
    }

    public class LicenciaLocal
    {
        public string sistema { get; set; }
        public string fecha_inicial { get; set; }
        public string fecha_final { get; set; }
        public string cantidad_dias { get; set; }
        public string cantidad_free { get; set; }
        public string restantes { get; set; }
        public string restantes_free { get; set; }
        public string estado { get; set; }
        public string mensaje { get; set; }
        public string tipo { get; set; }

        public LicenciaLocal()
        {
            this.sistema = "";
            this.fecha_inicial = "";
            this.fecha_final = "";
            this.cantidad_dias = "";
            this.cantidad_free = "";
            this.restantes = "";
            this.restantes_free = "";
            this.estado = "";
            this.mensaje = "";
            this.tipo = "";
        }

    }


}
