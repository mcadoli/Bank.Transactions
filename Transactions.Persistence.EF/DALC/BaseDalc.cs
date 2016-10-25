using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transactions.Persistence.EF.DALC
{
    public class BaseDalc
    {
        TransactionsContext ctx = new TransactionsContext();

        public IQueryable<TEntity> Find<TEntity>() where TEntity : class
        {
            return this.ctx.Set<TEntity>();
        }
        public IQueryable<TEntity> Find<TEntity>(string nameClass) where TEntity : class
        {
            return this.ctx.Set<TEntity>().Include(nameClass);
        }
       
    }
}
