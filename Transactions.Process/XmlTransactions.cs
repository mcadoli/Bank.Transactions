using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Transactions.Entities;
using Transactions.Entities.OFX;
using Transactions.Helpers;
using Transactions.Helpers.XML;
using System.IO;
using System.Configuration;

namespace Transactions.Process
{
    public class XmlTransactions
    {
        /// <summary>
        /// Método responsável por tratar o xml antes dserializá-lo. Este método 
        /// </summary>
        private List<string> TreatOfx(string encode, string file)
        {
            var txt = new List<string>(File.ReadAllLines(file));
                
            for (int c = 0; c <= 9; c++)
            {
                txt.RemoveAt(0);
            }
            txt.Insert(0, "<?xml version=\"1.0\" encoding=\"" + encode + "\"?>");
            txt.Insert(1, "<OFX xmlns=\"http://www.w3.org/2001/XMLSchema\">");
            
            return txt; 
        }
        /// <summary>
        /// Cria um novo xml adequado para ser desserializado
        /// </summary>
        private void CreateNewXml()
        {
            string[] files = Directory.GetFiles(Util.Diretorio("DiretorioOfx"));
            string encode = Util.RetornaEncode();
            string liAlterada = String.Empty;
            foreach (string file in files)
            {
                List<string> txt = TreatOfx(encode, file);
                string nomeArquivo = DateTime.Now.ToString("yyyyMMdd") + DateTime.Now.ToString("HHmmss");
                string[] nosErrados = new string[] { "CODE", "SEVERITY", "DTSERVER", "LANGUAGE", "TRNUID", "CURDEF", "BANKID", "ACCTID", "ACCTTYPE", "DTSTART", "DTEND", "TRNTYPE", "DTPOSTED", "TRNAMT", "FITID", "CHECKNUM", "MEMO", "BALAMT", "DTASOF", "PAYEEID" };

                using (XmlWriter newFile = new XmlTextWriter(Util.Diretorio("DiretorioXml") + "\\" + nomeArquivo + ".xml", null))
                {
                    foreach (string line in txt)
                    {
                        for (int i = 0; i < nosErrados.Length; i++)
                        {
                            if (line.Contains(nosErrados[i]))
                                liAlterada = line + "</" + nosErrados[i] + ">";
                        }
                        if (!String.IsNullOrWhiteSpace(liAlterada))
                            newFile.WriteRaw(liAlterada);
                        else
                            newFile.WriteRaw(line);

                        liAlterada = String.Empty;
                    }
                }
                File.Copy(file, Util.Diretorio("DiretorioOfxLog") + "\\" + Path.GetFileName(file), true);
                File.Delete(file);
            }
        }
        /// <summary>
        /// Desserializa o XML Salvo
        /// </summary>
        /// <returns></returns>
        public OFX DesserializeXml()
        {
            CreateNewXml();
            string[] files = Directory.GetFiles(Util.Diretorio("DiretorioXml"));
            OFX ofx = new OFX();
            FinanceTransaction tran = new FinanceTransaction();
            foreach (string file in files)
            {
                ofx = Serialize.Deserialize(ofx, file);
                File.Copy(file, Util.Diretorio("DiretorioXmlLog") + "\\" + Path.GetFileName(file), true);
                File.Delete(file);
                return ofx;
            }
            return null;
        }
    }
}
