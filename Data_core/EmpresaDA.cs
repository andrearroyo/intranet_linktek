using Models_core;
using System.Data.SqlClient;

namespace Data_core
{
    public class EmpresaDA
    {

        string _conexion = string.Empty;

        public EmpresaDA(string cadena)
        {
            Connection.conexion = (String.IsNullOrEmpty(Connection.conexion)) ? cadena : Connection.conexion;
            _conexion = Connection.conexion;
        }

        string consulta_general = @"Select idConsorcio, idEmpresa, e.nombre, c.nombre as nombreconsorcio, ruc, direccion, e.estado from Empresa (nolock) E inner join Consorcio (nolock) C on C.id = E.idConsorcio";
        string consulta_por_id = @"Select idConsorcio, idEmpresa, e.nombre, c.nombre as nombreconsorcio, ruc, direccion, e.estado from Empresa (nolock) E inner join Consorcio (nolock) C on C.id = E.idConsorcio where idEmpresa = @id";
        string consulta_por_estado = @"Select idConsorcio, idEmpresa, e.nombre, c.nombre as nombreconsorcio, ruc, direccion, e.estado from Empresa (nolock) E inner join Consorcio (nolock) C on C.id = E.idConsorcio where e.estado = @estado";
        string insert = @"insert into Empresa (idConsorcio, nombre, ruc, direccion, estado) values (@idConsorcio, @nombre, @ruc, @direccion, @estado)";
        string update = @"update Empresa set idConsorcio = @idConsorcio, nombre = @nombre, ruc = @ruc, direccion = @direccion, estado = @estado where idEmpresa = @idEmpresa";
        string delete = @"delete from Empresa where idEmpresa = @idEmpresa";

        public List<Empresa> GetAll()
        {
            List<Empresa> lista = new List<Empresa>();

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
                                var item = new Empresa
                                {
                                    idConsorcio = ManejaNulos.ManageNullInteger(dr["idConsorcio"]),
                                    idEmpresa = ManejaNulos.ManageNullInteger(dr["idEmpresa"]),
                                    nombre = ManejaNulos.ManageNullStr(dr["nombre"]),
                                    nombreConsorcio = ManejaNulos.ManageNullStr(dr["nombreconsorcio"]),
                                    ruc = ManejaNulos.ManageNullStr(dr["ruc"]),
                                    direccion = ManejaNulos.ManageNullStr(dr["direccion"]),
                                    estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                                };
                                lista.Add(item);
                            }
                        }
                        else
                            lista = new List<Empresa>();
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
        public Empresa GetByID(int id)
        {
            Empresa item = new Empresa();

            try
            {
                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta_por_id, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@idEmpresa", id);
                    using (var dr = query.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                item = new Empresa
                                {
                                    idConsorcio = ManejaNulos.ManageNullInteger(dr["idConsorcio"]),
                                    idEmpresa = ManejaNulos.ManageNullInteger(dr["idEmpresa"]),
                                    nombre = ManejaNulos.ManageNullStr(dr["nombre"]),
                                    nombreConsorcio = ManejaNulos.ManageNullStr(dr["nombreconsorcio"]),
                                    ruc = ManejaNulos.ManageNullStr(dr["ruc"]),
                                    direccion = ManejaNulos.ManageNullStr(dr["direccion"]),
                                    estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                                };
                            }
                        }
                        else
                            item = new Empresa();
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
        public List<Empresa> GetAllByStatus(int status)
        {
            List<Empresa> lista = new List<Empresa>();

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
                                var item = new Empresa
                                {
                                    idConsorcio = ManejaNulos.ManageNullInteger(dr["idConsorcio"]),
                                    idEmpresa = ManejaNulos.ManageNullInteger(dr["idEmpresa"]),
                                    nombre = ManejaNulos.ManageNullStr(dr["nombre"]),
                                    nombreConsorcio = ManejaNulos.ManageNullStr(dr["nombreconsorcio"]),
                                    ruc = ManejaNulos.ManageNullStr(dr["ruc"]),
                                    direccion = ManejaNulos.ManageNullStr(dr["direccion"]),
                                    estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                                };
                                lista.Add(item);
                            }
                        }
                        else
                            lista = new List<Empresa>();
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
        public Boolean Insert(Empresa item)
        {
            Boolean estado = false;
            try
            {

                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(insert, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@idConsorcio", item.idConsorcio);
                    query.Parameters.AddWithValue("@nombre", item.nombre);
                    query.Parameters.AddWithValue("@ruc", item.ruc);
                    query.Parameters.AddWithValue("@direccion", item.direccion);
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
        public Boolean Update(Empresa item)
        {
            Boolean estado = false;
            try
            {

                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(update, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@idConsorcio", item.idConsorcio);
                    query.Parameters.AddWithValue("@idEmpresa", item.idEmpresa);
                    query.Parameters.AddWithValue("@nombre", item.nombre);
                    query.Parameters.AddWithValue("@ruc", item.ruc);
                    query.Parameters.AddWithValue("@direccion", item.direccion);
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
                    query.Parameters.AddWithValue("@idEmpresa", id);

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
