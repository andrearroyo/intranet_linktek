using Models_core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_core
{
    public class PaqueteSistemaDA
    {
        string _conexion = string.Empty;

        public PaqueteSistemaDA(string cadena)
        {
            Connection.conexion = (String.IsNullOrEmpty(Connection.conexion)) ? cadena : Connection.conexion;
            _conexion = Connection.conexion;
        }

        string consulta_general = @"select idPaqueteSistema, idPaquete, idSistema, estado from PaqueteSistema (nolock)";
        string consulta_por_id = @"select idPaqueteSistema, idPaquete, idSistema, estado from PaqueteSistema (nolock) where idPaqueteSistema = @id";
        string consulta_por_estado = @"select idPaqueteSistema, idPaquete, idSistema, estado from PaqueteSistema (nolock) where estado = @status";
        string consulta_paquete_sistema = @"select PS.idPaqueteSistema, PS.idPaquete, ps.idSistema,  S.nombre as nombreSistema, s.version,  P.nombre as nombrePaquete, PS.estado from PaqueteSistema (nolock) PS
                                            inner join Sistema (nolock) S on PS.idSistema = S.idSistema
                                            inner join Paquete (nolock) P on P.idPaquete = PS.idPaquete";
        string insert = @"INSERT INTO dbo.PaqueteSistema
                        (idPaquete, idSistema, estado)
                        VALUES(@idPaquete, @idSistema, @estado)";
        string update = @"Update PaqueteSistema set idPaquete = @idPaquete, idSistema = @idSistema, estado = @estado where idPaqueteSistema = @idPaqueteSistema";
        string delete = @"delete from PaqueteSistema where idPaqueteSistema = @idPaqueteSistema";

        public List<PaqueteSistema> GetAll()
        {
            List<PaqueteSistema> lista = new List<PaqueteSistema>();

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
                                var item = new PaqueteSistema
                                {
                                    idPaqueteSistema = ManejaNulos.ManageNullInteger(dr["idPaqueteSistema"]),
                                    idPaquete = ManejaNulos.ManageNullInteger(dr["idPaquete"]),
                                    idSistema = ManejaNulos.ManageNullInteger(dr["idSistema"]),
                                    estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                                };
                                lista.Add(item);
                            }
                        }
                        else
                            lista = new List<PaqueteSistema>();
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
        public List<PaqueteSistema> GetAllPaqueteSistema()
        {
            List<PaqueteSistema> lista = new List<PaqueteSistema>();

            try
            {
                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta_paquete_sistema, con);
                    query.CommandTimeout = 0;
                    using (var dr = query.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item = new PaqueteSistema
                                {
                                    idPaqueteSistema = ManejaNulos.ManageNullInteger(dr["idPaqueteSistema"]),
                                    idPaquete = ManejaNulos.ManageNullInteger(dr["idPaquete"]),
                                    idSistema = ManejaNulos.ManageNullInteger(dr["idSistema"]),
                                    nombre_sistema = ManejaNulos.ManageNullStr(dr["nombreSistema"]),
                                    version_sistema = ManejaNulos.ManageNullStr(dr["version"]),
                                    nombre_paquete = ManejaNulos.ManageNullStr(dr["nombrePaquete"]),
                                    estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                                };
                                lista.Add(item);
                            }
                        }
                        else
                            lista = new List<PaqueteSistema>();
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
        public PaqueteSistema GetByID(int id)
        {
            PaqueteSistema item = new PaqueteSistema();

            try
            {
                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta_por_id, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@idPaqueteSistema", id);
                    using (var dr = query.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                item = new PaqueteSistema
                                {
                                    idPaqueteSistema = ManejaNulos.ManageNullInteger(dr["idPaqueteSistema"]),
                                    idPaquete = ManejaNulos.ManageNullInteger(dr["idPaquete"]),
                                    idSistema = ManejaNulos.ManageNullInteger(dr["idSistema"]),
                                    estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                                };
                            }
                        }
                        else
                            item = new PaqueteSistema();
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
        public List<PaqueteSistema> GetAllByStatus(int status)
        {
            List<PaqueteSistema> lista = new List<PaqueteSistema>();

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
                                var item = new PaqueteSistema
                                {
                                    idPaqueteSistema = ManejaNulos.ManageNullInteger(dr["idPaqueteSistema"]),
                                    idPaquete = ManejaNulos.ManageNullInteger(dr["idPaquete"]),
                                    idSistema = ManejaNulos.ManageNullInteger(dr["idSistema"]),
                                    estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                                };
                                lista.Add(item);
                            }
                        }
                        else
                            lista = new List<PaqueteSistema>();
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
        public Boolean Insert(PaqueteSistema item)
        {
            Boolean estado = false;
            try
            {

                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(insert, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@idPaquete", item.idPaquete);
                    query.Parameters.AddWithValue("@idSistema", item.idSistema);
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
        public Boolean Update(PaqueteSistema item)
        {
            Boolean estado = false;
            try
            {

                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(update, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@idPaqueteSistema", item.idPaqueteSistema);
                    query.Parameters.AddWithValue("@idPaquete", item.idPaquete);
                    query.Parameters.AddWithValue("@idSistema", item.idSistema);
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
                    query.Parameters.AddWithValue("@idPaqueteSistema", id);

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
