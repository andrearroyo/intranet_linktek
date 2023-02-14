using Models_core;
using Data_core.Seguridad;
using System.Data.SqlClient;

namespace Data_core
{
    public class LicenciaDA
    {

        string _conexion = string.Empty;
        SalaDA _itemSalaDa;

        public LicenciaDA(string cadena)
        {
            Connection.conexion = (String.IsNullOrEmpty(Connection.conexion)) ? cadena : Connection.conexion;
            _conexion = Connection.conexion;
            _itemSalaDa = new SalaDA(_conexion);
        }

        string consulta_general = @"select l.idLicencia, l.idSala, l.idPaquete, l.fecha_inic, l.fecha_fin, l.cantidad_dias, l.cantidad_free, l.estado, l.tipo,
                                    p.nombre as nombrePaquete, s.nombre as nombreSala
                                    from licencia (nolock) l
                                    inner join Paquete (nolock) P on P.idPaquete = l.idPaquete
                                    inner join Sala (nolock) S on S.idSala = l.idSala ";
        string consulta_por_id = @"select l.idLicencia, l.idSala, l.idPaquete, l.fecha_inic, l.fecha_fin, l.cantidad_dias, l.cantidad_free, l.estado, l.tipo,
                                    p.nombre as nombrePaquete, s.nombre as nombreSala
                                    from licencia (nolock) l
                                    inner join Paquete (nolock) P on P.idPaquete = l.idPaquete
                                    inner join Sala (nolock) S on S.idSala = l.idSala 
                                    where l.idPaquete = @idPaquete and l.idSala = @idSala";
        string consulta_remota = @"select l.idLicencia, l.idSala, l.idPaquete, ps.idSistema, l.fecha_inic, l.fecha_fin, l.cantidad_dias, l.cantidad_free, l.estado, l.tipo,
                                    p.nombre as nombrePaquete, s.nombre as nombreSala
                                    from licencia (nolock) l
                                    inner join Paquete (nolock) P on P.idPaquete = l.idPaquete
                                    inner join Sala (nolock) S on S.idSala = l.idSala 
                                    inner join PaqueteSistema (nolock) ps on ps.idPaquete = l.idPaquete
                                    where l.idSala = @idSala and @fecha between convert(date, l.fecha_inic) and convert(date, l.fecha_plazo)";
        string consulta_por_estado = @"Select idConsorcio, idEmpresa, e.nombre, c.nombre as nombreconsorcio, ruc, direccion, e.estado from Empresa (nolock) E inner join Consorcio (nolock) C on C.id = E.idConsorcio where e.estado = @estado";
        string insert = @"insert into Licencia (idSala, idPaquete, fecha_inic, fecha_fin, cantidad_dias, cantidad_free, estado, tipo) values (@idSala, @idPaquete, @fecha_inic, @fecha_fin, @cantidad_dias, @cantidad_free, @estado, @tipo)";
        string update = @"update Licencia set idSala = @idSala, idPaquete = @idPaquete, fecha_inic = @fecha_inic, fecha_fin = @fecha_fin, cantidad_dias = @cantidad_dias, cantidad_free = @cantidad_free, estado = @estado, tipo = @tipo where idLicencia = @idLicencia";
        string delete = @"delete from idLicencia where idLicencia = @idLicencia";

