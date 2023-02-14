using System.Data.SqlClient;
using Models_core;

namespace Data_core
{
    public class TipoConexionDA
    {
        string _conexion = string.Empty;

        public TipoConexionDA(string cadena)
        {
            Connection.conexion = (String.IsNullOrEmpty(Connection.conexion)) ? cadena : Connection.conexion;
            _conexion = Connection.conexion;
        }
        public List<TipoConexion> GetAllTipoConexion()
        {
            List<TipoConexion> lista = new List<TipoConexion>();

            try
            {
                string consulta = @"select idTipoConexion, nombre, estado from TipoConexion (NOLOCK)";

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
                                var item = new TipoConexion
                                {
                                    idTipoConexion = ManejaNulos.ManageNullInteger(dr["idTipoConexion"]),
                                    nombre = ManejaNulos.ManageNullStr(dr["nombre"]),
                                    estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                                };
                                lista.Add(item);
                            }
                        }
                        else //No existen datos
                        {
                            lista = new List<TipoConexion>();
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
        public TipoConexion GetTipoMaquinaId(string id)
        {
            TipoConexion item = new TipoConexion();

            try
            {
                string consulta = @"select idTipoConexion, nombre, estado from TipoConexion (NOLOCK)
                                    where idTipoConexion = @idTipoConexion";

                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@idTipoConexion", id);
                    using (var dr = query.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                item = new TipoConexion
                                {
                                    idTipoConexion = ManejaNulos.ManageNullInteger(dr["idTipoMaquina"]),
                                    nombre = ManejaNulos.ManageNullStr(dr["nombre"]),
                                    estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                                };
                            }
                        }
                        else //No existen datos
                        {
                            item = new TipoConexion();
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
        public Boolean Create(TipoConexion item)
        {
            Boolean estado = false;

            string consulta = @"
                    Insert into TipoConexion (nombre, estado)
                    values (@nombre, @estado)";

            try
            {

                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@idTipoConexion", item.idTipoConexion);
                    query.Parameters.AddWithValue("@nombre", item.nombre);
                    query.Parameters.AddWithValue("@estado", item.estado);

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
        public Boolean Update(TipoConexion item)
        {
            Boolean estado = false;

            string consulta = @"
                    Update TipoConexion
                            nombre = @nombre,
                            estado = @estado
                    WHERE idTipoConexion = @idTipoConexion";

            try
            {

                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@idTipoConexion", item.idTipoConexion);
                    query.Parameters.AddWithValue("@nombre", item.nombre);
                    query.Parameters.AddWithValue("@estado", item.estado);

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

            string consulta = @" Delete from TipoConexion WHERE idTipoConexion = @idTipoConexion";

            try
            {
                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@idTipoConexion", id);

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
