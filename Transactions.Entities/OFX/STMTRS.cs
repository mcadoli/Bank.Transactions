using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Transactions.Entities.OFX
{
    public class STMTRS
    {
        public string CURDEF { get; set; }
        public BANKACCTFROM BANKACCTFROM { get; set; } 
        public BANKTRANLIST BANKTRANLIST { get; set; }
        public LEDGERBAL LEDGERBAL { get; set; }
    }
}
