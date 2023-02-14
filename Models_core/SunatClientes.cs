using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models_core
{
    public class SunatClientes
    {
        public int id { get; set; }
        public int idSala { get; set; }
        public string ip { get; set; }
        public string puertoEconomico { get; set; }
        public string puertoTecnico { get; set; }
        public string usuario { get; set; }
        public string password { get; set; }
        public string semilla { get; set; }
        public string vector { get; set; }
        public string segundos { get; set; }
        public int estado { get; set; }
        public DateTime fecha { get; set; }
        public int tipo { get; set; }
        public string sala { get; set; }
    }
}
