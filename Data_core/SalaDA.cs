using Models_core;
using System.Data.SqlClient;

namespace Data_core
{
    public class SalaDA
    {
        string _conexion = string.Empty;

        public SalaDA(string cadena)
        {
            Connection.conexion = (String.IsNullOrEmpty(Connection.conexion)) ? cadena : Connection.conexion;
            _conexion = Connection.conexion;
        }

        string consulta_general = @"Select S.idConsorcio, S.idEmpresa, S.idEmpresa, S.nombre, E.nombre as nombreEmpresa, C.nombre as nombreConsorcio, s.ubigeo,
                                    S.autogenerado, S.direccion, S.estado, S. llave, S.idSala
                                    from Sala (nolock) S 
                                    inner join Empresa (nolock) E on E.idEmpresa  = S.idEmpresa and E.idConsorcio = S.idConsorcio
                                    inner join Consorcio (nolock) C on C.id = S.idConsorcio";
        string consulta_por_id = @"Select S.idConsorcio, S.idEmpresa, S.idEmpresa, S.nombre, E.nombre as nombreEmpresa, C.nombre as nombreConsorcio, s.ubigeo,
                                    S.autogenerado, S.direccion, S.estado, S. llave, S.idSala
                                    from Sala (nolock) S 
                                    inner join Empresa (nolock) E on E.idEmpresa  = S.idEmpresa and E.idConsorcio = S.idConsorcio
                                    inner join Consorcio (nolock) C on C.id = S.idConsorcio
                                    where idSala = @id";
        string consulta_por_estado = @"Select S.idConsorcio, S.idEmpresa, S.idEmpresa, S.nombre, E.nombre as nombreEmpresa, C.nombre as nombreConsorcio, s.ubigeo,
                                    S.autogenerado, S.direccion, S.estado, S. llave, S.idSala
                                    from Sala(nolock) S
                                    inner join Empresa(nolock) E on E.idEmpresa  = S.idEmpresa and E.idConsorcio = S.idConsorcio
                                    inner join Consorcio(nolock) C on C.id = S.idConsorcio where S.estado = @estado";
        string insert = @"INSERT INTO dbo.Sala
                        (idConsorcio,idEmpresa,nombre,direccion,ubigeo,estado,autogenerado,llave)
                        VALUES(@idConsorcio,@idEmpresa,@nombre,@direccion,@ubigeo,@estado,@autogenerado,@llave)";
        string update = @"Update Sala set nombre = @nombre, idConsorcio = @idConsorcio, idEmpresa = @idEmpresa, direccion = @direccion, ubigeo = @ubigeo,
                          estado = @estado, autogenerado = @autogenerado, llave = @llave where idSala = @idSala";
        string delete = @"delete from Sala where idSala = @id";

        string consulta_remoto = @"Select S.idConsorcio, S.idEmpresa, S.idEmpresa, S.nombre, E.nombre as nombreEmpresa, C.nombre as nombreConsorcio, s.ubigeo,
                                    S.autogenerado, S.direccion, S.estado, S. llave, S.idSala
                                    from Sala (nolock) S 
                                    inner join Empresa (nolock) E on E.idEmpresa  = S.idEmpresa and E.idConsorcio = S.idConsorcio
                                    inner join Consorcio (nolock) C on C.id = S.idConsorcio where s.autogenerado = @autogenerado";

