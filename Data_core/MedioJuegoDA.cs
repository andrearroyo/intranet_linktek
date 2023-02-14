using System.Data.SqlClient;
using Models_core;

namespace Data_core
{
    public class MedioJuegoDA
    {
        string _conexion = string.Empty;

        public MedioJuegoDA(string cadena)
        {
            Connection.conexion = (String.IsNullOrEmpty(Connection.conexion)) ? cadena : Connection.conexion;
            _conexion = Connection.conexion;
        }
        public List<MedioJuego> GetAllMedioJuego()
        {
            List<MedioJuego> lista = new List<MedioJuego>();

            try
            {
                string consulta = @"SELECT idMedioJuego, nombre, estado FROM dbo.MedioJuego (NOLOCK)";

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
                                var item = new MedioJuego
                                {
                                    id = ManejaNulos.ManageNullInteger(dr["idMedioJuego"]),
                                    nombre = ManejaNulos.ManageNullStr(dr["nombre"]),
                                    estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                                };
                                lista.Add(item);
                            }
                        }
                        else //No existen datos
                        {
                            lista = new List<MedioJuego>();
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
        public MedioJuego GetMedioJuegoId(string id)
        {
            MedioJuego item = new MedioJuego();

            try
            {
                string consulta = @"SELECT idMedioJuego, nombre, estado FROM dbo.MedioJuego (NOLOCK) 
                                    where idMedioJuego = @idMedioJuego";

                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@idMedioJuego", id);
                    using (var dr = query.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                item = new MedioJuego
                                {
                                    id = ManejaNulos.ManageNullInteger(dr["idMedioJuego"]),
                                    nombre = ManejaNulos.ManageNullStr(dr["nombre"]),
                                    estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                                };
                            }
                        }
                        else //No existen datos
                        {
                            item = new MedioJuego();
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
        public Boolean Create(MedioJuego item)
        {
            Boolean estado = false;

            string consulta = @"
                    Insert into MedioJuego (nombre, estado)
                    values ( @nombre, @estado)";

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
        public Boolean Update(MedioJuego item)
        {
            Boolean estado = false;

            string consulta = @"
                    Update MedioJuego
                            nombre = @nombre,
                            estado = @estado
                    WHERE idMedioJuego = @idMedioJuego";

            try
            {

                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@idMedioJuego", item.id);
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

            string consulta = @" Delete from MedioJuego WHERE idMedioJuego = @idMedioJuego";

            try
            {
                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@idMedioJuego", id);

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
