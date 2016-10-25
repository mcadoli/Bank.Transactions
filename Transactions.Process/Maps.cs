using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transactions.Entities;
using Transactions.Entities.OFX;
using Transactions.Helpers;

namespace Transactions.Process
{
    public class Maps
    {
        public List<Transaction> MapOfxToTransaction(OFX ofx)
        {
            int c = 0;
            List<Transaction> lstTransaction = new List<Transaction>();
            //Cada item é uma transação
            foreach (var item in ofx.BANKMSGSRSV1.STMTTRNRS.STMTRS.BANKTRANLIST.Items)
            {
                Transaction transaction = new Transaction();
                transaction.Account = new Account();
                transaction.Account.AccountId = ofx.BANKMSGSRSV1.STMTTRNRS.STMTRS.BANKACCTFROM.ACCTID;
                transaction.Account.AccountType = ofx.BANKMSGSRSV1.STMTTRNRS.STMTRS.BANKACCTFROM.ACCTTYPE;
                transaction.Account.BankId = ofx.BANKMSGSRSV1.STMTTRNRS.STMTRS.BANKACCTFROM.BANKID;
                if (!String.IsNullOrWhiteSpace(item.DTPOSTED))
                {
                    string data = item.DTPOSTED.Remove(12);
                    string dataFormatada = data.Substring(0, 4) + "-" + data.Substring(4, 2) + "-" + data.Substring(6, 2) + " " + data.Substring(8, 2) + ":" + data.Substring(10, 2);
                    transaction.DataPost = Convert.ToDateTime(dataFormatada);
                }
                transaction.TransactionId = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + c.ToString();
                transaction.Memo = item.MEMO;
                if (!String.IsNullOrWhiteSpace(item.TRNAMT))
                    transaction.Valor = Util.FormatarValorMonetario(item.TRNAMT);

                lstTransaction.Add(transaction);
                c++;
            }
            return lstTransaction;
        }
    }
}
