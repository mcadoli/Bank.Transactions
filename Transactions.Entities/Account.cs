using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transactions.Entities
{
    public class Account
    {
        [Key]
        public virtual string AccountId { get; set; }
        public virtual string BankId { get; set; }
        public virtual string AccountType { get; set; }
    }
}
