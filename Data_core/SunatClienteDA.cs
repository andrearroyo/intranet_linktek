using Models_core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_core
{
    public class SunatClienteDA
    {
        string _conexion = string.Empty;

        public SunatClienteDA(string cadena)
        {
            Connection.conexion = (String.IsNullOrEmpty(Connection.conexion)) ? cadena : Connection.conexion;
            _conexion = Connection.conexion;
        }

        string consulta_general = @"select id, ip, puertoEconomico, puertoTecnico, usuario, password, semilla, vector, segundos, estado, fecha, tipo, idSala, sala from sunatCliente (nolock)";
        
        string consulta_sala = @"select id, ip, puertoEconomico, puertoTecnico, usuario, password, semilla, vector, segundos, 
                                estado, fecha, tipo, idsala, sala from sunatCliente (nolock) where idSala = @sala";

        string insert = @"INSERT INTO dbo.sunatCliente
                        (ip, puertoEconomico, puertoTecnico, usuario, password, semilla, vector, segundos, estado, fecha, tipo, idSala, sala)
                        VALUES( @ip, @puertoEconomico, @puertoTecnico, @usuario, @password, @semilla, @vector, @segundos, @estado, @fecha, @tipo, @idSala, @sala)";

        string update = @"Update sunatCliente se ip = @ip, puertoEconomico = @puertoEconomico, puertoTecnico = @puertoTecnico, usuario = @usuario,
                          password = @password, semilla = @semilla, vector = @vector, segundos = @segundos, estado = @estado, fecha = @fecha, 
                          tipo = @tipo, idSala=@idsala, sala = @sala where id = @id";

        string delete = @"delete from sunatCliente where id = @id";

        public List<SunatClientes> GetAll()
        {
            List<SunatClientes> lista = new List<SunatClientes>();

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
                                var item = new SunatClientes
                                {
                                    id = ManejaNulos.ManageNullInteger(dr["id"]),
                                    ip = ManejaNulos.ManageNullStr(dr["ip"]),
                                    puertoEconomico = ManejaNulos.ManageNullStr(dr["puertoEconomico"]),
                                    puertoTecnico = ManejaNulos.ManageNullStr(dr["puertoTecnico"]),
                                    usuario = ManejaNulos.ManageNullStr(dr["usuario"]),
                                    password = ManejaNulos.ManageNullStr(dr["password"]),
                                    semilla = ManejaNulos.ManageNullStr(dr["semilla"]),
                                    vector = ManejaNulos.ManageNullStr(dr["vector"]),
                                    segundos = ManejaNulos.ManageNullStr(dr["segundos"]),
                                    estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                                    fecha = ManejaNulos.ManageNullDate(dr["fecha"]),
                                    tipo = ManejaNulos.ManageNullInteger(dr["tipo"]),
                                    idSala = ManejaNulos.ManageNullInteger(dr["idSala"]),
                                    sala = ManejaNulos.ManageNullStr(dr["sala"]),
                                };
                                lista.Add(item);
                            }
                        }
                        else
                            lista = new List<SunatClientes>();
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
        public SunatClientes GetByID(int id)
        {
            SunatClientes item = new SunatClientes();

            try
            {
                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta_sala, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@Sala", id);
                    using (var dr = query.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                item = new SunatClientes
                                {
                                    id = ManejaNulos.ManageNullInteger(dr["id"]),
                                    ip = ManejaNulos.ManageNullStr(dr["ip"]),
                                    puertoEconomico = ManejaNulos.ManageNullStr(dr["puertoEconomico"]),
                                    puertoTecnico = ManejaNulos.ManageNullStr(dr["puertoTecnico"]),
                                    usuario = ManejaNulos.ManageNullStr(dr["usuario"]),
                                    password = ManejaNulos.ManageNullStr(dr["password"]),
                                    semilla = ManejaNulos.ManageNullStr(dr["semilla"]),
                                    vector = ManejaNulos.ManageNullStr(dr["vector"]),
                                    segundos = ManejaNulos.ManageNullStr(dr["segundos"]),
                                    estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                                    fecha = ManejaNulos.ManageNullDate(dr["fecha"]),
                                    tipo = ManejaNulos.ManageNullInteger(dr["tipo"]),
                                    idSala = ManejaNulos.ManageNullInteger(dr["idSala"]),
                                    sala = ManejaNulos.ManageNullStr(dr["sala"]),
                                };
                            }
                        }
                        else
                            item = new SunatClientes();
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
        public Boolean Insert(SunatClientes item)
        {
            Boolean estado = false;
            try
            {

                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(insert, con);
                    query.CommandTimeout = 0;
                    //query.Parameters.AddWithValue("@id", item.id);
                    query.Parameters.AddWithValue("@idSala", item.idSala);
                    query.Parameters.AddWithValue("@ip", item.ip);
                    query.Parameters.AddWithValue("@puertoEconomico", item.puertoEconomico);
                    query.Parameters.AddWithValue("@puertoTecnico", item.puertoTecnico);
                    query.Parameters.AddWithValue("@usuario", item.usuario);
                    query.Parameters.AddWithValue("@password", item.password);
                    query.Parameters.AddWithValue("@semilla", item.semilla);
                    query.Parameters.AddWithValue("@vector", item.vector);
                    query.Parameters.AddWithValue("@segundos", item.segundos);
                    query.Parameters.AddWithValue("@estado", item.estado);
                    query.Parameters.AddWithValue("@fecha", item.fecha);
                    query.Parameters.AddWithValue("@tipo", item.tipo);
                    query.Parameters.AddWithValue("@sala", item.sala);

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
        public Boolean Update(SunatClientes item)
        {
            Boolean estado = false;
            try
            {

                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(update, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@id", item.id);
                    query.Parameters.AddWithValue("@idSala", item.idSala);
                    query.Parameters.AddWithValue("@ip", item.ip);
                    query.Parameters.AddWithValue("@puertoEconomico", item.puertoEconomico);
                    query.Parameters.AddWithValue("@puertoTecnico", item.puertoTecnico);
                    query.Parameters.AddWithValue("@usuario", item.usuario);
                    query.Parameters.AddWithValue("@password", item.password);
                    query.Parameters.AddWithValue("@semilla", item.semilla);
                    query.Parameters.AddWithValue("@vector", item.vector);
                    query.Parameters.AddWithValue("@segundos", item.segundos);
                    query.Parameters.AddWithValue("@estado", item.estado);
                    query.Parameters.AddWithValue("@fecha", item.fecha);
                    query.Parameters.AddWithValue("@tipo", item.tipo);
                    query.Parameters.AddWithValue("@sala", item.sala);

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
