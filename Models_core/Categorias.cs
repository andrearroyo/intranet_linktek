using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models_core
{
    public class Categorias
    {
        
    }

    public class lstEstados
    {
        public int id { get; set; }
        public string nombre { get; set; }

        public List<lstEstados> getEstados()
        {
            List<lstEstados> lista = new List<lstEstados>()
                {
                    new lstEstados
                    {
                        id = 1,
                        nombre = "Activo"
                    },
                    new lstEstados
                    {
                        id = 0,
                        nombre = "Inactivo"
                    },
                };

            return lista;
        }


    }

    public class tipoPaquete
    {
        public int id { get; set; }
        public string nombre { get; set; }

        public List<tipoPaquete> getTipoPaquete()
        {
            List<tipoPaquete> lista = new List<tipoPaquete>()
                {
                    new tipoPaquete
                    {
                        id = 1,
                        nombre = "Normal"
                    },
                    new tipoPaquete
                    {
                        id = 2,
                        nombre = "Especial"
                    },
                    new tipoPaquete
                    {
                        id = 3,
                        nombre = "Único"
                    },
                };
            return lista;
        }


    }

}
