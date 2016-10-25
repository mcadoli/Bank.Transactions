using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transactions.Entities.OFX
{
    public class STMTTRNRS
    {
        public string TRNUID { get; set; }
        public STATUS STATUS { get; set; }
        public STMTRS STMTRS { get; set; }
    }
}
