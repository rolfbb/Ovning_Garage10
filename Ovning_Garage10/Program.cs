using Ovning_Garage10.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning_Garage10
{
    class Program
    {
        private static GarageHandler garage = new GarageHandler();

        static void Main(string[] args)
        {
            LangHandler.AskAndSetLanguage();
            garage.Run();
        }

    }
}
