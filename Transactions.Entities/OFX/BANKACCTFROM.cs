using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transactions.Entities.OFX
{
    public class BANKACCTFROM
    {
        public string BANKID { get; set; }
        public string ACCTID { get; set; }
        public string ACCTTYPE { get; set; }
    }
}
