using Models_Alertas;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Globalization;

namespace Data.Alertas
{
    public class AlertaDA
    {
        string _conexion = string.Empty;

        public AlertaDA(string conexion)
        {
            _conexion = conexion;
        }
        public List<Alerta> GetAll()
        {
            List<Alerta> lista = new List<Alerta>();
            SqlConnection cnx = new SqlConnection();
            try
            {
                var comand = new SqlCommand();

                using (cnx = new SqlConnection(_conexion))
                {
                    cnx.Open();
                    comand.Connection = cnx;
                    comand.CommandText = "sp_listar_alertas_general";
                    comand.CommandType = CommandType.StoredProcedure;

                    var dr = comand.ExecuteReader();
                    while (dr.Read())
                    {
                        var item = new Alerta()
                        {
                            id = ManejaNulos.ManageNullInteger64(dr["id"]),
                            tipo = ManejaNulos.ManageNullInteger(dr["tipo"]),
                            sala = ManejaNulos.ManageNullInteger(dr["sala"]),
                            sistema = ManejaNulos.ManageNullInteger(dr["sistema"]),
                            fecha = ManejaNulos.ManageNullDate(dr["fecha"]),
                            tabla = ManejaNulos.ManageNullStr(dr["tabla"]).Trim(),
                            mensajeTotal = ManejaNulos.ManageNullStr(dr["mensajeTotal"]).Trim(),
                            estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                        };
                        lista.Add(item);
                    }

                    cnx.Close();
                }
            }
            catch (Exception)
            {
                lista = null;
                cnx.Close();
                cnx.Dispose();

            }
            return lista;
        }
        public List<Alerta> GetAllSala(int idSala)
        {
            List<Alerta> lista = new List<Alerta>();
            SqlConnection cnx = new SqlConnection();
            try
            {
                var comand = new SqlCommand();

                using (cnx = new SqlConnection(_conexion))
                {
                    cnx.Open();
                    comand.Connection = cnx;
                    comand.CommandText = "sp_listar_alertas_sala";
                    comand.CommandType = CommandType.StoredProcedure;
                    comand.Parameters.AddWithValue("@sala", idSala);

                    var dr = comand.ExecuteReader();
                    while (dr.Read())
                    {
                        var item = new Alerta()
                        {
                            id = ManejaNulos.ManageNullInteger64(dr["id"]),
                            tipo = ManejaNulos.ManageNullInteger(dr["tipo"]),
                            sala = ManejaNulos.ManageNullInteger(dr["sala"]),
                            sistema = ManejaNulos.ManageNullInteger(dr["sistema"]),
                            fecha = ManejaNulos.ManageNullDate(dr["fecha"]),
                            tabla = ManejaNulos.ManageNullStr(dr["tabla"]).Trim(),
                            mensajeTotal = ManejaNulos.ManageNullStr(dr["mensajeTotal"]).Trim(),
                            estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                        };
                        lista.Add(item);
                    }

                    cnx.Close();
                }
            }
            catch (Exception)
            {
                lista = null;
                cnx.Close();
                cnx.Dispose();

            }
            return lista;
        }
        public List<Alerta> GetAllSalaFecha(int idSala, DateTime fecha)
        {
            List<Alerta> lista = new List<Alerta>();
            SqlConnection cnx = new SqlConnection();
            try
            {
                var comand = new SqlCommand();

                using (cnx = new SqlConnection(_conexion))
                {
                    cnx.Open();
                    comand.Connection = cnx;
                    comand.CommandText = "sp_listar_alertas_sala_fecha";
                    comand.CommandType = CommandType.StoredProcedure;
                    comand.Parameters.AddWithValue("@sala", idSala);
                    comand.Parameters.AddWithValue("@fecha", fecha);

                    var dr = comand.ExecuteReader();
                    while (dr.Read())
                    {
                        var item = new Alerta()
                        {
                            id = ManejaNulos.ManageNullInteger64(dr["id"]),
                            tipo = ManejaNulos.ManageNullInteger(dr["tipo"]),
                            sala = ManejaNulos.ManageNullInteger(dr["sala"]),
                            sistema = ManejaNulos.ManageNullInteger(dr["sistema"]),
                            fecha = ManejaNulos.ManageNullDate(dr["fecha"]),
                            tabla = ManejaNulos.ManageNullStr(dr["tabla"]).Trim(),
                            mensajeTotal = ManejaNulos.ManageNullStr(dr["mensajeTotal"]).Trim(),
                            estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                        };
                        lista.Add(item);
                    }

                    cnx.Close();
                }
            }
            catch (Exception)
            {
                lista = null;
                cnx.Close();
                cnx.Dispose();

            }
            return lista;
        }
        public List<Alerta> GetAllTipo(int tipo)
        {
            List<Alerta> lista = new List<Alerta>();
            SqlConnection cnx = new SqlConnection();
            try
            {
                var comand = new SqlCommand();

                using (cnx = new SqlConnection(_conexion))
                {
                    cnx.Open();
                    comand.Connection = cnx;
                    comand.CommandText = "sp_listar_alertas_tipo";
                    comand.CommandType = CommandType.StoredProcedure;
                    comand.Parameters.AddWithValue("@tipo", tipo);

                    var dr = comand.ExecuteReader();
                    while (dr.Read())
                    {
                        var item = new Alerta()
                        {
                            id = ManejaNulos.ManageNullInteger64(dr["id"]),
                            tipo = ManejaNulos.ManageNullInteger(dr["tipo"]),
                            sala = ManejaNulos.ManageNullInteger(dr["sala"]),
                            sistema = ManejaNulos.ManageNullInteger(dr["sistema"]),
                            fecha = ManejaNulos.ManageNullDate(dr["fecha"]),
                            tabla = ManejaNulos.ManageNullStr(dr["tabla"]).Trim(),
                            mensajeTotal = ManejaNulos.ManageNullStr(dr["mensajeTotal"]).Trim(),
                            estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                        };
                        lista.Add(item);
                    }

                    cnx.Close();
                }
            }
            catch (Exception)
            {
                lista = null;
                cnx.Close();
                cnx.Dispose();

            }
            return lista;
        }
        public List<Alerta> GetAllTipoSala(int tipo, int sala)
        {
            List<Alerta> lista = new List<Alerta>();
            SqlConnection cnx = new SqlConnection();
            try
            {
                var comand = new SqlCommand();

                using (cnx = new SqlConnection(_conexion))
                {
                    cnx.Open();
                    comand.Connection = cnx;
                    comand.CommandText = "sp_listar_alertas_tipo_sala";
                    comand.CommandType = CommandType.StoredProcedure;
                    comand.Parameters.AddWithValue("@tipo", tipo);
                    comand.Parameters.AddWithValue("@sala", sala);

                    var dr = comand.ExecuteReader();
                    while (dr.Read())
                    {
                        var item = new Alerta()
                        {
                            id = ManejaNulos.ManageNullInteger64(dr["id"]),
                            tipo = ManejaNulos.ManageNullInteger(dr["tipo"]),
                            sala = ManejaNulos.ManageNullInteger(dr["sala"]),
                            sistema = ManejaNulos.ManageNullInteger(dr["sistema"]),
                            fecha = ManejaNulos.ManageNullDate(dr["fecha"]),
                            tabla = ManejaNulos.ManageNullStr(dr["tabla"]).Trim(),
                            mensajeTotal = ManejaNulos.ManageNullStr(dr["mensajeTotal"]).Trim(),
                            estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                        };
                        lista.Add(item);
                    }

                    cnx.Close();
                }
            }
            catch (Exception)
            {
                lista = null;
                cnx.Close();
                cnx.Dispose();

            }
            return lista;
        }
        public List<Alerta> GetAllTipoFecha(int tipo, DateTime fecha)
        {
            List<Alerta> lista = new List<Alerta>();
            SqlConnection cnx = new SqlConnection();
            try
            {
                var comand = new SqlCommand();

                using (cnx = new SqlConnection(_conexion))
                {
                    cnx.Open();
                    comand.Connection = cnx;
                    comand.CommandText = "sp_listar_alertas_tipo_fecha";
                    comand.CommandType = CommandType.StoredProcedure;
                    comand.Parameters.AddWithValue("@tipo", tipo);
                    comand.Parameters.AddWithValue("@fecha", fecha);

                    var dr = comand.ExecuteReader();
                    while (dr.Read())
                    {
                        var item = new Alerta()
                        {
                            id = ManejaNulos.ManageNullInteger64(dr["id"]),
                            tipo = ManejaNulos.ManageNullInteger(dr["tipo"]),
                            sala = ManejaNulos.ManageNullInteger(dr["sala"]),
                            sistema = ManejaNulos.ManageNullInteger(dr["sistema"]),
                            fecha = ManejaNulos.ManageNullDate(dr["fecha"]),
                            tabla = ManejaNulos.ManageNullStr(dr["tabla"]).Trim(),
                            mensajeTotal = ManejaNulos.ManageNullStr(dr["mensajeTotal"]).Trim(),
                            estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                        };
                        lista.Add(item);
                    }

                    cnx.Close();
                }
            }
            catch (Exception)
            {
                lista = null;
                cnx.Close();
                cnx.Dispose();

            }
            return lista;
        }
        public List<Alerta> GetAllTipoSalaFecha(int tipo, int sala, DateTime fecha)
        {
            List<Alerta> lista = new List<Alerta>();
            SqlConnection cnx = new SqlConnection();
            try
            {
                var comand = new SqlCommand();

                using (cnx = new SqlConnection(_conexion))
                {
                    cnx.Open();
                    comand.Connection = cnx;
                    comand.CommandText = "sp_listar_alertas_tipo_fecha_sala";
                    comand.CommandType = CommandType.StoredProcedure;
                    comand.Parameters.AddWithValue("@tipo", tipo);
                    comand.Parameters.AddWithValue("@sala", sala);
                    comand.Parameters.AddWithValue("@fecha", fecha);

                    var dr = comand.ExecuteReader();
                    while (dr.Read())
                    {
                        var item = new Alerta()
                        {
                            id = ManejaNulos.ManageNullInteger64(dr["id"]),
                            tipo = ManejaNulos.ManageNullInteger(dr["tipo"]),
                            sala = ManejaNulos.ManageNullInteger(dr["sala"]),
                            sistema = ManejaNulos.ManageNullInteger(dr["sistema"]),
                            fecha = ManejaNulos.ManageNullDate(dr["fecha"]),
                            tabla = ManejaNulos.ManageNullStr(dr["tabla"]).Trim(),
                            mensajeTotal = ManejaNulos.ManageNullStr(dr["mensajeTotal"]).Trim(),
                            estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                        };
                        lista.Add(item);
                    }

                    cnx.Close();
                }
            }
            catch (Exception)
            {
                lista = null;
                cnx.Close();
                cnx.Dispose();

            }
            return lista;
        }
        public List<Alerta> GetAllSistema(int sistema)
        {
            List<Alerta> lista = new List<Alerta>();
            SqlConnection cnx = new SqlConnection();
            try
            {
                var comand = new SqlCommand();

                using (cnx = new SqlConnection(_conexion))
                {
                    cnx.Open();
                    comand.Connection = cnx;
                    comand.CommandText = "sp_listar_alertas_sistema";
                    comand.CommandType = CommandType.StoredProcedure;
                    comand.Parameters.AddWithValue("@sistema", sistema);

                    var dr = comand.ExecuteReader();
                    while (dr.Read())
                    {
                        var item = new Alerta()
                        {
                            id = ManejaNulos.ManageNullInteger64(dr["id"]),
                            tipo = ManejaNulos.ManageNullInteger(dr["tipo"]),
                            sala = ManejaNulos.ManageNullInteger(dr["sala"]),
                            sistema = ManejaNulos.ManageNullInteger(dr["sistema"]),
                            fecha = ManejaNulos.ManageNullDate(dr["fecha"]),
                            tabla = ManejaNulos.ManageNullStr(dr["tabla"]).Trim(),
                            mensajeTotal = ManejaNulos.ManageNullStr(dr["mensajeTotal"]).Trim(),
                            estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                        };
                        lista.Add(item);
                    }

                    cnx.Close();
                }
            }
            catch (Exception)
            {
                lista = null;
                cnx.Close();
                cnx.Dispose();

            }
            return lista;
        }
        public List<Alerta> GetAllSistemaFecha(int sistema, DateTime fecha)
        {
            List<Alerta> lista = new List<Alerta>();
            SqlConnection cnx = new SqlConnection();
            try
            {
                var comand = new SqlCommand();

                using (cnx = new SqlConnection(_conexion))
                {
                    cnx.Open();
                    comand.Connection = cnx;
                    comand.CommandText = "sp_listar_alertas_sistema_fecha";
                    comand.CommandType = CommandType.StoredProcedure;
                    comand.Parameters.AddWithValue("@sistema", sistema);
                    comand.Parameters.AddWithValue("@fecha", fecha);

                    var dr = comand.ExecuteReader();
                    while (dr.Read())
                    {
                        var item = new Alerta()
                        {
                            id = ManejaNulos.ManageNullInteger64(dr["id"]),
                            tipo = ManejaNulos.ManageNullInteger(dr["tipo"]),
                            sala = ManejaNulos.ManageNullInteger(dr["sala"]),
                            sistema = ManejaNulos.ManageNullInteger(dr["sistema"]),
                            fecha = ManejaNulos.ManageNullDate(dr["fecha"]),
                            tabla = ManejaNulos.ManageNullStr(dr["tabla"]).Trim(),
                            mensajeTotal = ManejaNulos.ManageNullStr(dr["mensajeTotal"]).Trim(),
                            estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                        };
                        lista.Add(item);
                    }

                    cnx.Close();
                }
            }
            catch (Exception)
            {
                lista = null;
                cnx.Close();
                cnx.Dispose();

            }
            return lista;
        }
        public List<Alerta> GetAllSalaSistema(int sala, int sistema)
        {
            List<Alerta> lista = new List<Alerta>();
            SqlConnection cnx = new SqlConnection();
            try
            {
                var comand = new SqlCommand();

                using (cnx = new SqlConnection(_conexion))
                {
                    cnx.Open();
                    comand.Connection = cnx;
                    comand.CommandText = "sp_listar_alertas_sala_sistema";
                    comand.CommandType = CommandType.StoredProcedure;
                    comand.Parameters.AddWithValue("@sala", sala);
                    comand.Parameters.AddWithValue("@sistema", sistema);

                    var dr = comand.ExecuteReader();
                    while (dr.Read())
                    {
                        var item = new Alerta()
                        {
                            id = ManejaNulos.ManageNullInteger64(dr["id"]),
                            tipo = ManejaNulos.ManageNullInteger(dr["tipo"]),
                            sala = ManejaNulos.ManageNullInteger(dr["sala"]),
                            sistema = ManejaNulos.ManageNullInteger(dr["sistema"]),
                            fecha = ManejaNulos.ManageNullDate(dr["fecha"]),
                            tabla = ManejaNulos.ManageNullStr(dr["tabla"]).Trim(),
                            mensajeTotal = ManejaNulos.ManageNullStr(dr["mensajeTotal"]).Trim(),
                            estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                        };
                        lista.Add(item);
                    }

                    cnx.Close();
                }
            }
            catch (Exception)
            {
                lista = null;
                cnx.Close();
                cnx.Dispose();

            }
            return lista;
        }
        public List<Alerta> GetAllSalaSistemaFecha(int sala, int sistema, DateTime fecha)
        {
            List<Alerta> lista = new List<Alerta>();
            SqlConnection cnx = new SqlConnection();
            try
            {
                var comand = new SqlCommand();

                using (cnx = new SqlConnection(_conexion))
                {
                    cnx.Open();
                    comand.Connection = cnx;
                    comand.CommandText = "sp_listar_alertas_sala_sistema_fecha";
                    comand.CommandType = CommandType.StoredProcedure;
                    comand.Parameters.AddWithValue("@sala", sala);
                    comand.Parameters.AddWithValue("@sistema", sistema);
                    comand.Parameters.AddWithValue("@fecha", fecha);

                    var dr = comand.ExecuteReader();
                    while (dr.Read())
                    {
                        var item = new Alerta()
                        {
                            id = ManejaNulos.ManageNullInteger64(dr["id"]),
                            tipo = ManejaNulos.ManageNullInteger(dr["tipo"]),
                            sala = ManejaNulos.ManageNullInteger(dr["sala"]),
                            sistema = ManejaNulos.ManageNullInteger(dr["sistema"]),
                            fecha = ManejaNulos.ManageNullDate(dr["fecha"]),
                            tabla = ManejaNulos.ManageNullStr(dr["tabla"]).Trim(),
                            mensajeTotal = ManejaNulos.ManageNullStr(dr["mensajeTotal"]).Trim(),
                            estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                        };
                        lista.Add(item);
                    }

                    cnx.Close();
                }
            }
            catch (Exception)
            {
                lista = null;
                cnx.Close();
                cnx.Dispose();

            }
            return lista;
        }
        public Boolean Create(Alerta item)
        {
            Boolean rpta = false;
            SqlConnection cnx = new SqlConnection();
            try
            {
                var comand = new SqlCommand();

                using (cnx = new SqlConnection(_conexion))
                {
                    cnx.Open();
                    comand.Connection = cnx;
                    comand.CommandText = "sp_insertar_alerta";
                    comand.CommandType = CommandType.StoredProcedure;
                    comand.Parameters.AddWithValue("@tipo", item.tipo);
                    comand.Parameters.AddWithValue("@sala", item.sala);
                    comand.Parameters.AddWithValue("@sistema", item.sistema);
                    comand.Parameters.AddWithValue("@fecha", item.fecha);
                    comand.Parameters.AddWithValue("@tabla", item.tabla);
                    comand.Parameters.AddWithValue("@mensajeTotal", item.mensajeTotal);
                    comand.Parameters.AddWithValue("@estado", item.estado);

                    comand.ExecuteNonQuery();
                    rpta = true;
                    cnx.Close();
                }
            }
            catch (Exception)
            {
                rpta = false;
                cnx.Close();
                cnx.Dispose();

            }
            return rpta;
        }
        public Boolean Update(Alerta item)
        {
            Boolean rpta = false;
            SqlConnection cnx = new SqlConnection();
            try
            {
                var comand = new SqlCommand();

                using (cnx = new SqlConnection(_conexion))
                {
                    cnx.Open();
                    comand.Connection = cnx;
                    comand.CommandText = "sp_actualizar_alerta";
                    comand.CommandType = CommandType.StoredProcedure;
                    comand.Parameters.AddWithValue("@id", item.id);
                    comand.Parameters.AddWithValue("@tipo", item.tipo);
                    comand.Parameters.AddWithValue("@sala", item.sala);
                    comand.Parameters.AddWithValue("@sistema", item.sistema);
                    comand.Parameters.AddWithValue("@fecha", item.fecha);
                    comand.Parameters.AddWithValue("@tabla", item.tabla);
                    comand.Parameters.AddWithValue("@mensajeTotal", item.mensajeTotal);
                    comand.Parameters.AddWithValue("@estado", item.estado);

                    comand.ExecuteNonQuery();
                    rpta = true;
                    cnx.Close();
                }
            }
            catch (Exception)
            {
                rpta = false;
                cnx.Close();
                cnx.Dispose();

            }
            return rpta;
        }

    }
}
