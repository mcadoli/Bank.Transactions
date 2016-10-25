using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Transactions.Entities.OFX
{
    
    public class BANKTRANLIST
    {
        public BANKTRANLIST() { Items = new List<STMTTRN>(); }
        [XmlElement("STMTTRN")]
        public List<STMTTRN> Items { get; set; }
    }
}
