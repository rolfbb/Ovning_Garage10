using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning_Garage10
{
    internal struct MenyCommand
    {
        public string Description { get; set; }
        public Action Method { get; set; }
    }
}
