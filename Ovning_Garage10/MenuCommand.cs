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
            get => description;
            set
            {
                description = Msg.message(value);
                //Console.WriteLine("value: " + value + " description: " + description);
            }
        }

        public Action Method { get; set; }
    }
}
