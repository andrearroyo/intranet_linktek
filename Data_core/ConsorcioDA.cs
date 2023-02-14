using Models_core;
using System.Data.SqlClient;

namespace Data_core
{
    public class ConsorcioDA
    {
        string _conexion = string.Empty;

        public ConsorcioDA(string cadena)
        {
            Connection.conexion = (String.IsNullOrEmpty(Connection.conexion)) ? cadena : Connection.conexion;
            _conexion = Connection.conexion;
        }

        string consulta_general = @"Select id, nombre, estado from Consorcio (nolock)";
        string consulta_por_id = @"Select id, nombre, estado from Consorcio (nolock) where id = @id";
        string consulta_por_estado = @"Select id, nombre, estado from Consorcio (nolock) where estado = @estado";
        string insertar_consorcio = @"insert into Consorcio (nombre, estado) values (@nombre, @estado)";
        string update_consorcio = @"update Consorcio set nombre = @nombre, estado = @estado where id = @id";
        string delete_consorcio = @"delete from Consorcio where id = @id";

        public List<Consorcio> GetAll()
        {
            List<Consorcio> lista = new List<Consorcio>();

            try
            {
                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta_general, con);
                    query.CommandTimeout = 0;
                    using (var dr = query.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item = new Consorcio
                                {
                                    id = ManejaNulos.ManageNullInteger(dr["id"]),
                                    nombre = ManejaNulos.ManageNullStr(dr["nombre"]),
                                    estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                                };
                                lista.Add(item);
                            }
                        }
                        else 
                            lista = new List<Consorcio>();
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
        public Consorcio GetByID(int id)
        {
            Consorcio item = new Consorcio();

            try
            {
                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta_por_id, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@id", id);
                    using (var dr = query.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                item = new Consorcio
                                {
                                    id = ManejaNulos.ManageNullInteger(dr["id"]),
                                    nombre = ManejaNulos.ManageNullStr(dr["nombre"]),
                                    estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                                };
                            }
                        }
                        else
                            item = new Consorcio();
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
        public List<Consorcio> GetAllByStatus(int status)
        {
            List<Consorcio> lista = new List<Consorcio>();

            try
            {
                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta_por_estado, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@estado", status);
                    using (var dr = query.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item = new Consorcio
                                {
                                    id = ManejaNulos.ManageNullInteger(dr["id"]),
                                    nombre = ManejaNulos.ManageNullStr(dr["nombre"]),
                                    estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                                };
                                lista.Add(item);
                            }
                        }
                        else
                            lista = new List<Consorcio>();
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
        public Boolean Insert(Consorcio item)
        {
            Boolean estado = false;
            try
            {

                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(insertar_consorcio, con);
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
        public Boolean Update(Consorcio item)
        {
            Boolean estado = false;
            try
            {

                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(update_consorcio, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@id", item.id);
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
            try
            {
                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(delete_consorcio, con);
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