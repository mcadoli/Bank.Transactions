
using System;
using System.Configuration;
using System.IO;
namespace Transactions.Helpers
{
    public class Util
    {
        public static string Diretorio(string appKey)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["" + appKey + ""];
            return path;
        }

        public static string RetornaEncode()
        {
            string encode = ConfigurationManager.AppSettings["EncodeISO"];
            return encode;
        }

        public static decimal FormatarValorMonetario(string valor)
        {
            var cultura = System.Threading.Thread.CurrentThread.CurrentCulture;
            var separador = cultura.NumberFormat.CurrencyDecimalSeparator;

            valor = valor.Replace(",", separador);
            valor = valor.Replace(".", separador);
            return Convert.ToDecimal(valor); 
        }
    }
}
