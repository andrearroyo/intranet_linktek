using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models_core
{
    public class Formula
    {
        public int id { get; set; }
        public String formulaeconomica { get; set; }
        public String CoinIn { get; set; }
        public String CoinOut { get; set; }
        public String CancelCredits { get; set; }
        public String Jackpot { get; set; }
        public String Reserva1 { get; set; }
        public int estado { get; set; }
        public DateTime ultimaActualizacion { get; set; }

        public Formula()
        {
            this.id = 1;
            this.formulaeconomica = "";
            CoinIn = "";
            CoinOut = "";
            CancelCredits = "";
            Jackpot = "";
            Reserva1 = "";
            this.estado = 1;
            this.ultimaActualizacion = DateTime.Now;
        }
    }
}
