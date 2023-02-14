using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Models_Alertas
{
    public class Alerta
    {

        public Int64 id { get; set; }
        public int tipo { get; set; }
        public int sala { get; set; }
        public int sistema { get; set; }
        public DateTime fecha { get; set; }
        public string tabla { get; set; }
        public string mensajeTotal { get; set; }
        public int estado { get; set; }

        public Alerta()
        {
            this.id = 0;
            this.tipo = 0;
            this.sala = 0;
            this.sistema= 0;
            this.fecha = DateTime.Now;
            this.tabla = string.Empty;
            this.mensajeTotal = string.Empty;
            this.estado= 1;
        }

    }
}