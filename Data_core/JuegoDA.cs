using System.Data.SqlClient;
using Models_core;

namespace Data_core
{
    public class JuegoDA
    {
        string _conexion = string.Empty;

        public JuegoDA(string cadena)
        {
            Connection.conexion = (String.IsNullOrEmpty(Connection.conexion)) ? cadena : Connection.conexion;
            _conexion = Connection.conexion;
        }
        public List<Juego> GetAllJuego()
        {
            List<Juego> lista = new List<Juego>();

            try
            {
                string consulta = @"SELECT id,idmarca,nombre,sigla,estado,ultimaActualizacion FROM dbo.Juego (NOLOCK)";

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
                                var item = new Juego
                                {
                                    id = ManejaNulos.ManageNullInteger(dr["id"]),
                                    idmarca = ManejaNulos.ManageNullInteger(dr["idmarca"]),
                                    nombre = ManejaNulos.ManageNullStr(dr["nombre"]),
                                    sigla = ManejaNulos.ManageNullStr(dr["sigla"]),
                                    estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                                    ultimaActualizacion = ManejaNulos.ManageNullDate(dr["ultimaActualizacion"]),
                                };
                                lista.Add(item);
                            }
                        }
                        else //No existen datos
                        {
                            lista = new List<Juego>();
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
        public Juego GetJuegoId(int id)
        {
            Juego item = new Juego();

            try
            {
                string consulta = @"SELECT id,idmarca,nombre,sigla,estado,ultimaActualizacion FROM dbo.Juego (NOLOCK)
                                    where idMoneda = @idMoneda";

                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@idMoneda", id);
                    using (var dr = query.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                item = new Juego
                                {
                                    id = ManejaNulos.ManageNullInteger(dr["idMoneda"]),
                                    idmarca = ManejaNulos.ManageNullInteger(dr["idmarca"]),
                                    nombre = ManejaNulos.ManageNullStr(dr["nombre"]),
                                    sigla = ManejaNulos.ManageNullStr(dr["sigla"]),
                                    estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                                    ultimaActualizacion = ManejaNulos.ManageNullDate(dr["ultimaActualizacion"]),
                                };
                            }
                        }
                        else //No existen datos
                        {
                            item = new Juego();
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
        public Boolean Create(Juego item)
        {
            Boolean estado = false;

            string consulta = @"
                    Insert into Juego (id,idmarca,nombre,sigla,estado,ultimaActualizacion)
                    values (@id,@idmarca,@nombre,@sigla,@estado,@ultimaActualizacion)";

            try
            {

                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@id", Guid.NewGuid().ToString());
                    query.Parameters.AddWithValue("@idmarca", item.idmarca);
                    query.Parameters.AddWithValue("@nombre", item.nombre);
                    query.Parameters.AddWithValue("@sigla", item.sigla);
                    query.Parameters.AddWithValue("@estado", item.estado);
                    query.Parameters.AddWithValue("@ultimaActualizacion", item.ultimaActualizacion);

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
        public Boolean Update(Juego item)
        {
            Boolean estado = false;

            string consulta = @"
                    Update Juego set
                            idmarca = @idmarca,
                            nombre = @nombre,
                            sigla = @sigla,
                            estado = @estado,
                            ultimaActualizacion = @ultimaActualizacion
                    WHERE id = @id";

            try
            {

                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@id", item.id);
                    query.Parameters.AddWithValue("@idmarca", item.idmarca);
                    query.Parameters.AddWithValue("@nombre", item.nombre);
                    query.Parameters.AddWithValue("@sigla", item.sigla);
                    query.Parameters.AddWithValue("@estado", item.estado);
                    query.Parameters.AddWithValue("@ultimaActualizacion", item.ultimaActualizacion);

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

            string consulta = @" Delete from Juego WHERE id = @id";

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
