namespace Models_core
{
    public class Consorcio
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int estado { get; set; }

        public Consorcio()
        {
            this.id = 0;
            this.nombre = "";
            this.estado = 1;
        }
    }
}