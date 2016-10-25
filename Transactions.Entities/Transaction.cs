using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Transactions.Entities
{
    public class Transaction
    {
        public virtual string TransactionId { get; set; }
        public virtual Account Account { get; set; }
        public virtual decimal Valor { get; set; }
        public virtual string Memo { get; set; }
        public virtual DateTime DataPost { get; set; }
    }
}
