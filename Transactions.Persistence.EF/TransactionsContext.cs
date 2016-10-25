using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transactions.Entities;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Design;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Transactions.Persistence.EF
{
    public class TransactionsContext : DbContext
    {
        public TransactionsContext()
            : base()
        {
            
        }
        public DbSet<Transaction> Transactions { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();  
        }
    }
}
