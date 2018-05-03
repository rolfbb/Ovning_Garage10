using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning_Garage10
{
    internal struct MenuCommand
    {
        private string description;
        public string Description
        {
            get { return Description; }
            set
            {
                Console.WriteLine("value är: "  + value);
                if (value.Equals("F"))
                    description = Msg.message(value);
                else
                    description = value;
                Console.WriteLine("description är: "  + description);
            }
        }
        //public string Description { get; set; }
        public Action Method { get; set; }
    }
}
