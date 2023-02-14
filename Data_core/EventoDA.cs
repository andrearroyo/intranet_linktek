using System.Data.SqlClient;
using Models_core;

namespace Data_core
{
    public class EventoDA
    {
        string _conexion = string.Empty;

        public EventoDA(string cadena)
        {
            Connection.conexion = (String.IsNullOrEmpty(Connection.conexion)) ? cadena : Connection.conexion;
            _conexion = Connection.conexion;
        }
        public List<Evento> GetAllEvento()
        {
            List<Evento> lista = new List<Evento>();

            try
            {
                string consulta = @"select id, nombre, tipoevento, prioridad, estado, repetitivo, enviomincetur, enviolinktek from evento (nolock)";

                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.CommandTimeout = 0;
                    using (var dr = query.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item = new Evento
                                {
                                    id = ManejaNulos.ManageNullInteger(dr["id"]),
                                    nombre = ManejaNulos.ManageNullStr(dr["nombre"]),
                                    tipoevento = ManejaNulos.ManageNullInteger(dr["tipoevento"]),
                                    prioridad = ManejaNulos.ManageNullInteger(dr["prioridad"]),
                                    estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                                    repetitivo = ManejaNulos.ManageNullInteger(dr["repetitivo"]),
                                    enviomincetur = ManejaNulos.ManageNullInteger(dr["enviomincetur"]),
                                    enviolinktek = ManejaNulos.ManageNullInteger(dr["enviolinktek"]),
                                };
                                lista.Add(item);
                            }
                        }
                        else //No existen datos
                        {
                            lista = new List<Evento>();
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                lista = null;
            }
            return lista;

        }
        public Evento GetEventoId(string id)
        {
            Evento item = new Evento();

            try
            {
                string consulta = @"select id, nombre, tipoevento, prioridad, estado, repetitivo, enviomincetur, enviolinktek from evento (nolock)
                                    where id = @id";

                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@id", id);
                    using (var dr = query.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                item = new Evento
                                {
                                    id = ManejaNulos.ManageNullInteger(dr["id"]),
                                    nombre = ManejaNulos.ManageNullStr(dr["nombre"]),
                                    tipoevento = ManejaNulos.ManageNullInteger(dr["tipoevento"]),
                                    prioridad = ManejaNulos.ManageNullInteger(dr["prioridad"]),
                                    estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                                    repetitivo = ManejaNulos.ManageNullInteger(dr["repetitivo"]),
                                    enviomincetur = ManejaNulos.ManageNullInteger(dr["enviomincetur"]),
                                    enviolinktek = ManejaNulos.ManageNullInteger(dr["enviolinktek"]),
                                };
                            }
                        }
                        else //No existen datos
                        {
                            item = new Evento();
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                item = null;
            }
            return item;

        }
        public Boolean Create(Evento item)
        {
            Boolean estado = false;

            string consulta = @"
                    Insert into Evento (id, nombre, tipoevento, prioridad,estado, repetitivo, enviomincetur, enviolinktek)
                    values (@id, @nombre, @tipoevento, @prioridad,@estado, @repetitivo, @enviomincetur, @enviolinktek)";

            try
            {
                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@id", Guid.NewGuid().ToString());
                    query.Parameters.AddWithValue("@nombre", item.nombre);
                    query.Parameters.AddWithValue("@tipoevento", item.tipoevento);
                    query.Parameters.AddWithValue("@prioridad", item.prioridad);
                    query.Parameters.AddWithValue("@estado", item.estado);
                    query.Parameters.AddWithValue("@repetitivo", item.repetitivo);
                    query.Parameters.AddWithValue("@enviomincetur", item.enviomincetur);
                    query.Parameters.AddWithValue("@enviolinktek", item.enviolinktek);

                    using (var dr = query.ExecuteReader())
                    {
                        estado = true;
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                estado = false;
            }
            return estado;
        }
        public Boolean Update(Evento item)
        {
            Boolean estado = false;

            string consulta = @"
                    Update Evento set
                            nombre = @nombre,
                            tipoevento = @tipoevento,
                            prioridad = @prioridad,
                            estado = @estado,
                            repetitivo = @repetitivo,
                            enviomincetur = @enviomincetur,
                            enviolinktek = @enviolinktek
                    WHERE id = @id";

            try
            {

                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@id", Guid.NewGuid().ToString());
                    query.Parameters.AddWithValue("@nombre", item.nombre);
                    query.Parameters.AddWithValue("@tipoevento", item.tipoevento);
                    query.Parameters.AddWithValue("@prioridad", item.prioridad);
                    query.Parameters.AddWithValue("@estado", item.estado);
                    query.Parameters.AddWithValue("@repetitivo", item.repetitivo);
                    query.Parameters.AddWithValue("@enviomincetur", item.enviomincetur);
                    query.Parameters.AddWithValue("@enviolinktek", item.enviolinktek);

                    using (var dr = query.ExecuteReader())
                    {
                        estado = true;
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                estado = false;
            }
            return estado;
        }
        public Boolean Delete(int id)
        {
            Boolean estado = false;

            string consulta = @" Delete from Evento WHERE id = @id";

            try
            {
                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@id", id);

                    using (var dr = query.ExecuteReader())
                    {
                        estado = true;
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                estado = false;
            }
            return estado;
        }

    }
}
