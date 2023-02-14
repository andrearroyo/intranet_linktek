using Models_core;
using System.Data.SqlClient;

namespace Data_core
{
    public class MarcaDA
    {
        string _conexion = string.Empty;

        public MarcaDA(string cadena)
        {
            Connection.conexion = (String.IsNullOrEmpty(Connection.conexion)) ? cadena : Connection.conexion;
            _conexion = Connection.conexion;
        }

        public List<Marca> GetAllMarca()
        {
            List<Marca> lista = new List<Marca>();

            try
            {
                string consulta = @"SELECT idMarca, nombre, sigla, estado, imagen FROM dbo.Marca (NOLOCK)
                                    order by nombre asc";

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
                                var item = new Marca
                                {
                                    id = ManejaNulos.ManageNullInteger(dr["idMarca"]),
                                    nombre = ManejaNulos.ManageNullStr(dr["nombre"]),
                                    sigla = ManejaNulos.ManageNullStr(dr["sigla"]),
                                    estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                                    imagen = ManejaNulos.ManageNullStr(dr["imagen"]),
                                };
                                lista.Add(item);
                            }
                        }
                        else //No existen datos
                        {
                            lista = new List<Marca>();
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

        public Marca GetMarcaId(int id)
        {
            Marca item = new Marca();

            try
            {
                string consulta = @"SELECT idMarca, nombre, sigla, estado, imagen 
                                    FROM dbo.Marca (NOLOCK) where idMarca = @idMarca";

                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@idMarca", id);
                    using (var dr = query.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                item = new Marca
                                {
                                    id = ManejaNulos.ManageNullInteger(dr["idMarca"]),
                                    nombre = ManejaNulos.ManageNullStr(dr["nombre"]),
                                    sigla = ManejaNulos.ManageNullStr(dr["sigla"]),
                                    estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                                    imagen = ManejaNulos.ManageNullStr(dr["imagen"]),
                                };
                            }
                        }
                        else //No existen datos
                        {
                            item = new Marca();
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

        public Boolean Create(Marca item)
        {
            Boolean estado = false;

            string consulta = @"
                    Insert into Marca (nombre, sigla, estado, imagen)
                    values (@nombre, @sigla, @estado, @imagen)";

            try
            {

                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@nombre", item.nombre);
                    query.Parameters.AddWithValue("@sigla", item.sigla);
                    query.Parameters.AddWithValue("@estado", item.estado);
                    query.Parameters.AddWithValue("@imagen", item.imagen);

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

        public Boolean Update(Marca item)
        {
            Boolean estado = false;

            string consulta = @"
                    Update Marca set nombre = @nombre,
                            sigla = @sigla,
                            estado = @estado,
                            imagen = @imagen
                    WHERE id = @id
                                        ";

            try
            {

                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@id", item.id);
                    query.Parameters.AddWithValue("@nombre", item.nombre);
                    query.Parameters.AddWithValue("@sigla", item.sigla);
                    query.Parameters.AddWithValue("@estado", item.estado);
                    query.Parameters.AddWithValue("@imagen", item.imagen);

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

            string consulta = @" Delete from Marca WHERE id = @id";

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
