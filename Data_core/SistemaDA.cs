using Models_core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_core
{
    public class SistemaDA
    {
        string _conexion = string.Empty;

        public SistemaDA(string cadena)
        {
            Connection.conexion = (String.IsNullOrEmpty(Connection.conexion)) ? cadena : Connection.conexion;
            _conexion = Connection.conexion;
        }

        string consulta_general = @"Select idSistema, nombre, version, fecha_compilado, numero_registros, estado from Sistema (nolock)";
        string consulta_por_id = @"Select idSistema, nombre, version, fecha_compilado, numero_registros, estado from Sistema (nolock) where idSistema = @id";
        string consulta_por_estado = @"Select idSistema, nombre, version. fecha_compilado, numero_registros, estado from Sistema (nolock) where estado = @status";

        string consulta_por_paquete = @"select S.idSistema, S.nombre, S.version, S.fecha_compilado, S.numero_registros, S.estado from PaqueteSistema (nolock) PS inner join Sistema S (nolock) on PS.idSistema = S.idSistema where idPaquete = @idPaquete";


        string insert = @"INSERT INTO dbo.Sistema
                        (nombre, version, fecha_compilado, numero_registros, estado)
                        VALUES(@nombre, @version, @fecha_compilado, @numero_registros, @estado)";
        string update = @"Update Sistema set nombre = @nombre, version = @version, fecha_compilado = @fecha_compilado, numero_registros = @numero_registros,
                          estado = @estado where idSistema = @idSistema";
        string delete = @"delete from Sistema where idSistema = @id";

        public List<Sistema> GetAll()
        {
            List<Sistema> lista = new List<Sistema>();

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
                                var item = new Sistema
                                {
                                    idSistema = ManejaNulos.ManageNullInteger(dr["idSistema"]),
                                    nombre = ManejaNulos.ManageNullStr(dr["nombre"]),
                                    version = ManejaNulos.ManageNullStr(dr["version"]),
                                    fecha_compilado = ManejaNulos.ManageNullDate(dr["fecha_compilado"]),
                                    numero_registros = ManejaNulos.ManageNullInteger(dr["numero_registros"]),
                                    estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                                };
                                lista.Add(item);
                            }
                        }
                        else
                            lista = new List<Sistema>();
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
        public Sistema GetByID(int id)
        {
            Sistema item = new Sistema();

            try
            {
                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta_por_id, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@idSistema", id);
                    using (var dr = query.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                item = new Sistema
                                {
                                    idSistema = ManejaNulos.ManageNullInteger(dr["idSistema"]),
                                    nombre = ManejaNulos.ManageNullStr(dr["nombre"]),
                                    version = ManejaNulos.ManageNullStr(dr["version"]),
                                    fecha_compilado = ManejaNulos.ManageNullDate(dr["fecha_compilado"]),
                                    numero_registros = ManejaNulos.ManageNullInteger(dr["numero_registros"]),
                                    estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                                };
                            }
                        }
                        else
                            item = new Sistema();
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
        public List<Sistema> GetSistemasPorPaquete(int idPaquete)
        {
            List<Sistema> lista = new List<Sistema>();

            try
            {
                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta_por_paquete, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@idPaquete", idPaquete);
                    using (var dr = query.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item = new Sistema
                                {
                                    idSistema = ManejaNulos.ManageNullInteger(dr["idSistema"]),
                                    nombre = ManejaNulos.ManageNullStr(dr["nombre"]),
                                    version = ManejaNulos.ManageNullStr(dr["version"]),
                                    fecha_compilado = ManejaNulos.ManageNullDate(dr["fecha_compilado"]),
                                    numero_registros = ManejaNulos.ManageNullInteger(dr["numero_registros"]),
                                    estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                                };
                                lista.Add(item);
                            }
                        }
                        else
                            lista = new List<Sistema>();
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                lista = new List<Sistema>();
            }
            return lista;

        }
        public List<Sistema> GetAllByStatus(int status)
        {
            List<Sistema> lista = new List<Sistema>();

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
                                var item = new Sistema
                                {
                                    idSistema = ManejaNulos.ManageNullInteger(dr["idSistema"]),
                                    nombre = ManejaNulos.ManageNullStr(dr["nombre"]),
                                    version = ManejaNulos.ManageNullStr(dr["version"]),
                                    fecha_compilado = ManejaNulos.ManageNullDate(dr["fecha_compilado"]),
                                    numero_registros = ManejaNulos.ManageNullInteger(dr["numero_registros"]),
                                    estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                                };
                                lista.Add(item);
                            }
                        }
                        else
                            lista = new List<Sistema>();
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
        public Boolean Insert(Sistema item)
        {
            Boolean estado = false;
            try
            {

                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(insert, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@nombre", item.nombre);
                    query.Parameters.AddWithValue("@version", item.version);
                    query.Parameters.AddWithValue("@fecha_compilado", item.fecha_compilado);
                    query.Parameters.AddWithValue("@numero_registros", item.numero_registros);
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
        public Boolean Update(Sistema item)
        {
            Boolean estado = false;
            try
            {

                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(update, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@idSistema", item.idSistema);
                    query.Parameters.AddWithValue("@nombre", item.nombre);
                    query.Parameters.AddWithValue("@version", item.version);
                    query.Parameters.AddWithValue("@fecha_compilado", item.fecha_compilado);
                    query.Parameters.AddWithValue("@numero_registros", item.numero_registros);
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
                    var query = new SqlCommand(delete, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@idSistema", id);

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
