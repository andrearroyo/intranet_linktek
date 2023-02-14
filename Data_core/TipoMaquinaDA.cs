using System.Data.SqlClient;
using Models_core;

namespace Data_core
{
    public class TipoMaquinaDA
    {
        string _conexion = string.Empty;

        public TipoMaquinaDA(string cadena)
        {
            Connection.conexion = (String.IsNullOrEmpty(Connection.conexion)) ? cadena : Connection.conexion;
            _conexion = Connection.conexion;
        }
        public List<TipoMaquina> GetAllTipoMaquina()
        {
            List<TipoMaquina> lista = new List<TipoMaquina>();

            try
            {
                string consulta = @"SELECT idTipoMaquina, nombre, estado FROM dbo.TipoMaquina (NOLOCK)";

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
                                var item = new TipoMaquina
                                {
                                    id = ManejaNulos.ManageNullInteger(dr["idTipoMaquina"]),
                                    nombre = ManejaNulos.ManageNullStr(dr["nombre"]),
                                    estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                                };
                                lista.Add(item);
                            }
                        }
                        else //No existen datos
                        {
                            lista = new List<TipoMaquina>();
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
        public TipoMaquina GetTipoMaquinaId(string id)
        {
            TipoMaquina item = new TipoMaquina();

            try
            {
                string consulta = @"SELECT idTipoMaquina, nombre, estado FROM dbo.TipoMaquina (NOLOCK)
                                    where idTipoMaquina = @idTipoMaquina";

                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@idTipoMaquina", id);
                    using (var dr = query.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                item = new TipoMaquina
                                {
                                    id = ManejaNulos.ManageNullInteger(dr["idTipoMaquina"]),
                                    nombre = ManejaNulos.ManageNullStr(dr["nombre"]),
                                    estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                                };
                            }
                        }
                        else //No existen datos
                        {
                            item = new TipoMaquina();
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
        public Boolean Create(TipoMaquina item)
        {
            Boolean estado = false;

            string consulta = @"
                    Insert into TipoMaquina (nombre, estado)
                    values (@nombre, @estado)";

            try
            {

                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.CommandTimeout = 0;
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
        public Boolean Update(TipoMaquina item)
        {
            Boolean estado = false;

            string consulta = @"
                    Update TipoMaquina
                            nombre = @nombre,
                            estado = @estado
                    WHERE idTipoMaquina = @idTipoMaquina";

            try
            {

                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@idTipoMaquina", item.id);
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

            string consulta = @" Delete from TipoMaquina WHERE idTipoMaquina = @idTipoMaquina";

            try
            {
                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@idTipoMaquina", id);

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
