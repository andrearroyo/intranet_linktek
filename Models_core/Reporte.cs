using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models_core
{
    public class Reporte
    {
        public string categoria { get; set; }
        public int valor1 { get; set; }
        public decimal valor2 { get; set; }
        public DateTime valor3 { get; set; }
        public string valor4 { get; set; }

        public Reporte()
        {
            categoria = "";
            valor1 = 0;
            valor2 = 0M;
            valor3 = DateTime.Now;
            valor4 = "";
        }

    }
}
