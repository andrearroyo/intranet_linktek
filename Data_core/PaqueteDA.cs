using Models_core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_core
{
    public class PaqueteDA
    {
        string _conexion = string.Empty;

        public PaqueteDA(string cadena)
        {
            Connection.conexion = (String.IsNullOrEmpty(Connection.conexion)) ? cadena : Connection.conexion;
            _conexion = Connection.conexion;
        }

        string consulta_general = @"Select idPaquete, nombre, tipo, estado from Paquete (nolock)";
        string consulta_por_id = @"Select idPaquete, nombre, tipo, estado from Paquete (nolock) where idPaquete = @id";
        string consulta_por_estado = @"Select idPaquete, nombre, tipo, estado from Paquete (nolock) where estado = @status";
        string insert = @"INSERT INTO dbo.Paquete
                        (nombre, tipo, estado)
                        VALUES( @nombre, @tipo, @estado)";
        string update = @"Update Paquete set nombre = @nombre, tipo = @tipo, estado = @estado where idPaquete = @idPaquete";
        string delete = @"delete from Paquete where idPaquete = @idPaquete";

        public List<Paquete> GetAll()
        {
            List<Paquete> lista = new List<Paquete>();

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
                                var item = new Paquete
                                {
                                    idPaquete = ManejaNulos.ManageNullInteger(dr["idPaquete"]),
                                    nombre = ManejaNulos.ManageNullStr(dr["nombre"]),
                                    tipo = ManejaNulos.ManageNullInteger(dr["tipo"]),
                                    estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                                };
                                lista.Add(item);
                            }
                        }
                        else
                            lista = new List<Paquete>();
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
        public Paquete GetByID(int id)
        {
            Paquete item = new Paquete();

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
                                item = new Paquete
                                {
                                    idPaquete = ManejaNulos.ManageNullInteger(dr["idPaquete"]),
                                    nombre = ManejaNulos.ManageNullStr(dr["nombre"]),
                                    tipo = ManejaNulos.ManageNullInteger(dr["tipo"]),
                                    estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                                };
                            }
                        }
                        else
                            item = new Paquete();
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
        public List<Paquete> GetAllByStatus(int status)
        {
            List<Paquete> lista = new List<Paquete>();

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
                                var item = new Paquete
                                {
                                    idPaquete = ManejaNulos.ManageNullInteger(dr["idPaquete"]),
                                    nombre = ManejaNulos.ManageNullStr(dr["nombre"]),
                                    tipo = ManejaNulos.ManageNullInteger(dr["tipo"]),
                                    estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                                };
                                lista.Add(item);
                            }
                        }
                        else
                            lista = new List<Paquete>();
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
        public Boolean Insert(Paquete item)
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
                    query.Parameters.AddWithValue("@tipo", item.tipo);
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
        public Boolean Update(Paquete item)
        {
            Boolean estado = false;
            try
            {

                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(update, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@idPaquete", item.idPaquete);
                    query.Parameters.AddWithValue("@nombre", item.nombre);
                    query.Parameters.AddWithValue("@tipo", item.tipo);
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
                    query.Parameters.AddWithValue("@idPaquete", id);

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
