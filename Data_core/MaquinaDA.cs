using System.Data.SqlClient;
using Models_core;

namespace Data_core
{
    public class MaquinaDA
    {
        string _conexion = string.Empty;

        public MaquinaDA(string cadena)
        {
            Connection.conexion = (String.IsNullOrEmpty(Connection.conexion)) ? cadena : Connection.conexion;
            _conexion = Connection.conexion;
        }

        public List<Maquina> GetAllMaquina()
        {
            List<Maquina> lista = new List<Maquina>();

            try
            {
                string consulta = @"SELECT m.id,codigoAlterno,codigoInterno,nroSerie,mar.idMarca,m.idModelo,idJuego,
                                    token,ip,hopper,idMedioJuego,codIso,idDenominacion,idMoneda,idTipoMaquina,
                                    posx,posy,idFormula,idFormulaEconomica,porcTeorico,nuc,nuid,m.estado,
                                    servidor,segmento,tipoconexion,retirotemporal,fechaCreado,fechaModificado
									,J.nombre Juego,mo.nombre Modelo,mar.nombre marca
                                    FROM Maquina m (nolock) 
									inner join Juego j (nolock) on j.id=m.idJuego
									inner join Modelo mo (nolock) on mo.idModelo=m.idModelo
									inner join Marca mar (nolock) on mar.idMarca=j.idmarca ";

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
                                var item = new Maquina
                                {
                                    codigoAlterno = ManejaNulos.ManageNullStr(dr["codigoAlterno"]),
                                    codigoInterno = ManejaNulos.ManageNullStr(dr["codigoInterno"]),
                                    nroSerie = ManejaNulos.ManageNullStr(dr["nroSerie"]),
                                    idMarca = ManejaNulos.ManageNullInteger(dr["idMarca"]),
                                    idModelo = ManejaNulos.ManageNullInteger(dr["idModelo"]),
                                    idJuego = ManejaNulos.ManageNullInteger(dr["idJuego"]),
                                    token = ManejaNulos.ManageNullDecimal(dr["token"]),
                                    ip = ManejaNulos.ManageNullStr(dr["ip"]),
                                    hopper = ManejaNulos.ManageNullInteger(dr["hopper"]),
                                    idMedioJuego = ManejaNulos.ManageNullInteger(dr["idMedioJuego"]),
                                    codIso = ManejaNulos.ManageNullStr(dr["codIso"]),
                                    idDenominacion = ManejaNulos.ManageNullInteger(dr["idDenominacion"]),
                                    idMoneda = ManejaNulos.ManageNullInteger(dr["idMoneda"]),
                                    idTipoMaquina = ManejaNulos.ManageNullInteger(dr["idTipoMaquina"]),
                                    posx = ManejaNulos.ManageNullInteger(dr["posx"]),
                                    posy = ManejaNulos.ManageNullInteger(dr["posy"]),
                                    idFormula = ManejaNulos.ManageNullInteger(dr["idFormula"]),
                                    idFormulaEconomica = ManejaNulos.ManageNullInteger(dr["idFormulaEconomica"]),
                                    porcTeorico = ManejaNulos.ManageNullDecimal(dr["porcTeorico"]),
                                    nuc = ManejaNulos.ManageNullStr(dr["nuc"]),
                                    nuid = ManejaNulos.ManageNullStr(dr["nuid"]),
                                    estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                                    servidor = ManejaNulos.ManageNullInteger(dr["servidor"]),
                                    segmento = ManejaNulos.ManageNullInteger(dr["segmento"]),
                                    tipoconexion = ManejaNulos.ManageNullInteger(dr["tipoconexion"]),
                                    retirotemporal = ManejaNulos.ManageNullInteger(dr["retirotemporal"]),
                                    fechaCreado = ManejaNulos.ManageNullDate(dr["fechaCreado"]),
                                    fechaModificado = ManejaNulos.ManageNullDate(dr["fechaModificado"]),
                                    marca = ManejaNulos.ManageNullStr(dr["marca"]),
                                    juego = ManejaNulos.ManageNullStr(dr["juego"]),
                                    modelo = ManejaNulos.ManageNullStr(dr["modelo"]),
                                };
                                lista.Add(item);
                            }
                        }
                        else //No existen datos
                        {
                            lista = new List<Maquina>();
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
        public List<Maquina> GetAllMaquina(int idSala)
        {
            List<Maquina> lista = new List<Maquina>();

            try
            {
                string consulta = @"SELECT m.id,codigoAlterno,codigoInterno,nroSerie,mar.idMarca,m.idModelo,idJuego,
                                    token,ip,hopper,idMedioJuego,codIso,idDenominacion,idMoneda,idTipoMaquina,
                                    posx,posy,idFormula,idFormulaEconomica,porcTeorico,nuc,nuid,m.estado,
                                    servidor,segmento,tipoconexion,retirotemporal,fechaCreado,fechaModificado, idSala
									,J.nombre Juego,mo.nombre Modelo,mar.nombre marca
                                    FROM Maquina m (nolock) 
									inner join Juego j (nolock) on j.id=m.idJuego
									inner join Modelo mo (nolock) on mo.idModelo=m.idModelo
									inner join Marca mar (nolock) on mar.idMarca=j.idmarca 
                                    where idSala = @idSala";

                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@idSala", idSala);
                    using (var dr = query.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item = new Maquina
                                {
                                    codigoAlterno = ManejaNulos.ManageNullStr(dr["codigoAlterno"]),
                                    codigoInterno = ManejaNulos.ManageNullStr(dr["codigoInterno"]),
                                    nroSerie = ManejaNulos.ManageNullStr(dr["nroSerie"]),
                                    idMarca = ManejaNulos.ManageNullInteger(dr["idMarca"]),
                                    idModelo = ManejaNulos.ManageNullInteger(dr["idModelo"]),
                                    idJuego = ManejaNulos.ManageNullInteger(dr["idJuego"]),
                                    token = ManejaNulos.ManageNullDecimal(dr["token"]),
                                    ip = ManejaNulos.ManageNullStr(dr["ip"]),
                                    hopper = ManejaNulos.ManageNullInteger(dr["hopper"]),
                                    idMedioJuego = ManejaNulos.ManageNullInteger(dr["idMedioJuego"]),
                                    codIso = ManejaNulos.ManageNullStr(dr["codIso"]),
                                    idDenominacion = ManejaNulos.ManageNullInteger(dr["idDenominacion"]),
                                    idMoneda = ManejaNulos.ManageNullInteger(dr["idMoneda"]),
                                    idTipoMaquina = ManejaNulos.ManageNullInteger(dr["idTipoMaquina"]),
                                    posx = ManejaNulos.ManageNullInteger(dr["posx"]),
                                    posy = ManejaNulos.ManageNullInteger(dr["posy"]),
                                    idFormula = ManejaNulos.ManageNullInteger(dr["idFormula"]),
                                    idFormulaEconomica = ManejaNulos.ManageNullInteger(dr["idFormulaEconomica"]),
                                    porcTeorico = ManejaNulos.ManageNullDecimal(dr["porcTeorico"]),
                                    nuc = ManejaNulos.ManageNullStr(dr["nuc"]),
                                    nuid = ManejaNulos.ManageNullStr(dr["nuid"]),
                                    estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                                    servidor = ManejaNulos.ManageNullInteger(dr["servidor"]),
                                    segmento = ManejaNulos.ManageNullInteger(dr["segmento"]),
                                    tipoconexion = ManejaNulos.ManageNullInteger(dr["tipoconexion"]),
                                    retirotemporal = ManejaNulos.ManageNullInteger(dr["retirotemporal"]),
                                    fechaCreado = ManejaNulos.ManageNullDate(dr["fechaCreado"]),
                                    fechaModificado = ManejaNulos.ManageNullDate(dr["fechaModificado"]),
                                    marca = ManejaNulos.ManageNullStr(dr["marca"]),
                                    juego = ManejaNulos.ManageNullStr(dr["juego"]),
                                    modelo = ManejaNulos.ManageNullStr(dr["modelo"]),
                                    idSala = ManejaNulos.ManageNullInteger(dr["idSala"]),
                                };
                                lista.Add(item);
                            }
                        }
                        else //No existen datos
                        {
                            lista = new List<Maquina>();
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

        public List<Maquina> GetAllMaquinaStatus(int estado)
        {
            List<Maquina> lista = new List<Maquina>();

            try
            {
                string consulta = @"SELECT m.id,codigoAlterno,codigoInterno,nroSerie,mar.idMarca,m.idModelo,idJuego,
                                    token,ip,hopper,idMedioJuego,codIso,idDenominacion,idMoneda,idTipoMaquina,
                                    posx,posy,idFormula,idFormulaEconomica,porcTeorico,nuc,nuid,m.estado,
                                    servidor,segmento,tipoconexion,retirotemporal,fechaCreado,fechaModificado
									,J.nombre Juego,mo.nombre Modelo,mar.nombre marca
                                    FROM Maquina m (nolock) 
									inner join Juego j (nolock) on j.id=m.idJuego
									inner join Modelo mo (nolock) on mo.idModelo=m.idModelo
									inner join Marca mar (nolock) on mar.idMarca=j.idmarca where m.estado = @estado";

                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@estado", estado);
                    using (var dr = query.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item = new Maquina
                                {
                                    codigoAlterno = ManejaNulos.ManageNullStr(dr["codigoAlterno"]),
                                    codigoInterno = ManejaNulos.ManageNullStr(dr["codigoInterno"]),
                                    nroSerie = ManejaNulos.ManageNullStr(dr["nroSerie"]),
                                    idMarca = ManejaNulos.ManageNullInteger(dr["idMarca"]),
                                    idModelo = ManejaNulos.ManageNullInteger(dr["idModelo"]),
                                    idJuego = ManejaNulos.ManageNullInteger(dr["idJuego"]),
                                    token = ManejaNulos.ManageNullDecimal(dr["token"]),
                                    ip = ManejaNulos.ManageNullStr(dr["ip"]),
                                    hopper = ManejaNulos.ManageNullInteger(dr["hopper"]),
                                    idMedioJuego = ManejaNulos.ManageNullInteger(dr["idMedioJuego"]),
                                    codIso = ManejaNulos.ManageNullStr(dr["codIso"]),
                                    idDenominacion = ManejaNulos.ManageNullInteger(dr["idDenominacion"]),
                                    idMoneda = ManejaNulos.ManageNullInteger(dr["idMoneda"]),
                                    idTipoMaquina = ManejaNulos.ManageNullInteger(dr["idTipoMaquina"]),
                                    posx = ManejaNulos.ManageNullInteger(dr["posx"]),
                                    posy = ManejaNulos.ManageNullInteger(dr["posy"]),
                                    idFormula = ManejaNulos.ManageNullInteger(dr["idFormula"]),
                                    idFormulaEconomica = ManejaNulos.ManageNullInteger(dr["idFormulaEconomica"]),
                                    porcTeorico = ManejaNulos.ManageNullDecimal(dr["porcTeorico"]),
                                    nuc = ManejaNulos.ManageNullStr(dr["nuc"]),
                                    nuid = ManejaNulos.ManageNullStr(dr["nuid"]),
                                    estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                                    servidor = ManejaNulos.ManageNullInteger(dr["servidor"]),
                                    segmento = ManejaNulos.ManageNullInteger(dr["segmento"]),
                                    tipoconexion = ManejaNulos.ManageNullInteger(dr["tipoconexion"]),
                                    retirotemporal = ManejaNulos.ManageNullInteger(dr["retirotemporal"]),
                                    fechaCreado = ManejaNulos.ManageNullDate(dr["fechaCreado"]),
                                    fechaModificado = ManejaNulos.ManageNullDate(dr["fechaModificado"]),
                                };
                                lista.Add(item);
                            }
                        }
                        else //No existen datos
                        {
                            lista = new List<Maquina>();
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

        public Maquina GetByCodMaq(string codmaq)
        {
            Maquina _item = new Maquina();

            try
            {
                string consulta = @"SELECT m.id,codigoAlterno,codigoInterno,nroSerie,mar.idMarca,m.idModelo,idJuego,
                                    token,ip,hopper,idMedioJuego,codIso,idDenominacion,idMoneda,idTipoMaquina,
                                    posx,posy,idFormula,idFormulaEconomica,porcTeorico,nuc,nuid,m.estado,
                                    servidor,segmento,tipoconexion,retirotemporal,fechaCreado,fechaModificado
									,J.nombre Juego,mo.nombre Modelo,mar.nombre marca
                                    FROM Maquina m (nolock) 
									inner join Juego j (nolock) on j.id=m.idJuego
									inner join Modelo mo (nolock) on mo.idModelo=m.idModelo
									inner join Marca mar (nolock) on mar.idMarca=j.idmarca where (codigoAlterno = @codmaq or codigoInterno = @codmaq)";

                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@codmaq", codmaq);
                    using (var dr = query.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                _item = new Maquina
                                {
                                    codigoAlterno = ManejaNulos.ManageNullStr(dr["codigoAlterno"]),
                                    codigoInterno = ManejaNulos.ManageNullStr(dr["codigoInterno"]),
                                    nroSerie = ManejaNulos.ManageNullStr(dr["nroSerie"]),
                                    idMarca = ManejaNulos.ManageNullInteger(dr["idMarca"]),
                                    idModelo = ManejaNulos.ManageNullInteger(dr["idModelo"]),
                                    idJuego = ManejaNulos.ManageNullInteger(dr["idJuego"]),
                                    token = ManejaNulos.ManageNullDecimal(dr["token"]),
                                    ip = ManejaNulos.ManageNullStr(dr["ip"]),
                                    hopper = ManejaNulos.ManageNullInteger(dr["hopper"]),
                                    idMedioJuego = ManejaNulos.ManageNullInteger(dr["idMedioJuego"]),
                                    codIso = ManejaNulos.ManageNullStr(dr["codIso"]),
                                    idDenominacion = ManejaNulos.ManageNullInteger(dr["idDenominacion"]),
                                    idMoneda = ManejaNulos.ManageNullInteger(dr["idMoneda"]),
                                    idTipoMaquina = ManejaNulos.ManageNullInteger(dr["idTipoMaquina"]),
                                    posx = ManejaNulos.ManageNullInteger(dr["posx"]),
                                    posy = ManejaNulos.ManageNullInteger(dr["posy"]),
                                    idFormula = ManejaNulos.ManageNullInteger(dr["idFormula"]),
                                    idFormulaEconomica = ManejaNulos.ManageNullInteger(dr["idFormulaEconomica"]),
                                    porcTeorico = ManejaNulos.ManageNullDecimal(dr["porcTeorico"]),
                                    nuc = ManejaNulos.ManageNullStr(dr["nuc"]),
                                    nuid = ManejaNulos.ManageNullStr(dr["nuid"]),
                                    estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                                    servidor = ManejaNulos.ManageNullInteger(dr["servidor"]),
                                    segmento = ManejaNulos.ManageNullInteger(dr["segmento"]),
                                    tipoconexion = ManejaNulos.ManageNullInteger(dr["tipoconexion"]),
                                    retirotemporal = ManejaNulos.ManageNullInteger(dr["retirotemporal"]),
                                    fechaCreado = ManejaNulos.ManageNullDate(dr["fechaCreado"]),
                                    fechaModificado = ManejaNulos.ManageNullDate(dr["fechaModificado"]),
                                };
                            }
                        }
                        else //No existen datos
                        {
                            _item = new Maquina();
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                _item = null;
            }
            return _item;

        }

        public Maquina GetById(int id)
        {
            Maquina _item = new Maquina();

            try
            {
                string consulta = @"SELECT m.id,codigoAlterno,codigoInterno,nroSerie,mar.idMarca,m.idModelo,idJuego,
                                    token,ip,hopper,idMedioJuego,codIso,idDenominacion,idMoneda,idTipoMaquina,
                                    posx,posy,idFormula,idFormulaEconomica,porcTeorico,nuc,nuid,m.estado,
                                    servidor,segmento,tipoconexion,retirotemporal,fechaCreado,fechaModificado
									,J.nombre Juego,mo.nombre Modelo,mar.nombre marca
                                    FROM Maquina m (nolock) 
									inner join Juego j (nolock) on j.id=m.idJuego
									inner join Modelo mo (nolock) on mo.idModelo=m.idModelo
									inner join Marca mar (nolock) on mar.idMarca=j.idmarca where m.id = @id";

                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.Parameters.AddWithValue("@id", id);
                    query.CommandTimeout = 0;
                    using (var dr = query.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                _item = new Maquina
                                {
                                    codigoAlterno = ManejaNulos.ManageNullStr(dr["codigoAlterno"]),
                                    codigoInterno = ManejaNulos.ManageNullStr(dr["codigoInterno"]),
                                    nroSerie = ManejaNulos.ManageNullStr(dr["nroSerie"]),
                                    idMarca = ManejaNulos.ManageNullInteger(dr["idMarca"]),
                                    idModelo = ManejaNulos.ManageNullInteger(dr["idModelo"]),
                                    idJuego = ManejaNulos.ManageNullInteger(dr["idJuego"]),
                                    token = ManejaNulos.ManageNullDecimal(dr["token"]),
                                    ip = ManejaNulos.ManageNullStr(dr["ip"]),
                                    hopper = ManejaNulos.ManageNullInteger(dr["hopper"]),
                                    idMedioJuego = ManejaNulos.ManageNullInteger(dr["idMedioJuego"]),
                                    codIso = ManejaNulos.ManageNullStr(dr["codIso"]),
                                    idDenominacion = ManejaNulos.ManageNullInteger(dr["idDenominacion"]),
                                    idMoneda = ManejaNulos.ManageNullInteger(dr["idMoneda"]),
                                    idTipoMaquina = ManejaNulos.ManageNullInteger(dr["idTipoMaquina"]),
                                    posx = ManejaNulos.ManageNullInteger(dr["posx"]),
                                    posy = ManejaNulos.ManageNullInteger(dr["posy"]),
                                    idFormula = ManejaNulos.ManageNullInteger(dr["idFormula"]),
                                    idFormulaEconomica = ManejaNulos.ManageNullInteger(dr["idFormulaEconomica"]),
                                    porcTeorico = ManejaNulos.ManageNullDecimal(dr["porcTeorico"]),
                                    nuc = ManejaNulos.ManageNullStr(dr["nuc"]),
                                    nuid = ManejaNulos.ManageNullStr(dr["nuid"]),
                                    estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                                    servidor = ManejaNulos.ManageNullInteger(dr["servidor"]),
                                    segmento = ManejaNulos.ManageNullInteger(dr["segmento"]),
                                    tipoconexion = ManejaNulos.ManageNullInteger(dr["tipoconexion"]),
                                    retirotemporal = ManejaNulos.ManageNullInteger(dr["retirotemporal"]),
                                    fechaCreado = ManejaNulos.ManageNullDate(dr["fechaCreado"]),
                                    fechaModificado = ManejaNulos.ManageNullDate(dr["fechaModificado"]),
                                };
                            }
                        }
                        else //No existen datos
                        {
                            _item = new Maquina();
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                _item = null;
            }
            return _item;

        }

        public Maquina GetByCodigoAlterno(string codigoAlterno)
        {
            Maquina _item = new Maquina();

            try
            {
                string consulta = @"SELECT m.id,codigoAlterno,codigoInterno,nroSerie,mar.idMarca,m.idModelo,idJuego,
                                    token,ip,hopper,idMedioJuego,codIso,idDenominacion,idMoneda,idTipoMaquina,
                                    posx,posy,idFormula,idFormulaEconomica,porcTeorico,nuc,nuid,m.estado,
                                    servidor,segmento,tipoconexion,retirotemporal,fechaCreado,fechaModificado
									,J.nombre Juego,mo.nombre Modelo,mar.nombre marca
                                    FROM Maquina m (nolock) 
									inner join Juego j (nolock) on j.id=m.idJuego
									inner join Modelo mo (nolock) on mo.idModelo=m.idModelo
									inner join Marca mar (nolock) on mar.idMarca=j.idmarca where codigoAlterno = @codigoAlterno";

                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.Parameters.AddWithValue("@codigoAlterno", codigoAlterno);
                    query.CommandTimeout = 0;
                    using (var dr = query.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                _item = new Maquina
                                {
                                    codigoAlterno = ManejaNulos.ManageNullStr(dr["codigoAlterno"]),
                                    codigoInterno = ManejaNulos.ManageNullStr(dr["codigoInterno"]),
                                    nroSerie = ManejaNulos.ManageNullStr(dr["nroSerie"]),
                                    idMarca = ManejaNulos.ManageNullInteger(dr["idMarca"]),
                                    idModelo = ManejaNulos.ManageNullInteger(dr["idModelo"]),
                                    idJuego = ManejaNulos.ManageNullInteger(dr["idJuego"]),
                                    token = ManejaNulos.ManageNullDecimal(dr["token"]),
                                    ip = ManejaNulos.ManageNullStr(dr["ip"]),
                                    hopper = ManejaNulos.ManageNullInteger(dr["hopper"]),
                                    idMedioJuego = ManejaNulos.ManageNullInteger(dr["idMedioJuego"]),
                                    codIso = ManejaNulos.ManageNullStr(dr["codIso"]),
                                    idDenominacion = ManejaNulos.ManageNullInteger(dr["idDenominacion"]),
                                    idMoneda = ManejaNulos.ManageNullInteger(dr["idMoneda"]),
                                    idTipoMaquina = ManejaNulos.ManageNullInteger(dr["idTipoMaquina"]),
                                    posx = ManejaNulos.ManageNullInteger(dr["posx"]),
                                    posy = ManejaNulos.ManageNullInteger(dr["posy"]),
                                    idFormula = ManejaNulos.ManageNullInteger(dr["idFormula"]),
                                    idFormulaEconomica = ManejaNulos.ManageNullInteger(dr["idFormulaEconomica"]),
                                    porcTeorico = ManejaNulos.ManageNullDecimal(dr["porcTeorico"]),
                                    nuc = ManejaNulos.ManageNullStr(dr["nuc"]),
                                    nuid = ManejaNulos.ManageNullStr(dr["nuid"]),
                                    estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                                    servidor = ManejaNulos.ManageNullInteger(dr["servidor"]),
                                    segmento = ManejaNulos.ManageNullInteger(dr["segmento"]),
                                    tipoconexion = ManejaNulos.ManageNullInteger(dr["tipoconexion"]),
                                    retirotemporal = ManejaNulos.ManageNullInteger(dr["retirotemporal"]),
                                    fechaCreado = ManejaNulos.ManageNullDate(dr["fechaCreado"]),
                                    fechaModificado = ManejaNulos.ManageNullDate(dr["fechaModificado"]),
                                };
                            }
                        }
                        else //No existen datos
                        {
                            _item = new Maquina();
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                _item = null;
            }
            return _item;

        }

        public List<Maquina> BuscarPorMarca(int idMarca)
        {
            List<Maquina> lista = new List<Maquina>();

            try
            {
                string consulta = @"SELECT m.id,codigoAlterno,codigoInterno,nroSerie,mar.idMarca,m.idModelo,idJuego,
                                    token,ip,hopper,idMedioJuego,codIso,idDenominacion,idMoneda,idTipoMaquina,
                                    posx,posy,idFormula,idFormulaEconomica,porcTeorico,nuc,nuid,m.estado,
                                    servidor,segmento,tipoconexion,retirotemporal,fechaCreado,fechaModificado
									,J.nombre Juego,mo.nombre Modelo,mar.nombre marca
                                    FROM Maquina m (nolock) 
									inner join Juego j (nolock) on j.id=m.idJuego
									inner join Modelo mo (nolock) on mo.idModelo=m.idModelo
									inner join Marca mar (nolock) on mar.idMarca=j.idmarca where mar.idMarca = @idMarca";

                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@idMarca", idMarca);
                    using (var dr = query.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var _item = new Maquina
                                {
                                    codigoAlterno = ManejaNulos.ManageNullStr(dr["codigoAlterno"]),
                                    codigoInterno = ManejaNulos.ManageNullStr(dr["codigoInterno"]),
                                    nroSerie = ManejaNulos.ManageNullStr(dr["nroSerie"]),
                                    idMarca = ManejaNulos.ManageNullInteger(dr["idMarca"]),
                                    idModelo = ManejaNulos.ManageNullInteger(dr["idModelo"]),
                                    idJuego = ManejaNulos.ManageNullInteger(dr["idJuego"]),
                                    token = ManejaNulos.ManageNullDecimal(dr["token"]),
                                    ip = ManejaNulos.ManageNullStr(dr["ip"]),
                                    hopper = ManejaNulos.ManageNullInteger(dr["hopper"]),
                                    idMedioJuego = ManejaNulos.ManageNullInteger(dr["idMedioJuego"]),
                                    codIso = ManejaNulos.ManageNullStr(dr["codIso"]),
                                    idDenominacion = ManejaNulos.ManageNullInteger(dr["idDenominacion"]),
                                    idMoneda = ManejaNulos.ManageNullInteger(dr["idMoneda"]),
                                    idTipoMaquina = ManejaNulos.ManageNullInteger(dr["idTipoMaquina"]),
                                    posx = ManejaNulos.ManageNullInteger(dr["posx"]),
                                    posy = ManejaNulos.ManageNullInteger(dr["posy"]),
                                    idFormula = ManejaNulos.ManageNullInteger(dr["idFormula"]),
                                    idFormulaEconomica = ManejaNulos.ManageNullInteger(dr["idFormulaEconomica"]),
                                    porcTeorico = ManejaNulos.ManageNullDecimal(dr["porcTeorico"]),
                                    nuc = ManejaNulos.ManageNullStr(dr["nuc"]),
                                    nuid = ManejaNulos.ManageNullStr(dr["nuid"]),
                                    estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                                    servidor = ManejaNulos.ManageNullInteger(dr["servidor"]),
                                    segmento = ManejaNulos.ManageNullInteger(dr["segmento"]),
                                    tipoconexion = ManejaNulos.ManageNullInteger(dr["tipoconexion"]),
                                    retirotemporal = ManejaNulos.ManageNullInteger(dr["retirotemporal"]),
                                    fechaCreado = ManejaNulos.ManageNullDate(dr["fechaCreado"]),
                                    fechaModificado = ManejaNulos.ManageNullDate(dr["fechaModificado"]),
                                };
                                lista.Add(_item);

                            }
                        }
                        else //No existen datos
                        {
                            lista = new List<Maquina>();
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

        public List<Maquina> BuscarPorTipoConexion(int idTipoConexion)
        {
            List<Maquina> lista = new List<Maquina>();

            try
            {
                string consulta = @"SELECT m.id,codigoAlterno,codigoInterno,nroSerie,mar.idMarca,m.idModelo,idJuego,
                                    token,ip,hopper,idMedioJuego,codIso,idDenominacion,idMoneda,idTipoMaquina,
                                    posx,posy,idFormula,idFormulaEconomica,porcTeorico,nuc,nuid,m.estado,
                                    servidor,segmento,tipoconexion,retirotemporal,fechaCreado,fechaModificado
									,J.nombre Juego,mo.nombre Modelo,mar.nombre marca
                                    FROM Maquina m (nolock) 
									inner join Juego j (nolock) on j.id=m.idJuego
									inner join Modelo mo (nolock) on mo.idModelo=m.idModelo
									inner join Marca mar (nolock) on mar.idMarca=j.idmarca where tipoconexion = @idTipoConexion";

                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@idTipoConexion", idTipoConexion);
                    using (var dr = query.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var _item = new Maquina
                                {
                                    codigoAlterno = ManejaNulos.ManageNullStr(dr["codigoAlterno"]),
                                    codigoInterno = ManejaNulos.ManageNullStr(dr["codigoInterno"]),
                                    nroSerie = ManejaNulos.ManageNullStr(dr["nroSerie"]),
                                    idMarca = ManejaNulos.ManageNullInteger(dr["idMarca"]),
                                    idModelo = ManejaNulos.ManageNullInteger(dr["idModelo"]),
                                    idJuego = ManejaNulos.ManageNullInteger(dr["idJuego"]),
                                    token = ManejaNulos.ManageNullDecimal(dr["token"]),
                                    ip = ManejaNulos.ManageNullStr(dr["ip"]),
                                    hopper = ManejaNulos.ManageNullInteger(dr["hopper"]),
                                    idMedioJuego = ManejaNulos.ManageNullInteger(dr["idMedioJuego"]),
                                    codIso = ManejaNulos.ManageNullStr(dr["codIso"]),
                                    idDenominacion = ManejaNulos.ManageNullInteger(dr["idDenominacion"]),
                                    idMoneda = ManejaNulos.ManageNullInteger(dr["idMoneda"]),
                                    idTipoMaquina = ManejaNulos.ManageNullInteger(dr["idTipoMaquina"]),
                                    posx = ManejaNulos.ManageNullInteger(dr["posx"]),
                                    posy = ManejaNulos.ManageNullInteger(dr["posy"]),
                                    idFormula = ManejaNulos.ManageNullInteger(dr["idFormula"]),
                                    idFormulaEconomica = ManejaNulos.ManageNullInteger(dr["idFormulaEconomica"]),
                                    porcTeorico = ManejaNulos.ManageNullDecimal(dr["porcTeorico"]),
                                    nuc = ManejaNulos.ManageNullStr(dr["nuc"]),
                                    nuid = ManejaNulos.ManageNullStr(dr["nuid"]),
                                    estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                                    servidor = ManejaNulos.ManageNullInteger(dr["servidor"]),
                                    segmento = ManejaNulos.ManageNullInteger(dr["segmento"]),
                                    tipoconexion = ManejaNulos.ManageNullInteger(dr["tipoconexion"]),
                                    retirotemporal = ManejaNulos.ManageNullInteger(dr["retirotemporal"]),
                                    fechaCreado = ManejaNulos.ManageNullDate(dr["fechaCreado"]),
                                    fechaModificado = ManejaNulos.ManageNullDate(dr["fechaModificado"]),
                                };
                                lista.Add(_item);
                            }
                        }
                        else //No existen datos
                        {
                            lista = new List<Maquina>();
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

        public List<Reporte> MaquinasPorMarca()
        {
            List<Reporte> lista = new List<Reporte>();

            try
            {
                string consulta = @"
                                SELECT DISTINCT TOP 10  m.idMarca, m.nombre, COUNT(*) as 'cantidad' FROM dbo.Maquina (NOLOCK) maq
										inner join Juego j (nolock) on j.id=maq.idJuego
                                INNER JOIN Marca m (NOLOCK) ON j.idMarca = m.idMarca
                                GROUP BY m.idMarca, m.nombre
                                ORDER BY COUNT(*) desc";

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
                                var _item = new Reporte
                                {
                                    categoria = ManejaNulos.ManageNullStr(dr["nombre"]),
                                    valor1 = ManejaNulos.ManageNullInteger(dr["cantidad"]),
                                    valor2 = ManejaNulos.ManageNullInteger(dr["idMarca"]),
                                };
                                lista.Add(_item);
                            }
                        }
                        else //No existen datos
                        {
                            lista = new List<Reporte>();
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

        public List<Reporte> MaquinasPorTipoConexion()
        {
            List<Reporte> lista = new List<Reporte>();

            try
            {
                string consulta = @"SELECT DISTINCT TOP 10  maq.tipoconexion, t.nombre, COUNT(*) FROM dbo.Maquina (NOLOCK) maq
                                    INNER JOIN dbo.tipoconexion t (NOLOCK) ON maq.tipoconexion = t.idTipoConexion
                                    GROUP BY maq.tipoconexion, t.nombre
                                    ORDER BY COUNT(*) desc";

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
                                var _item = new Reporte
                                {
                                    categoria = ManejaNulos.ManageNullStr(dr["nombre"]),
                                    valor1 = ManejaNulos.ManageNullInteger(dr["cantidad"]),
                                    valor2 = ManejaNulos.ManageNullInteger(dr["idMarca"]),
                                };
                                lista.Add(_item);
                            }
                        }
                        else //No existen datos
                        {
                            lista = new List<Reporte>();
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

        public Boolean Create(Maquina item)
        {
            Boolean estado = false;

            string consulta = @"
                    INSERT INTO dbo.Maquina (codigoAlterno,codigoInterno,nroSerie,idModelo
                    ,idJuego,token,ip,hopper,idMedioJuego,codIso,idDenominacion,idMoneda
                    ,idTipoMaquina,posx,posy,idFormula,idFormulaEconomica,porcTeorico
                    ,nuc,nuid,estado,servidor,segmento,tipoconexion,retirotemporal,fechaCreado,fechaModificado, idSala)

                    VALUES (@codigoAlterno, @codigoInterno, @nroSerie, @idModelo
                    , @idJuego, @token, @ip, @hopper, @idMedioJuego, @codIso, @idDenominacion, @idMoneda
                    , @idTipoMaquina, @posx, @posy, @idFormula, @idFormulaEconomica, @porcTeorico
                    , @nuc, @nuid, @estado, @servidor, @segmento, @tipoconexion, @retirotemporal, @fechaCreado, @fechaModificado, @idSala)";

            try
            {

                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@codigoAlterno", item.codigoAlterno);
                    query.Parameters.AddWithValue("@codigoInterno", item.codigoInterno);
                    query.Parameters.AddWithValue("@nroSerie", item.nroSerie);
                    query.Parameters.AddWithValue("@idModelo", item.idModelo);
                    query.Parameters.AddWithValue("@idJuego", item.idJuego);
                    query.Parameters.AddWithValue("@token", item.token);
                    query.Parameters.AddWithValue("@ip", item.ip);
                    query.Parameters.AddWithValue("@hopper", item.hopper);
                    query.Parameters.AddWithValue("@idMedioJuego", item.idMedioJuego);
                    query.Parameters.AddWithValue("@codIso", item.codIso);
                    query.Parameters.AddWithValue("@idDenominacion", item.idDenominacion);
                    query.Parameters.AddWithValue("@idMoneda", item.idMoneda);
                    query.Parameters.AddWithValue("@idTipoMaquina", item.idTipoMaquina);
                    query.Parameters.AddWithValue("@posx", item.posx);
                    query.Parameters.AddWithValue("@posy", item.posy);
                    query.Parameters.AddWithValue("@idFormula", item.idFormula);
                    query.Parameters.AddWithValue("@idFormulaEconomica", item.idFormulaEconomica);
                    query.Parameters.AddWithValue("@porcTeorico", item.porcTeorico);
                    query.Parameters.AddWithValue("@nuc", item.nuc);
                    query.Parameters.AddWithValue("@nuid", item.nuid);
                    query.Parameters.AddWithValue("@estado", item.estado);
                    query.Parameters.AddWithValue("@servidor", item.servidor);
                    query.Parameters.AddWithValue("@segmento", item.segmento);
                    query.Parameters.AddWithValue("@tipoconexion", item.tipoconexion);
                    query.Parameters.AddWithValue("@retirotemporal", item.retirotemporal);
                    query.Parameters.AddWithValue("@fechaCreado", item.fechaCreado);
                    query.Parameters.AddWithValue("@fechaModificado", item.fechaModificado);
                    query.Parameters.AddWithValue("@idSala", item.idSala);

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

        public Boolean Update(Maquina item)
        {
            Boolean estado = false;

            string consulta = @"
                    Update Maquina set codigoAlterno=@codigoAlterno,
                                        codigoInterno=@codigoInterno,
                                        nroSerie=@nroSerie,
                                        idModelo=@idModelo,
                                        idJuego=@idJuego,
                                        token=@token,
                                        ip=@ip,
                                        hopper=@hopper,
                                        idMedioJuego=@idMedioJuego,
                                        codIso=@codIso,
                                        idDenominacion=@idDenominacion,
                                        idMoneda=@idMoneda,
                                        idTipoMaquina=@idTipoMaquina,
                                        posx=@posx,
                                        posy=@posy,
                                        idFormula=@idFormula,
                                        idFormulaEconomica=@idFormulaEconomica,
                                        porcTeorico=@porcTeorico,
                                        nuc=@nuc,
                                        nuid=@nuid,
                                        estado=@estado,
                                        servidor=@servidor,
                                        segmento=@segmento,
                                        tipoconexion=@tipoconexion,
                                        retirotemporal=@retirotemporal,
                                        fechaCreado=@fechaCreado,
                                        fechaModificado=@fechaModificado,
                                        idSala = @idSala
                    WHERE id = @id
                                        ";

            try
            {

                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@id", item.id);
                    query.Parameters.AddWithValue("@codigoAlterno", item.codigoAlterno);
                    query.Parameters.AddWithValue("@codigoInterno", item.codigoInterno);
                    query.Parameters.AddWithValue("@nroSerie", item.nroSerie);
                    query.Parameters.AddWithValue("@idModelo", item.idModelo);
                    query.Parameters.AddWithValue("@idJuego", item.idJuego);
                    query.Parameters.AddWithValue("@token", item.token);
                    query.Parameters.AddWithValue("@ip", item.ip);
                    query.Parameters.AddWithValue("@hopper", item.hopper);
                    query.Parameters.AddWithValue("@idMedioJuego", item.idMedioJuego);
                    query.Parameters.AddWithValue("@codIso", item.codIso);
                    query.Parameters.AddWithValue("@idDenominacion", item.idDenominacion);
                    query.Parameters.AddWithValue("@idMoneda", item.idMoneda);
                    query.Parameters.AddWithValue("@idTipoMaquina", item.idTipoMaquina);
                    query.Parameters.AddWithValue("@posx", item.posx);
                    query.Parameters.AddWithValue("@posy", item.posy);
                    query.Parameters.AddWithValue("@idFormula", item.idFormula);
                    query.Parameters.AddWithValue("@idFormulaEconomica", item.idFormulaEconomica);
                    query.Parameters.AddWithValue("@porcTeorico", item.porcTeorico);
                    query.Parameters.AddWithValue("@nuc", item.nuc);
                    query.Parameters.AddWithValue("@nuid", item.nuid);
                    query.Parameters.AddWithValue("@estado", item.estado);
                    query.Parameters.AddWithValue("@servidor", item.servidor);
                    query.Parameters.AddWithValue("@segmento", item.segmento);
                    query.Parameters.AddWithValue("@tipoconexion", item.tipoconexion);
                    query.Parameters.AddWithValue("@retirotemporal", item.retirotemporal);
                    query.Parameters.AddWithValue("@fechaCreado", item.fechaCreado);
                    query.Parameters.AddWithValue("@fechaModificado", item.fechaModificado);
                    query.Parameters.AddWithValue("@idSala", item.idSala);

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

        public Boolean UpdateMaquina(Maquina item)
        {
            Boolean estado = false;

            string consulta = @"
                    Update Maquina set 
                                        codigoInterno=@codigoInterno,
                                        nroSerie=@nroSerie,
                                        idModelo=@idModelo,
                                        idJuego=@idJuego,
                                        token=@token,
                                        ip=@ip,
                                        hopper=@hopper,
                                        idMedioJuego=@idMedioJuego,
                                        codIso=@codIso,
                                        idDenominacion=@idDenominacion,
                                        idMoneda=@idMoneda,
                                        idTipoMaquina=@idTipoMaquina,
                                        posx=@posx,
                                        posy=@posy,
                                        idFormula=@idFormula,
                                        idFormulaEconomica=@idFormulaEconomica,
                                        porcTeorico=@porcTeorico,
                                        nuc=@nuc,
                                        nuid=@nuid,
                                        estado=@estado,
                                        servidor=@servidor,
                                        segmento=@segmento,
                                        tipoconexion=@tipoconexion,
                                        retirotemporal=@retirotemporal,
                                        fechaCreado=@fechaCreado,
                                        fechaModificado=@fechaModificado
                    WHERE codigoAlterno = @codigoAlterno and idSala = @idSala
                                        ";

            try
            {

                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@id", item.id);
                    query.Parameters.AddWithValue("@codigoAlterno", item.codigoAlterno);
                    query.Parameters.AddWithValue("@codigoInterno", item.codigoInterno);
                    query.Parameters.AddWithValue("@nroSerie", item.nroSerie);
                    query.Parameters.AddWithValue("@idModelo", item.idModelo);
                    query.Parameters.AddWithValue("@idJuego", item.idJuego);
                    query.Parameters.AddWithValue("@token", item.token);
                    query.Parameters.AddWithValue("@ip", item.ip);
                    query.Parameters.AddWithValue("@hopper", item.hopper);
                    query.Parameters.AddWithValue("@idMedioJuego", item.idMedioJuego);
                    query.Parameters.AddWithValue("@codIso", item.codIso);
                    query.Parameters.AddWithValue("@idDenominacion", item.idDenominacion);
                    query.Parameters.AddWithValue("@idMoneda", item.idMoneda);
                    query.Parameters.AddWithValue("@idTipoMaquina", item.idTipoMaquina);
                    query.Parameters.AddWithValue("@posx", item.posx);
                    query.Parameters.AddWithValue("@posy", item.posy);
                    query.Parameters.AddWithValue("@idFormula", item.idFormula);
                    query.Parameters.AddWithValue("@idFormulaEconomica", item.idFormulaEconomica);
                    query.Parameters.AddWithValue("@porcTeorico", item.porcTeorico);
                    query.Parameters.AddWithValue("@nuc", item.nuc);
                    query.Parameters.AddWithValue("@nuid", item.nuid);
                    query.Parameters.AddWithValue("@estado", item.estado);
                    query.Parameters.AddWithValue("@servidor", item.servidor);
                    query.Parameters.AddWithValue("@segmento", item.segmento);
                    query.Parameters.AddWithValue("@tipoconexion", item.tipoconexion);
                    query.Parameters.AddWithValue("@retirotemporal", item.retirotemporal);
                    query.Parameters.AddWithValue("@fechaCreado", item.fechaCreado);
                    query.Parameters.AddWithValue("@fechaModificado", item.fechaModificado);
                    query.Parameters.AddWithValue("@idSala", item.idSala);

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

            string consulta = @" Delete from Maquina WHERE id = @id";

            try
            {
                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
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