        public List<Licencia> GetAll()
        {
            List<Licencia> lista = new List<Licencia>();

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
                                var item = new Licencia
                                {
                                    idLicencia = ManejaNulos.ManageNullInteger(dr["idLicencia"]),
                                    idSala = ManejaNulos.ManageNullInteger(dr["idSala"]),
                                    idPaquete = ManejaNulos.ManageNullInteger(dr["idPaquete"]),
                                    fecha_inic = ManejaNulos.ManageNullDate(dr["fecha_inic"]),
                                    fecha_fin = ManejaNulos.ManageNullDate(dr["fecha_fin"]),
                                    cantidad_dias = ManejaNulos.ManageNullStr(dr["cantidad_dias"]),
                                    cantidad_free = ManejaNulos.ManageNullStr(dr["cantidad_free"]),
                                    estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                                    tipo = ManejaNulos.ManageNullInteger(dr["tipo"]),
                                    nombrePaquete = ManejaNulos.ManageNullStr(dr["nombrePaquete"]),
                                    nombreSala = ManejaNulos.ManageNullStr(dr["nombreSala"]),
                                };
                                lista.Add(item);
                            }
                        }
                        else
                            lista = new List<Licencia>();
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
        public Licencia GetByIDs(int idPaquete, int idSala)
        {
            Licencia item = new Licencia();

            try
            {
                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta_por_id, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@idPaquete", idPaquete);
                    query.Parameters.AddWithValue("@idSala", idSala);
                    using (var dr = query.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                item = new Licencia
                                {
                                    idLicencia = ManejaNulos.ManageNullInteger(dr["idLicencia"]),
                                    idSala = ManejaNulos.ManageNullInteger(dr["idSala"]),
                                    idPaquete = ManejaNulos.ManageNullInteger(dr["idPaquete"]),
                                    fecha_inic = ManejaNulos.ManageNullDate(dr["fecha_inic"]),
                                    fecha_fin = ManejaNulos.ManageNullDate(dr["fecha_fin"]),
                                    cantidad_dias = ManejaNulos.ManageNullStr(dr["cantidad_dias"]),
                                    cantidad_free = ManejaNulos.ManageNullStr(dr["cantidad_free"]),
                                    estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                                    tipo = ManejaNulos.ManageNullInteger(dr["tipo"]),
                                    nombrePaquete = ManejaNulos.ManageNullStr(dr["nombrePaquete"]),
                                    nombreSala = ManejaNulos.ManageNullStr(dr["nombreSala"]),
                                };
                            }
                        }
                        else
                            item = null;
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
        public List<LicenciaLocal> GetLicenciaRemota(int idSala, string fecha)
        {
            Licencia _item = new Licencia();
            List<LicenciaLocal> lista = new List<LicenciaLocal>();
            LicenciaLocal item = new LicenciaLocal();

            var salaConsulta = _itemSalaDa.GetByID(idSala);

            //var llaveEncriptada = SeguridadLinktek.EncryptLlave(salaConsulta.llave);
            //var llaveDecencriptada = SeguridadLinktek.DecriptLlave(llaveEncriptada);


            try
            {
                DateTime d = Convert.ToDateTime(fecha);
                //DateTime d2 = DateTime.Now.AddDays(-5);
                DateTime d2 = DateTime.Now;

                if (d.ToShortDateString() != d2.ToShortDateString())
                {
                    fecha = d2.ToString("dd-MM-yyyy");
                }

                if (!String.IsNullOrEmpty(salaConsulta.llave))
                {
                    using (var con = new SqlConnection(_conexion))
                    {
                        con.Open();
                        var query = new SqlCommand(consulta_remota, con);
                        query.CommandTimeout = 0;
                        query.Parameters.AddWithValue("@idSala", idSala);
                        query.Parameters.AddWithValue("@fecha", fecha);
                        using (var dr = query.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    _item = new Licencia
                                    {
                                        idLicencia = ManejaNulos.ManageNullInteger(dr["idLicencia"]),
                                        idSala = ManejaNulos.ManageNullInteger(dr["idSala"]),
                                        idPaquete = ManejaNulos.ManageNullInteger(dr["idPaquete"]),
                                        fecha_inic = ManejaNulos.ManageNullDate(dr["fecha_inic"]),
                                        fecha_fin = ManejaNulos.ManageNullDate(dr["fecha_fin"]),
                                        cantidad_dias = ManejaNulos.ManageNullStr(dr["cantidad_dias"]),
                                        cantidad_free = ManejaNulos.ManageNullStr(dr["cantidad_free"]),
                                        estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                                        tipo = ManejaNulos.ManageNullInteger(dr["tipo"]),
                                        nombrePaquete = ManejaNulos.ManageNullStr(dr["nombrePaquete"]),
                                        nombreSala = ManejaNulos.ManageNullStr(dr["nombreSala"]),
                                        idSistema = ManejaNulos.ManageNullInteger(dr["idSistema"]),
                                        mensaje = "Licencia Activa"
                                    };

                                    if(_item.tipo == 2) //compra
                                    {

                                        item = new LicenciaLocal
                                        {
                                            fecha_inicial = Encriptar.Encrypt(DateTime.Now.ToShortDateString(), salaConsulta.llave),
                                            fecha_final = Encriptar.Encrypt(DateTime.Now.ToShortDateString(), salaConsulta.llave),
                                            cantidad_dias = Encriptar.Encrypt("7305000", salaConsulta.llave),
                                            cantidad_free = Encriptar.Encrypt("7305000", salaConsulta.llave),
                                            estado = Encriptar.Encrypt("1", salaConsulta.llave),
                                            sistema = Encriptar.Encrypt(_item.idSistema.ToString(), salaConsulta.llave),
                                            restantes = Encriptar.Encrypt("7305000", salaConsulta.llave),
                                            restantes_free = Encriptar.Encrypt("7305000", salaConsulta.llave),
                                            tipo = Encriptar.Encrypt(_item.tipo.ToString(), salaConsulta.llave),
                                            mensaje = $"Producto comprado"
                                        };
                                    }
                                    else
                                    {
                                        _item.fecha_plazo = _item.fecha_fin.AddDays(Convert.ToInt32(_item.cantidad_free));

                                        DateTime fechaHoy = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                                        DateTime fechaInicial = new DateTime(_item.fecha_inic.Year, _item.fecha_inic.Month, _item.fecha_inic.Day, 0, 0, 0);

                                        var diferencia_fechas = fechaHoy - fechaInicial;
                                        int free = Convert.ToInt32(_item.cantidad_free);
                                        var cantidad = Convert.ToInt32(_item.cantidad_dias) - diferencia_fechas.Days;

                                        if (DateTime.Now > _item.fecha_fin)
                                        {
                                            cantidad = 0;
                                            DateTime fechaPlazo = new DateTime(_item.fecha_plazo.Year, _item.fecha_plazo.Month, _item.fecha_plazo.Day, 0, 0, 0);

                                            diferencia_fechas = fechaPlazo - fechaHoy;
                                            free = Convert.ToInt32(_item.cantidad_free) - diferencia_fechas.Days;

                                            if (free > 0)
                                            {
                                                item = new LicenciaLocal
                                                {
                                                    fecha_inicial = Encriptar.Encrypt(_item.fecha_inic.ToShortDateString(), salaConsulta.llave),
                                                    fecha_final = Encriptar.Encrypt(_item.fecha_fin.ToShortDateString(), salaConsulta.llave),
                                                    cantidad_dias = Encriptar.Encrypt(_item.cantidad_dias.ToString(), salaConsulta.llave),
                                                    cantidad_free = Encriptar.Encrypt(_item.cantidad_free.ToString(), salaConsulta.llave),
                                                    estado = Encriptar.Encrypt("1", salaConsulta.llave),
                                                    sistema = Encriptar.Encrypt(_item.idSistema.ToString(), salaConsulta.llave),
                                                    restantes = Encriptar.Encrypt(cantidad.ToString(), salaConsulta.llave),
                                                    restantes_free = Encriptar.Encrypt(free.ToString(), salaConsulta.llave),
                                                    tipo = Encriptar.Encrypt(_item.tipo.ToString(), salaConsulta.llave),
                                                    mensaje = $"Licencia en estado free, le queda un plazo máximo de {free} días, antes de vencer la licencia"
                                                };
                                            }
                                            else
                                            {
                                                item = new LicenciaLocal
                                                {
                                                    fecha_inicial = Encriptar.Encrypt(_item.fecha_inic.ToShortDateString(), salaConsulta.llave),
                                                    fecha_final = Encriptar.Encrypt(_item.fecha_fin.ToShortDateString(), salaConsulta.llave),
                                                    cantidad_dias = Encriptar.Encrypt(_item.cantidad_dias.ToString(), salaConsulta.llave),
                                                    cantidad_free = Encriptar.Encrypt(_item.cantidad_free.ToString(), salaConsulta.llave),
                                                    estado = Encriptar.Encrypt("0", salaConsulta.llave),
                                                    sistema = Encriptar.Encrypt(_item.idSistema.ToString(), salaConsulta.llave),
                                                    restantes = Encriptar.Encrypt(cantidad.ToString(), salaConsulta.llave),
                                                    restantes_free = Encriptar.Encrypt(free.ToString(), salaConsulta.llave),
                                                    tipo = Encriptar.Encrypt(_item.tipo.ToString(), salaConsulta.llave),
                                                    mensaje = $"Licencia ha vencido, comuníquese con el departamento de ventas o facturación"
                                                };
                                            }
                                        }
                                        else
                                        {
                                            cantidad = Convert.ToInt32(_item.cantidad_dias) - diferencia_fechas.Days;

                                            item = new LicenciaLocal
                                            {
                                                fecha_inicial = Encriptar.Encrypt(_item.fecha_inic.ToShortDateString(), salaConsulta.llave),
                                                fecha_final = Encriptar.Encrypt(_item.fecha_fin.ToShortDateString(), salaConsulta.llave),
                                                cantidad_dias = Encriptar.Encrypt(_item.cantidad_dias.ToString(), salaConsulta.llave),
                                                cantidad_free = Encriptar.Encrypt(_item.cantidad_free.ToString(), salaConsulta.llave),
                                                estado = Encriptar.Encrypt("1", salaConsulta.llave),
                                                sistema = Encriptar.Encrypt(_item.idSistema.ToString(), salaConsulta.llave),
                                                restantes = Encriptar.Encrypt(cantidad.ToString(), salaConsulta.llave),
                                                restantes_free = Encriptar.Encrypt(free.ToString(), salaConsulta.llave),
                                                tipo = Encriptar.Encrypt(_item.tipo.ToString(), salaConsulta.llave),
                                                mensaje = $"Licencia activa, dias restantes: {cantidad}"
                                            };
                                        }
                                    }                                    
                                    lista.Add(item);
                                }
                            }
                            else
                            {
                                item = new LicenciaLocal();
                                item.estado = Encriptar.Encrypt("0", salaConsulta.llave);
                                item.sistema = Encriptar.Encrypt("-1", salaConsulta.llave);
                                item.tipo = Encriptar.Encrypt("1", salaConsulta.llave);
                                item.mensaje = "No se encuentran parametros para otorgar licencia o ha vencido, comuníquese con el departamento de ventas, facturación o sistemas";
                                lista.Add(item);
                            }
                        }
                        con.Close();
                    }
                }
                else
                {
                    item = new LicenciaLocal();
                    item.estado = Encriptar.Encrypt("0", salaConsulta.llave);
                    item.sistema = Encriptar.Encrypt("-1", salaConsulta.llave);
                    item.tipo = Encriptar.Encrypt("1", salaConsulta.llave);
                    item.mensaje = "Sala no registrada";
                    lista.Add(item);
                }
            }
            catch (Exception ex)
            {
                lista = null;
            }
            return lista;

        }
        public List<Licencia> GetAllByStatus(int status)
        {
            List<Licencia> lista = new List<Licencia>();

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
                                var item = new Licencia
                                {
                                    idLicencia = ManejaNulos.ManageNullInteger(dr["idLicencia"]),
                                    idSala = ManejaNulos.ManageNullInteger(dr["idSala"]),
                                    idPaquete = ManejaNulos.ManageNullInteger(dr["idPaquete"]),
                                    fecha_inic = ManejaNulos.ManageNullDate(dr["fecha_inic"]),
                                    fecha_fin = ManejaNulos.ManageNullDate(dr["fecha_fin"]),
                                    cantidad_dias = ManejaNulos.ManageNullStr(dr["cantidad_dias"]),
                                    cantidad_free = ManejaNulos.ManageNullStr(dr["cantidad_free"]),
                                    estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                                    tipo = ManejaNulos.ManageNullInteger(dr["tipo"]),
                                    nombrePaquete = ManejaNulos.ManageNullStr(dr["nombrePaquete"]),
                                    nombreSala = ManejaNulos.ManageNullStr(dr["nombreSala"]),
                                };
                                lista.Add(item);
                            }
                        }
                        else
                            lista = new List<Licencia>();
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
        public Boolean Insert(Licencia item)
        {
            Boolean estado = false;
            try
            {

                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(insert, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@idSala", item.idSala);
                    query.Parameters.AddWithValue("@idPaquete", item.idPaquete);
                    query.Parameters.AddWithValue("@fecha_inic", item.fecha_inic);
                    query.Parameters.AddWithValue("@fecha_fin", item.fecha_fin);
                    query.Parameters.AddWithValue("@cantidad_dias", item.cantidad_dias);
                    query.Parameters.AddWithValue("@cantidad_free", item.cantidad_free);
                    query.Parameters.AddWithValue("@estado", item.estado);
                    query.Parameters.AddWithValue("@tipo", item.tipo);

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
        public Boolean Update(Licencia item)
        {
            Boolean estado = false;
            try
            {

                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(update, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@idLicencia", item.idLicencia);
                    query.Parameters.AddWithValue("@idSala", item.idSala);
                    query.Parameters.AddWithValue("@idPaquete", item.idPaquete);
                    query.Parameters.AddWithValue("@fecha_inic", item.fecha_inic);
                    query.Parameters.AddWithValue("@fecha_fin", item.fecha_fin);
                    query.Parameters.AddWithValue("@cantidad_dias", item.cantidad_dias);
                    query.Parameters.AddWithValue("@cantidad_free", item.cantidad_free);
                    query.Parameters.AddWithValue("@estado", item.estado);
                    query.Parameters.AddWithValue("@tipo", item.tipo);

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
                    query.Parameters.AddWithValue("@idLicencia", id);

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

