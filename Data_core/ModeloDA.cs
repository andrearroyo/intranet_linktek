using System.Data.SqlClient;
using Models_core;

namespace Data_core
{
    public class ModeloDA
    {
        string _conexion = string.Empty;

        public ModeloDA(string cadena)
        {
            Connection.conexion = (String.IsNullOrEmpty(Connection.conexion)) ? cadena : Connection.conexion;
            _conexion = Connection.conexion;
        }
        public List<Modelo> GetAllModelo()
        {
            List<Modelo> lista = new List<Modelo>();

            try
            {
                string consulta = @"SELECT MO.idModelo, MO.idMarca, MO.nombre, MO.sigla, MO.estado, MA.nombre as 'marca' FROM dbo.Modelo (NOLOCK) MO
                                    inner join Marca MA  ON MO.idMarca = MA.idMarca";

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
                                var item = new Modelo
                                {
                                    id = ManejaNulos.ManageNullInteger(dr["idModelo"]),
                                    idMarca = ManejaNulos.ManageNullInteger(dr["idMarca"]),
                                    nombre = ManejaNulos.ManageNullStr(dr["nombre"]),
                                    sigla = ManejaNulos.ManageNullStr(dr["sigla"]),
                                    estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                                    marca = ManejaNulos.ManageNullStr(dr["marca"]),
                                };
                                lista.Add(item);
                            }
                        }
                        else //No existen datos
                        {
                            lista = new List<Modelo>();
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
        public Modelo GetModeloId(string id)
        {
            Modelo item = new Modelo();

            try
            {
                string consulta = @"SELECT MO.idModelo, MO.idMarca, MO.nombre, MO.sigla, MO.estado, MA.nombre as 'marca' FROM dbo.Modelo (NOLOCK) MO
                                    inner join Marca MA  ON MO.idMarca = MA.idMarca 
                                    where idModelo = @idModelo";

                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@idModelo", id);
                    using (var dr = query.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                item = new Modelo
                                {
                                    id = ManejaNulos.ManageNullInteger(dr["idModelo"]),
                                    idMarca = ManejaNulos.ManageNullInteger(dr["idMarca"]),
                                    nombre = ManejaNulos.ManageNullStr(dr["nombre"]),
                                    sigla = ManejaNulos.ManageNullStr(dr["sigla"]),
                                    estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                                };
                            }
                        }
                        else //No existen datos
                        {
                            item = new Modelo();
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
        public List<Modelo> GetAllModeloByMarca(string idMarca)
        {
            List<Modelo> lista = new List<Modelo>();

            try
            {
                string consulta = @"SELECT idModelo, mo.idMarca, mo.nombre, mo.sigla, mo.estado, m.nombre AS 'marca'
                                    FROM dbo.Modelo (NOLOCK) mo
                                    INNER JOIN dbo.Marca m (NOLOCK) ON m.idMarca = mo.idMarca
                                    WHERE mo.idMarca = @idMarca";

                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@idMarca", idMarca);
                    using (var dr = query.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item = new Modelo
                                {
                                    id = ManejaNulos.ManageNullInteger(dr["idModelo"]),
                                    idMarca = ManejaNulos.ManageNullInteger(dr["idMarca"]),
                                    nombre = ManejaNulos.ManageNullStr(dr["nombre"]),
                                    sigla = ManejaNulos.ManageNullStr(dr["sigla"]),
                                    estado = ManejaNulos.ManageNullInteger(dr["estado"]),

                                    marca = ManejaNulos.ManageNullStr(dr["marca"]),
                                };
                                lista.Add(item);
                            }
                        }
                        else //No existen datos
                        {
                            lista = new List<Modelo>();
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
        public Boolean Create(Modelo item)
        {
            Boolean estado = false;

            string consulta = @"
                    Insert into Modelo (idMarca, nombre, sigla, estado)
                    values (@idMarca, @nombre, @sigla, @estado)";

            try
            {

                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@idMarca", item.idMarca);
                    query.Parameters.AddWithValue("@nombre", item.nombre);
                    query.Parameters.AddWithValue("@sigla", item.sigla);
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
        public Boolean Update(Modelo item)
        {
            Boolean estado = false;

            string consulta = @"
                    Update Modelo set idMarca = @idMarca,
                            nombre = @nombre,
                            sigla = @sigla,
                            estado = @estado
                    WHERE idModelo = @idModelo";

            try
            {

                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@idModelo", item.id);
                    query.Parameters.AddWithValue("@idMarca", item.idMarca);
                    query.Parameters.AddWithValue("@nombre", item.nombre);
                    query.Parameters.AddWithValue("@sigla", item.sigla);
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
        public Boolean Delete(string id)
        {
            Boolean estado = false;

            string consulta = @" Delete from Modelo WHERE idModelo = @idModelo";

            try
            {
                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@idModelo", id);

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
