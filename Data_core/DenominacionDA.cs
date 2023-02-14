using System.Data.SqlClient;
using Models_core;

namespace Data_core
{
    public class DenominacionDA
    {
        string _conexion = string.Empty;
        public DenominacionDA(string cadena)
        {
            Connection.conexion = (String.IsNullOrEmpty(Connection.conexion)) ? cadena : Connection.conexion;
            _conexion = Connection.conexion;
        }
        public List<Denominacion> GetAllDenominacion()
        {
            List<Denominacion> lista = new List<Denominacion>();

            try
            {
                string consulta = @"SELECT idDenominacion, idMoneda, valor, estado FROM dbo.Denominacion (NOLOCK)";

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
                                var item = new Denominacion
                                {
                                    id = ManejaNulos.ManageNullInteger(dr["idDenominacion"]),
                                    idmoneda = ManejaNulos.ManageNullInteger(dr["idMoneda"]),
                                    valor = ManejaNulos.ManageNullDecimal(dr["valor"]),
                                    estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                                };
                                lista.Add(item);
                            }

                        }
                        else //No existen datos
                        {
                            lista = new List<Denominacion>();
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
        public Denominacion GetDenominacionId(int id)
        {
            Denominacion item = new Denominacion();

            try
            {
                string consulta = @"SELECT idDenominacion, idMoneda, valor, estado FROM dbo.Denominacion (NOLOCK) 
                                    where idDenominacion = @idDenominacion";

                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@idDenominacion", id);
                    using (var dr = query.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                item = new Denominacion
                                {
                                    id = ManejaNulos.ManageNullInteger(dr["idDenominacion"]),
                                    idmoneda = ManejaNulos.ManageNullInteger(dr["idMoneda"]),
                                    valor = ManejaNulos.ManageNullDecimal(dr["valor"]),
                                    estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                                };
                            }
                        }
                        else //No existen datos
                        {
                            item = new Denominacion();
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
        public Boolean Create(Denominacion item)
        {
            Boolean estado = false;

            string consulta = @"
                    Insert into Denominacion (idDenominacion, idMoneda, valor, estado)
                    values (@idDenominacion, @idMoneda, @valor, @estado)";

            try
            {

                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@idDenominacion", Guid.NewGuid().ToString());
                    query.Parameters.AddWithValue("@idMoneda", item.idmoneda);
                    query.Parameters.AddWithValue("@valor", item.valor);
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
        public Boolean Update(Denominacion item)
        {
            Boolean estado = false;

            string consulta = @"
                    Update Denominacion
                            idMoneda = @idMoneda,
                            valor = @valor,
                            estado = @estado
                    WHERE idDenominacion = @idDenominacion";

            try
            {

                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@idDenominacion", item.id);
                    query.Parameters.AddWithValue("@idMoneda", item.idmoneda);
                    query.Parameters.AddWithValue("@valor", item.valor);
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

            string consulta = @" Delete from Denominacion WHERE idDenominacion = @idDenominacion";

            try
            {
                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@idDenominacion", id);

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
