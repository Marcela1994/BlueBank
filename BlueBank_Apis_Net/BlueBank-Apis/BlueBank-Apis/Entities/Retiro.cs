using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueBank_Apis.Entities
{
    public class Retiro
    {
        public string cuenta { get; set; }
        public decimal valor { get; set; }
        public string pin { get; set; }
    }
}
