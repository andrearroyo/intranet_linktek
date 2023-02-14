using System.Data.SqlClient;
using Models_core;

namespace Data_core
{
    public class FormulaDA
    {
        string _conexion = string.Empty;

        public FormulaDA(string cadena)
        {
            Connection.conexion = (String.IsNullOrEmpty(Connection.conexion)) ? cadena : Connection.conexion;
            _conexion = Connection.conexion;
        }
        public List<Formula> GetAllFormula()
        {
            List<Formula> lista = new List<Formula>();

            try
            {
                string consulta = @"SELECT idFormula, formulaEconomica, coinIn, coinOut, cancelCredits, jackpot, reserva1, estado FROM dbo.Formula (NOLOCK)";

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
                                var item = new Formula
                                {
                                    id = ManejaNulos.ManageNullInteger(dr["idFormula"]),
                                    formulaeconomica = ManejaNulos.ManageNullStr(dr["formulaEconomica"]),
                                    CoinIn = ManejaNulos.ManageNullStr(dr["coinIn"]),
                                    CoinOut = ManejaNulos.ManageNullStr(dr["coinOut"]),
                                    CancelCredits = ManejaNulos.ManageNullStr(dr["cancelCredits"]),
                                    Jackpot = ManejaNulos.ManageNullStr(dr["jackpot"]),
                                    Reserva1 = ManejaNulos.ManageNullStr(dr["reserva1"]),
                                    estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                                };
                                lista.Add(item);
                            }
                        }
                        else //No existen datos
                        {
                            lista = new List<Formula>();
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
        public Formula GetFormulaId(string id)
        {
            Formula item = new Formula();

            try
            {
                string consulta = @"SELECT idFormula, formulaEconomica, coinIn, coinOut, cancelCredits, jackpot, reserva1, estado FROM dbo.Formula (NOLOCK) 
                                    where idFormula = @idFormula";

                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@idFormula", id);
                    using (var dr = query.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                item = new Formula
                                {
                                    id = ManejaNulos.ManageNullInteger(dr["idFormula"]),
                                    formulaeconomica = ManejaNulos.ManageNullStr(dr["formulaEconomica"]),
                                    CoinIn = ManejaNulos.ManageNullStr(dr["coinIn"]),
                                    CoinOut = ManejaNulos.ManageNullStr(dr["coinOut"]),
                                    CancelCredits = ManejaNulos.ManageNullStr(dr["cancelCredits"]),
                                    Jackpot = ManejaNulos.ManageNullStr(dr["jackpot"]),
                                    Reserva1 = ManejaNulos.ManageNullStr(dr["reserva1"]),
                                    estado = ManejaNulos.ManageNullInteger(dr["estado"]),
                                };
                            }
                        }
                        else //No existen datos
                        {
                            item = new Formula();
                        }
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
        public Boolean Create(Formula item)
        {
            Boolean estado = false;

            string consulta = @"
                    Insert into Formula (formulaEconomica, coinIn, coinOut, cancelCredits, jackpot, reserva1,  estado)
                    values (@formulaEconomica, @coinIn, @coinOut, @cancelCredits, @jackpot, @reserva1,  @estado)";

            try
            {

                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@formulaEconomica", item.formulaeconomica);
                    query.Parameters.AddWithValue("@coinIn", item.CoinIn);
                    query.Parameters.AddWithValue("@coinOut", item.CoinOut);
                    query.Parameters.AddWithValue("@cancelCredits", item.CancelCredits);
                    query.Parameters.AddWithValue("@jackpot", item.Jackpot);
                    query.Parameters.AddWithValue("@reserva1", item.Reserva1);
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
        public Boolean Update(Formula item)
        {
            Boolean estado = false;

            string consulta = @"
                    Update Formula
                            formulaEconomica = @formulaEconomica,
                            coinIn = @coinIn,
                            coinIn = @coinIn,
                            coinOut = @coinOut,
                            cancelCredis = @cancelCredis,
                            jackpot = @jackpot,
                            reserva1 = @reserva1,
                            estado = @estado
                    WHERE idFormula = @idFormula";

            try
            {

                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@idFormula", item.id);
                    query.Parameters.AddWithValue("@formulaEconomica", item.formulaeconomica);
                    query.Parameters.AddWithValue("@coinIn", item.CoinIn);
                    query.Parameters.AddWithValue("@coinOut", item.CoinOut);
                    query.Parameters.AddWithValue("@cancelCredits", item.CancelCredits);
                    query.Parameters.AddWithValue("@jackpot", item.Jackpot);
                    query.Parameters.AddWithValue("@reserva1", item.Reserva1);
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

            string consulta = @" Delete from Formula WHERE idFormula = @idFormula";

            try
            {
                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.CommandTimeout = 0;
                    query.Parameters.AddWithValue("@idFormula", id);

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
