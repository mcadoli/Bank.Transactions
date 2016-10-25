using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Transactions.Entities.OFX
{
    [XmlRoot("OFX", Namespace = "http://www.w3.org/2001/XMLSchema")]
    public class OFX
    {
        public SIGNONMSGSRSV1 SIGNONMSGSRSV1 {get; set;}
        public BANKMSGSRSV1 BANKMSGSRSV1 { get; set; }
    }
}
