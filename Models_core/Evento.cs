using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models_core
{
    public class Evento
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int tipoevento { get; set; }
        public int prioridad { get; set; }
        public int estado { get; set; }
        public int repetitivo { get; set; }
        public int enviomincetur { get; set; }
        public int enviolinktek { get; set; }

        public Evento()
        {
            id = 0;
            nombre = "";
            tipoevento = 0; 
            prioridad = 0;
            estado = 0;
            repetitivo = 0;
            enviomincetur = 0;
            enviolinktek = 0;
        }

    }
}
