using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Transactions.Entities.OFX
{
    public class STATUS
    {
        public string CODE { get; set; }
       
        public string SEVERITY { get; set; }
    }
}
