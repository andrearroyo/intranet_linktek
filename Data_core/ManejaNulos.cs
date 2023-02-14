using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Data_core
{
    public class ManejaNulos
    {
        public static string checksum(byte[] val, int cant)
        {
            byte crct = 0;
            for (int i = 0; i < cant; i++)
            {
                crct = (byte)(crct ^ val[i]);
            }
            return string.Format("{0:X2}", crct);
        }
        public static string crc_xmodem(byte[] val, int cant)
        {
            byte crct = 0;
            for (int i = 0; i < cant; i++)
            {
                crct = (byte)(crct ^ val[i]);
            }
            return string.Format("{0:X2}", crct);
        }
        public static string crc_xmodem1(byte[] val, int cant)
        {
            int _crc = 0, _c;
            for (int i = 0; i < cant; i++)
            {
                _c = val[i];
                _crc = (Int16)(_crc ^ (_c << 8));
                for (int j = 0; j < 8; j++)
                {
                    if ((_crc & 0x8000) != 0) { _crc = (Int16)((_crc << 1) ^ 0x1021); }
                    else { _crc = (Int16)(_crc << 1); }
                }
            }
            Int16 Retorna = (Int16)_crc;
            return Retorna.ToString("X4");
        }
        public static string crc_xmodem2(byte[] val, int cant)
        {
            int _crc = 0, _c;
            for (int i = 0; i < cant; i++)
            {
                _c = val[i];
                _crc = (Int16)(_crc ^ (_c << 8));
                for (int j = 0; j < 8; j++)
                {
                    if ((_crc & 0x8000) != 0) { _crc = (Int16)((_crc << 1) ^ 0x1021); }
                    else { _crc = (Int16)(_crc << 1); }
                }
            }
            string temp = string.Format("{0:X2}", _crc);
            if (temp.Length == 3) { temp = "0" + temp; }
            if (temp.Length == 2) { temp = "00" + temp; }
            if (temp.Length > 4) { temp = temp.Substring(temp.Length - 4, 4); }
            string valor;
            try
            {
                valor = ToHexa(temp);
            }
            catch
            {
                return "00";
            }
            return valor.ToString();
        }
        public static int HexToInt(string hexString)
        {
            return int.Parse(hexString, System.Globalization.NumberStyles.HexNumber, null);
        }//ok
        public static String ToHexa(String valor)
        {
            UInt64 uiDecimal = 0;
            uiDecimal = checked((UInt64)System.Convert.ToUInt64(valor));
            return String.Format("{0:x2}", uiDecimal);
        }

        public ManejaNulos()
        {

        }
        public static CultureInfo Culture_Info = new CultureInfo("es-PE");
        public static string Numero(string Maquina, DateTime Calendario)
        {
            int year = Calendario.Year;
            string Mes = Completar(Calendario.Month.ToString(), 2, "0");
            string Dia = Completar(Calendario.Day.ToString(), 2, "0");
            string hora = Completar(Calendario.Hour.ToString(), 2, "0");
            string minuto = Completar(Calendario.Minute.ToString(), 2, "0");
            string segundo = Completar(Calendario.Second.ToString(), 2, "0");
            string Numero = string.Format("{0}{1}{2}{3}{4}{5}{6}", Maquina, year, Mes, Dia, hora, minuto, segundo);
            return Numero;
        }
        public static string Completar(string parametro, int largo, string variable)
        {
            string Valor = parametro;
            if (largo < parametro.Length)
            {
                int remover = parametro.Length - largo;
                Valor = parametro.Remove(0, remover);
            }

            while (largo > Valor.Length)
            {
                Valor = Valor.Insert(0, variable);
            }
            return Valor;

        }

        public static string Cadena(string Parametro, int Cantidad, string variable)
        {
            string Valor = Parametro;
            if (Cantidad <= 0)
            {
                return Valor;
            }

            int i = 0;
            while (Cantidad > i)
            {
                i++;
                Valor = Valor.Insert(0, variable);
            }
            return Valor;
        }
        /// <summary>
        /// Controla si un elemento es Nulo
        /// </summary>
        /// <param name="aValue">Objeto a ser verificado</param>
        /// <returns>Devuelve cero si es Null</returns>
        public static long ManageNullLng(System.Object aValue)
        {

            if (Convert.IsDBNull(aValue))
            {
                return -1;
            }
            else
            {
                return Convert.ToInt64(aValue);
            }
        }
        public static bool ManegeNullBool(System.Object aValue)
        {
            if (Convert.IsDBNull(aValue))
            {
                return false;
            }
            else
            {
                return Convert.ToBoolean(aValue);
            }
        }
        public static bool ManegeNullBool(string aValue)
        {
            if (Convert.IsDBNull(aValue))
            {
                return false;
            }
            else
            {
                return Convert.ToBoolean(aValue);
            }
        }
        /// <summary>
        /// Control si un elemento es Nulo
        /// </summary>
        /// <param name="aValue">Objeto a ser verificado</param>
        /// <returns>Devuelve una cadena vacia si es Null</returns>
        public static string ManageNullStr(System.Object aValue)
        {
            //IsDBNull(aValue) 
            if (Convert.IsDBNull(aValue))
            {
                return String.Empty;
            }
            else
            {
                return Convert.ToString(aValue);
            }

        }
        public static TimeSpan ManageNullTimespan(System.Object aValue)
        {
            //IsDBNull(aValue) 
            if (Convert.IsDBNull(aValue))
            {
                return TimeSpan.Zero;
            }
            else
            {
                return (TimeSpan)aValue;
            }

        }
        /// <summary>
        /// Controla si un Formato es Nula
        /// </summary>
        /// <param name="aValue">es el objeto a controlar</param>
        /// <returns>Devuelve una Fecha </returns>
        public static DateTime ManageNullDate(System.Object aValue)
        {
            if (Convert.IsDBNull(aValue))
            {
                return DateTime.Parse("01/01/1753");
            }
            else
            {
                return Convert.ToDateTime(aValue);
            }
        }
        public static int ManageNullInteger(string aValue)
        {
            if (string.IsNullOrEmpty(aValue))
            {
                return short.Parse("0");
            }
            else
            {
                return Convert.ToInt32(aValue);
            }
        }
        public static int ManageNullInteger(System.Object aValue)
        {
            if (Convert.IsDBNull(aValue))
            {
                return short.Parse("0");
            }
            else
            {
                return Convert.ToInt32(aValue);
            }
        }

        public static Int64 ManageNullInteger64(System.Object aValue)
        {
            if (Convert.IsDBNull(aValue))
            {
                return short.Parse("0");
            }
            else
            {
                return Convert.ToInt64(aValue);
            }
        }

        public static int ManageNullIntegerM1(System.Object aValue)
        {
            if (Convert.IsDBNull(aValue))
            {
                return short.Parse("0");
            }
            else
            {
                return Convert.ToInt32(aValue);
            }
        }
        public static double ManageNullDouble(string aValue)
        {
            if (aValue.Equals(string.Empty))
            {
                return short.Parse("0");
            }
            else
            {
                return Convert.ToDouble(aValue);
            }
        }
        public static Double ManageNullDouble(System.Object aValue)
        {
            if (Convert.IsDBNull(aValue))
            {
                return short.Parse("0");
            }
            else
            {
                return Convert.ToDouble(aValue);
            }
        }
        public static string CambiosFormulasConcidentes(string Formula)
        {
            return Formula.ToLower().Replace(("TrueCoinOut").ToLower(), "ctcoo").Replace(("TrueCoinIn").ToLower(), "ctcoi");
        }
        public static short ManageNullShort(string aValue)
        {
            if (aValue.Equals(string.Empty))
            {
                return short.Parse("0");
            }
            else
            {
                return Convert.ToInt16(aValue);
            }
        }
        public static decimal ManageNullDecimal(string aValue)
        {
            if (string.IsNullOrEmpty(aValue))
            {
                return decimal.Parse("0.0", Culture_Info);
            }
            else
            {
                return Convert.ToDecimal(aValue);
            }
        }
        /// <summary>
        /// Controla si un Formato es Nula
        /// </summary>
        /// <param name="aValue">es el cadena a controlar</param>
        /// <returns>Devuelve una Fecha </returns>
        public static DateTime ManageNullDate(string aValue)
        {
            if (aValue.Equals(string.Empty))
            {
                return DateTime.Parse("01/01/1753");
            }
            else
            {
                return Convert.ToDateTime(aValue); //DateTime.ParseExact(aValue, "MM/dd/yyyy",new CultureInfo("en-US") );
            }
        }
        public static float ManageNullFloat(System.Object aValue)
        {

            if (Convert.IsDBNull(aValue))
            {
                return 0;
            }
            else
            {
                return Convert.ToSingle(aValue);
            }
        }
        public static float ManageNullFloat(string aValue)
        {

            if (aValue.Equals(string.Empty))
            {
                return 0;
            }
            else
            {
                return Convert.ToSingle(aValue);
            }
        }
        public string MonthShort()
        {
            string TodayDate = DateTime.Now.Day + ShortMonth() + ShortYear();
            return (TodayDate);

        }
        public string ShortMonth()
        {
            string sMonth;
            //set new month values
            if (DateTime.Now.Month == 1)
            {
                sMonth = "ENE";
            }
            else if (DateTime.Now.Month == 2)
            {
                sMonth = "FEB";
            }
            else if (DateTime.Now.Month == 3)
            {
                sMonth = "MAR";
            }
            else if (DateTime.Now.Month == 4)
            {
                sMonth = "ABR";
            }
            else if (DateTime.Now.Month == 5)
            {
                sMonth = "MAY";
            }
            else if (DateTime.Now.Month == 6)
            {
                sMonth = "JUN";
            }
            else if (DateTime.Now.Month == 7)
            {
                sMonth = "JUL";
            }
            else if (DateTime.Now.Month == 8)
            {
                sMonth = "AGO";
            }
            else if (DateTime.Now.Month == 9)
            {
                sMonth = "SEP";
            }
            else if (DateTime.Now.Month == 10)
            {
                sMonth = "OCT";
            }
            else if (DateTime.Now.Month == 11)
            {
                sMonth = "NOV";
            }
            else //if( DateTime.Now.Month == 12 )
            {
                sMonth = "DIC";
            }

            return (sMonth);

        }
        public string ShortYear()
        {
            string sYear = Convert.ToString(DateTime.Now.Year);
            return sYear.Substring(2, 2);
        }

        /// <summary>
        /// Devuelve Los Nombres de las Propiedades de la Clase
        /// </summary>
        /// <param name="obj">Objeto del que se quiere obtener la información</param>
        /// <returns>devuelve los nombres de las Propiedades</returns>
        public static String[] GetFieldNames(object obj)
        {
            BindingFlags flags = BindingFlags.Instance
               | BindingFlags.Public
               | BindingFlags.DeclaredOnly
               | BindingFlags.Static;
            Type t;



            long i;

            string[] sOut; //Array de salida

            t = obj.GetType(); //Se obtiene el tipo

            PropertyInfo[] fInfo = t.GetProperties(flags);//Se obtienen los campos

            sOut = new string[fInfo.GetLength(0)];
            int tope = fInfo.GetLength(0);
            for (i = 0; i < tope; i++)
            {

                //Se añade el nombre de cada uno de los campos

                //al array de salida

                sOut[i] = fInfo[i].Name;

            }

            return sOut;

        }

        /// <summary>
        /// Devuelve un array(1D o 2D) con los nombres y/o valores de las Propiedades de un determinado objeto.
        /// </summary>
        /// <param name="obj">Objeto del que se quiere obtener la información        
        /// </param>
        /// <param name="returnData">- 1: devuelve los nombres de las Propiedades (Default)
        ///                          - 2: devuelve los valores de las Propiedades
        ///                          - 3: Nombres + Valores
        ///</param>
        /// <returns>1D/2D String array con los nombres y/o valores</returns>
        public static Array GetFieldNamesValues(object obj, int returnData)
        {
            BindingFlags flags = BindingFlags.Instance
                | BindingFlags.Public
                | BindingFlags.DeclaredOnly
                | BindingFlags.Static;
            Type t;

            long i;
            t = obj.GetType();
            //FieldInfo[] fInfo = t.GetFields(flags);
            PropertyInfo[] fInfo = t.GetProperties(flags);

            switch (returnData)
            {
                case 1:
                    //FieldNames
                    String[] sOut = new String[fInfo.GetLength(0)];
                    for (i = 0; i < fInfo.GetLength(0); i++)
                    {
                        sOut[i] = fInfo[i].Name;
                    }
                    return sOut;

                case 2:
                    //FieldValues
                    String[] sOut1 = new String[fInfo.GetLength(0)];
                    for (i = 0; i < fInfo.GetLength(0); i++)
                    {
                        if (fInfo[i].GetValue(obj, null) is DateTime)
                        {
                            sOut1[i] = ManejaNulos.ManageNullDate(fInfo[i].GetValue(obj, null).ToString()).ToShortDateString();
                        }
                        else
                        {
                            sOut1[i] = ManageNullStr(fInfo[i].GetValue(obj, null));
                        }
                    }
                    return sOut1;
                case 3:
                    //Both
                    string[,] sOut2 = new string[fInfo.GetLength(0), 2];
                    for (i = 0; i < fInfo.GetLength(0); i++)
                    {
                        sOut2[i, 0] = fInfo[i].Name;
                        if (fInfo[i].GetValue(obj, null) is DateTime)
                        {
                            sOut2[i, 1] = ManejaNulos.ManageNullDate(fInfo[i].GetValue(obj, null).ToString()).ToShortDateString();
                        }
                        else
                        {
                            sOut2[i, 1] = ManageNullStr(fInfo[i].GetValue(obj, null));
                        }
                    }
                    return sOut2;
            }
            var objRef1 = new object[0];
            return objRef1;
        }

        /// <summary>
        /// Devuelve Los Nombres de las Atributos de la Clase
        /// </summary>
        /// <param name="obj">Objeto del que se quiere obtener la información</param>
        /// <returns>devuelve los nombres de las Propiedades</returns>
        public static String[] aGetFieldNames(object obj)
        {
            BindingFlags flags = BindingFlags.Instance
               | BindingFlags.Public
               | BindingFlags.NonPublic
               | BindingFlags.DeclaredOnly
               | BindingFlags.Static;
            Type t;



            long i;

            List<string> sOut = new List<string>(); //Array de salida

            t = obj.GetType(); //Se obtiene el tipo


            FieldInfo[] fInfo = t.GetFields(flags);//Se obtienen los campos

            int tope = fInfo.GetLength(0);
            for (i = 0; i < tope; i++)
            {

                //Se añade el nombre de cada uno de los campos

                //al array de salida
                if (!fInfo[i].Name.Contains("_BackingField"))
                {
                    sOut.Add(fInfo[i].Name.Remove(0, 1));
                }

            }

            return sOut.ToArray();

        }

        /// <summary>
        /// Devuelve un array(1D o 2D) con los nombres y/o valores de las Campos de un determinado objeto.
        /// </summary>
        /// <param name="obj">Objeto del que se quiere obtener la información        
        /// </param>
        /// <param name="returnData">- 1: devuelve los nombres de las Campos (Default)
        ///                          - 2: devuelve los valores de las Campos
        ///                          - 3: Nombres + Valores
        ///</param>
        /// <returns>1D/2D String array con los nombres y/o valores</returns>
        public static Array aGetFieldNamesValues(object obj, int returnData)
        {
            BindingFlags flags = BindingFlags.Instance
               | BindingFlags.Public
               | BindingFlags.NonPublic
               | BindingFlags.DeclaredOnly
               | BindingFlags.Static;
            Type t;

            long i;
            t = obj.GetType();
            FieldInfo[] fInfo = t.GetFields(flags);

            switch (returnData)
            {
                case 1:
                    //FieldNames
                    List<string> sOut = new List<string>();
                    for (i = 0; i < fInfo.GetLength(0); i++)
                    {
                        if (!fInfo[i].Name.Contains("_BackingField"))
                        {
                            sOut.Add(fInfo[i].Name.Remove(0, 1));
                        }
                    }
                    return sOut.ToArray();

                case 2:
                    //FieldValues
                    List<string> sOut1 = new List<string>();
                    for (i = 0; i < fInfo.GetLength(0); i++)
                    {
                        if (!fInfo[i].Name.Contains("_BackingField"))
                        {
                            if (fInfo[i].GetValue(obj) is DateTime)
                            {
                                sOut1.Add(ManejaNulos.ManageNullDate(fInfo[i].GetValue(obj).ToString()).ToShortDateString());
                            }
                            else
                            {
                                sOut1.Add(ManageNullStr(fInfo[i].GetValue(obj)));
                            }
                        }
                    }
                    return sOut1.ToArray();
                case 3:
                    //Both   
                    int Total = 0;
                    for (i = 0; i < fInfo.GetLength(0); i++)
                    {
                        if (!fInfo[i].Name.Contains("_BackingField"))
                        {
                            Total++;
                        }
                    }
                    string[,] sOut2 = new string[Total, 2];
                    for (i = 0; i < fInfo.GetLength(0); i++)
                    {
                        if (!fInfo[i].Name.Contains("_BackingField"))
                        {
                            sOut2[i, 0] = fInfo[i].Name;
                            if (fInfo[i].GetValue(obj) is DateTime)
                            {
                                sOut2[i, 1] = ManejaNulos.ManageNullDate(fInfo[i].GetValue(obj).ToString()).ToShortDateString();
                            }
                            else
                            {
                                sOut2[i, 1] = ManageNullStr(fInfo[i].GetValue(obj));
                            }
                        }
                    }
                    return sOut2;
            }
            var objRef1 = new object[0];
            return objRef1;
        }

        public static Nullable<T> DbValueToNullable<T>(Object dbValue) where T : struct
        {
            Nullable<T> returnValue = null;
            if (dbValue != null && !dbValue.Equals(DBNull.Value))
            {
                returnValue = (T)dbValue;
            }
            return returnValue;
        }

        public static string ajustar(int tam, object valor, string simbolo)
        {
            string numtmp = valor.ToString();
            while (numtmp.Length < tam)
                numtmp = simbolo + numtmp;
            return numtmp;
        }

        public static decimal ManageNullDecimal(object aValue)
        {
            if (Convert.IsDBNull(aValue))
            {
                return short.Parse("0");
            }
            else
            {
                return Convert.ToDecimal(aValue);
            }
        }

        public static string ObtenerValorPropiedad(string NomPropiedad, object obj)
        {
            string Valor = string.Empty;
            BindingFlags flags = BindingFlags.Instance
                | BindingFlags.Public
                | BindingFlags.DeclaredOnly
                | BindingFlags.Static;
            Type t;


            t = obj.GetType();
            PropertyInfo[] fInfo = t.GetProperties(flags);

            var linPro = (from p in fInfo
                          where p.Name.ToLower() == NomPropiedad.Trim().ToLower()
                          select p).FirstOrDefault();
            if (linPro == null)
            {
                return string.Empty;
            }

            Valor = ManageNullStr(linPro.GetValue(obj, null));
            return Valor;
        }

        public static T Valores<T>(object dbValue) where T : struct
        {
            if (dbValue == null && dbValue.Equals(DBNull.Value))
            {
                return default(T);
            }
            else
            {
                TypeConverter conv = TypeDescriptor.GetConverter(typeof(T));
                return (T)conv.ConvertFrom(dbValue.ToString());
            }
        }

        public static byte[] ObtenerBinarios(System.Data.IDataReader dr, int posTrama)
        {
            //dr.GetOrdinal["Trama"]
            byte[] trama = null;
            long tamBlob = dr.GetBytes(posTrama, 0, null, 0, 0); //Al hacer el SELECT Trama es la indice 3
            if (tamBlob > 0)
            {
                trama = new byte[tamBlob];
                long tamBytesLeer = 0;
                int pos = 0;
                int tamPedazo = 1024;

                while (tamBytesLeer < tamBlob)
                {
                    if ((tamBytesLeer + tamPedazo) > tamBlob)
                    {
                        tamPedazo = (int)(tamBlob - tamBytesLeer);

                    }
                    tamBytesLeer += dr.GetBytes(posTrama, pos, trama, pos, tamPedazo);
                    pos += tamPedazo;
                }
            }
            return trama;
        }

        public static byte[] ObtenerBinarios(System.Data.Common.DbDataReader dr, int posTrama)
        {
            //dr.GetOrdinal["Trama"]
            byte[] trama = null;
            long tamBlob = dr.GetBytes(posTrama, 0, null, 0, 0); //Al hacer el SELECT Trama es la indice 3
            if (tamBlob > 0)
            {
                trama = new byte[tamBlob];
                long tamBytesLeer = 0;
                int pos = 0;
                int tamPedazo = 1024;

                while (tamBytesLeer < tamBlob)
                {
                    if ((tamBytesLeer + tamPedazo) > tamBlob)
                    {
                        tamPedazo = (int)(tamBlob - tamBytesLeer);

                    }
                    tamBytesLeer += dr.GetBytes(posTrama, pos, trama, pos, tamPedazo);
                    pos += tamPedazo;
                }
            }
            return trama;
        }
    }
}
