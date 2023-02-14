using System.Data.SqlClient;
using Models_core;

namespace Data_core
{
    public class MonedaDA
    {
        string _conexion = string.Empty;

        public MonedaDA(string cadena)
        {
            Connection.conexion = (String.IsNullOrEmpty(Connection.conexion)) ? cadena : Connection.conexion;
            _conexion = Connection.conexion;
        }
        public List<Moneda> GetAllMoneda()
        {
            List<Moneda> lista = new List<Moneda>();

            try
            {
                string consulta = @"SELECT idMoneda, nombre, simbolo, codIso, estado FROM dbo.Moneda (NOLOCK)";

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
                                var item = new Moneda
                                {
                                    id = ManejaNulos.ManageNullInteger(dr["idMoneda"]),
                                    nombre = ManejaNulos.ManageNullStr(dr["nombre"]),
                                    simbolo = ManejaNulos.ManageNullStr(dr["simbolo"]),
                                    codIso = ManejaNulos.ManageNullStr(dr["codIso"]),
                                    estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                                };
                                lista.Add(item);
                            }
                        }
                        else //No existen datos
                        {
                            lista = new List<Moneda>();
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
        public Moneda GetMonedaId(string id)
        {
            Moneda item = new Moneda();

            try
            {
                string consulta = @"SELECT idMoneda, nombre, simbolo, codIso, estado FROM dbo.Moneda (NOLOCK) 
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
                                item = new Moneda
                                {
                                    id = ManejaNulos.ManageNullInteger(dr["idMoneda"]),
                                    nombre = ManejaNulos.ManageNullStr(dr["nombre"]),
                                    simbolo = ManejaNulos.ManageNullStr(dr["simbolo"]),
                                    codIso = ManejaNulos.ManageNullStr(dr["codIso"]),
                                    estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                                };
                            }
                        }
                        else //No existen datos
                        {
                            item = new Moneda();
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

        public Boolean Create(Moneda item)
        {
            Boolean estado = false;

            string consulta = @"
                    Insert into Moneda (nombre, simbolo, codIso, estado)
                    values (@nombre, @simbolo, @codIso, @estado)";

            try
            {

                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@nombre", item.nombre);
                    query.Parameters.AddWithValue("@simbolo", item.simbolo);
                    query.Parameters.AddWithValue("@codIso", item.codIso);
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
        public Boolean Update(Moneda item)
        {
            Boolean estado = false;

            string consulta = @"
                    Update Moneda set
                            nombre = @nombre,
                            simbolo = @simbolo,
                            codIso = @codIso,
                            estado = @estado
                    WHERE idModelo = @idModelo";

            try
            {

                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@idMoneda", item.id);
                    query.Parameters.AddWithValue("@nombre", item.nombre);
                    query.Parameters.AddWithValue("@simbolo", item.simbolo);
                    query.Parameters.AddWithValue("@codIso", item.codIso);
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

            string consulta = @" Delete from Moneda WHERE idMoneda = @idMoneda";

            try
            {
                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@idMoneda", id);

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
