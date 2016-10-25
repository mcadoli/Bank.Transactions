using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transactions.Entities;
using Transactions.Entities.OFX;
using Transactions.Persistence.EF.DALC;

namespace Transactions.Process
{
    public class FinanceTransaction
    {
        public List<Transaction> ListarDadosTransaction()
        {
            TransactionDalc trsDalc = new TransactionDalc();
            return trsDalc.ListarTransacoes().ToList<Transaction>();
        }

        public void DeleteAllTransaction()
        {
            TransactionDalc trsDalc = new TransactionDalc();
            List<Transaction> trs = new List<Transaction>();
            trs = trsDalc.ListarTransacoes().ToList<Transaction>();
            foreach (var item in trs)
            {
                trsDalc.ExcluirTransacao(item.TransactionId);
            }
        }

        public List<Account> ListarAccount()
        {
            TransactionDalc trsDalc = new TransactionDalc();
            return trsDalc.ListarAccounts().ToList<Account>();
        }
        public void SalvarDadosTransaction()
        {
            TransactionDalc trsDalc = new TransactionDalc();
            Maps map = new Maps();
            XmlTransactions xmlTran = new XmlTransactions();
            OFX ofx = xmlTran.DesserializeXml();
            List<Transaction> trs = new List<Transaction>();
            trs = map.MapOfxToTransaction(ofx);
            trsDalc.SalvarTransacoes(trs);
        }  
    }
}