        public List<Sala> GetAll()
        {
            List<Sala> lista = new List<Sala>();

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
                                var item = new Sala
                                {
                                    idConsorcio = ManejaNulos.ManageNullInteger(dr["idConsorcio"]),
                                    idEmpresa = ManejaNulos.ManageNullInteger(dr["idEmpresa"]),
                                    idSala = ManejaNulos.ManageNullInteger(dr["idSala"]),
                                    nombre = ManejaNulos.ManageNullStr(dr["nombre"]),
                                    nombreConsorcio = ManejaNulos.ManageNullStr(dr["nombreconsorcio"]),
                                    nombreEmpresa = ManejaNulos.ManageNullStr(dr["nombreEmpresa"]),
                                    direccion = ManejaNulos.ManageNullStr(dr["direccion"]),
                                    ubigeo = ManejaNulos.ManageNullStr(dr["ubigeo"]),
                                    estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                                    autogenerado = ManejaNulos.ManageNullStr(dr["autogenerado"]),
                                    llave = ManejaNulos.ManageNullStr(dr["llave"]),
                                };
                                lista.Add(item);
                            }
                        }
                        else
                            lista = new List<Sala>();
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
        public Sala GetByID(int id)
        {
            Sala item = new Sala();

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
                                item = new Sala
                                {
                                    idConsorcio = ManejaNulos.ManageNullInteger(dr["idConsorcio"]),
                                    idEmpresa = ManejaNulos.ManageNullInteger(dr["idEmpresa"]),
                                    idSala = ManejaNulos.ManageNullInteger(dr["idSala"]),
                                    nombre = ManejaNulos.ManageNullStr(dr["nombre"]),
                                    nombreConsorcio = ManejaNulos.ManageNullStr(dr["nombreconsorcio"]),
                                    nombreEmpresa = ManejaNulos.ManageNullStr(dr["nombreEmpresa"]),
                                    direccion = ManejaNulos.ManageNullStr(dr["direccion"]),
                                    ubigeo = ManejaNulos.ManageNullStr(dr["ubigeo"]),
                                    estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                                    autogenerado = ManejaNulos.ManageNullStr(dr["autogenerado"]),
                                    llave = ManejaNulos.ManageNullStr(dr["llave"]),
                                };
                            }
                        }
                        else
                            item = new Sala();
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
        public Sala GetRemoto(string autogenerado)
        {
            Sala item = new Sala();
            SeguridadLinktek sl = new SeguridadLinktek();
            try
            {
                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta_remoto, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@autogenerado", autogenerado);
                    using (var dr = query.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                item = new Sala
                                {
                                    idConsorcio = ManejaNulos.ManageNullInteger(dr["idConsorcio"]),
                                    idEmpresa = ManejaNulos.ManageNullInteger(dr["idEmpresa"]),
                                    idSala = ManejaNulos.ManageNullInteger(dr["idSala"]),
                                    nombre = ManejaNulos.ManageNullStr(dr["nombre"]),
                                    nombreConsorcio = ManejaNulos.ManageNullStr(dr["nombreconsorcio"]),
                                    nombreEmpresa = ManejaNulos.ManageNullStr(dr["nombreEmpresa"]),
                                    direccion = ManejaNulos.ManageNullStr(dr["direccion"]),
                                    ubigeo = ManejaNulos.ManageNullStr(dr["ubigeo"]),
                                    estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                                    autogenerado = ManejaNulos.ManageNullStr(dr["autogenerado"]),
                                    llave = ManejaNulos.ManageNullStr(dr["llave"]),
                                };
                                sl.KeyLinktek = sl.KeyLinktek.Trim() + item.idSala.ToString();
                                string llaveEncriptada = sl.EncryptLlave(item.llave);
                                item.llave = llaveEncriptada;
                            }
                        }
                        else
                            item = new Sala();
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
        public List<Sala> GetAllByStatus(int status)
        {
            List<Sala> lista = new List<Sala>();

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
                                var item = new Sala
                                {
                                    idConsorcio = ManejaNulos.ManageNullInteger(dr["idConsorcio"]),
                                    idEmpresa = ManejaNulos.ManageNullInteger(dr["idEmpresa"]),
                                    idSala = ManejaNulos.ManageNullInteger(dr["idSala"]),
                                    nombre = ManejaNulos.ManageNullStr(dr["nombre"]),
                                    nombreConsorcio = ManejaNulos.ManageNullStr(dr["nombreconsorcio"]),
                                    nombreEmpresa = ManejaNulos.ManageNullStr(dr["nombreEmpresa"]),
                                    direccion = ManejaNulos.ManageNullStr(dr["direccion"]),
                                    ubigeo = ManejaNulos.ManageNullStr(dr["ubigeo"]),
                                    estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                                    autogenerado = ManejaNulos.ManageNullStr(dr["autogenerado"]),
                                    llave = ManejaNulos.ManageNullStr(dr["llave"]),
                                };
                                lista.Add(item);
                            }
                        }
                        else
                            lista = new List<Sala>();
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
        public Boolean Insert(Sala item)
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
                    query.Parameters.AddWithValue("@idEmpresa", item.idEmpresa);
                    query.Parameters.AddWithValue("@nombre", item.nombre);
                    query.Parameters.AddWithValue("@direccion", item.direccion);
                    query.Parameters.AddWithValue("@ubigeo", item.ubigeo);
                    query.Parameters.AddWithValue("@estado", item.estado);
                    query.Parameters.AddWithValue("@autogenerado", item.autogenerado);
                    query.Parameters.AddWithValue("@llave", item.llave);

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
        public Boolean Update(Sala item)
        {
            Boolean estado = false;
            try
            {

                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(update, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@idsala", item.idSala);
                    query.Parameters.AddWithValue("@idConsorcio", item.idConsorcio);
                    query.Parameters.AddWithValue("@idEmpresa", item.idEmpresa);
                    query.Parameters.AddWithValue("@nombre", item.nombre);
                    query.Parameters.AddWithValue("@direccion", item.direccion);
                    query.Parameters.AddWithValue("@ubigeo", item.ubigeo);
                    query.Parameters.AddWithValue("@estado", item.estado);
                    query.Parameters.AddWithValue("@autogenerado", item.autogenerado);
                    query.Parameters.AddWithValue("@llave", item.llave);

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
                    query.Parameters.AddWithValue("@idSala", id);

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
