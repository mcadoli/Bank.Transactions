using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Transactions.Entities;


namespace Transactions.Persistence.EF.DALC
{
    public class TransactionDalc
    {
        BaseDalc baseDalc = new BaseDalc();
        public List<Transaction> ListarTransacoes()
        {
            using (var ctx = new TransactionsContext())
            {
                return baseDalc.Find<Transaction>().OrderBy(x => x.DataPost).ToList<Transaction>();
            }

        }

        public List<Account> ListarAccounts()
        {
            using (var ctx = new TransactionsContext())
            {
                return baseDalc.Find<Account>().OrderBy(x => x.AccountId).ToList<Account>();
            }
        }
        public void SalvarTransacoes(List<Transaction> trs)
        {
            
            foreach (var item in trs)
            {
                using (var ctx = new TransactionsContext())
                {
                    using (var ctxTransaction = ctx.Database.BeginTransaction())
                    {
                        try
                        {
                            ctx.Entry(item.Account).State = EntityState.Modified;
                            ctx.Transactions.Add(item);
                            ctx.SaveChanges();
                            ctxTransaction.Commit();
                        }
                        catch (Exception)
                        {
                            ctxTransaction.Rollback();
                        }
                    }
                }
            }
        }

        public Transaction BuscarTransacaoPorId(string id)
        {
            using (var ctx = new TransactionsContext())
            {
                return baseDalc.Find<Transaction>().FirstOrDefault(x => x.TransactionId == id);
            }
        }

        public void ExcluirTransacao(string id)
        {
            var tr = BuscarTransacaoPorId(id);
            this.baseDalc.Delete(tr);
        }
    }
}
