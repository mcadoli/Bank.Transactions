using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transactions.Entities.OFX
{
    public class STMTTRN
    {
        public string TRNTYPE { get; set; }
        public string DTPOSTED { get; set; }
        public string TRNAMT { get; set; }
        public string MEMO { get; set; }
        public string PAYEEID { get; set; }
    }
}
