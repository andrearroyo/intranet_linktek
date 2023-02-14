using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models_core
{
    public class Maquina
    {
        public int id { get; set; }
        public int idSala { get; set; }
        public String codigoAlterno { get; set; }
        public String codigoInterno { get; set; }
        public String nroSerie { get; set; }
        public int idMarca { get; set; }
        public int idModelo { get; set; }
        public int idJuego { get; set; }
        public decimal token { get; set; }
        public String ip { get; set; }
        public int hopper { get; set; }
        public int idMedioJuego { get; set; }
        public String codIso { get; set; }
        public int idDenominacion { get; set; }
        public int idMoneda { get; set; }
        public int idTipoMaquina { get; set; }
        public int posx { get; set; }
        public int posy { get; set; }
        public int idFormula { get; set; }
        public int idFormulaEconomica { get; set; }
        public decimal porcTeorico { get; set; }
        public String nuc { get; set; }
        public String nuid { get; set; }
        public int estado { get; set; }
        public int servidor { get; set; }
        public int segmento { get; set; }
        public int tipoconexion { get; set; }
        public int retirotemporal { get; set; }
        public DateTime fechaCreado { get; set; }
        public DateTime fechaModificado { get; set; }
        public int piso { get; set; }

        public string juego { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }

        public Maquina()
        {
            this.id = 1;
            this.idSala = 1;
            this.codigoAlterno = "";
            this.codigoInterno = "";
            this.nroSerie = "";
            this.idMarca = 1;
            this.idModelo = 1;
            this.idJuego = 1;
            this.token = 0.01M;
            this.ip = "";
            this.hopper = 0;
            this.idMedioJuego = 1;
            this.codIso = "";
            this.idDenominacion = 1;
            this.idMoneda = 1;
            this.idTipoMaquina = 1;
            this.posx = 0;
            this.posy = 0;
            this.idFormula = 1;
            this.idFormulaEconomica = 1;
            this.porcTeorico = 88;
            this.nuc = "";
            this.nuid = "";
            this.estado = 1;
            this.servidor = 1;
            this.segmento = 1;
            this.tipoconexion = 1;
            this.retirotemporal = 1;
            this.fechaCreado = DateTime.Now;
            this.fechaModificado = DateTime.Now;
            this.piso = 1;
        }
    }
}
