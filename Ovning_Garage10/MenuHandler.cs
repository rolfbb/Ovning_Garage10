using Ovning_Garage10.Utilities;
using System;
using System.Collections.Generic;

namespace Ovning_Garage10
{
    internal class MenuHandler
    {
        private static Dictionary<string, MenuCommand> menuCommands;

        internal static void PrintMainMenu()
        {
            InitCommands();

            Console.WriteLine("=============================================================================");
            Console.WriteLine("*         Garage - Huvudmeny                                              ");
            Console.WriteLine("=============================================================================");
            Console.WriteLine(menuCommands.Count);
            foreach (var item in menuCommands)
            {
                Console.WriteLine(item.Key + ": " + menuCommands[item.Key].Description);
            }
            Console.WriteLine("=============================================================================");
        }

        internal static Dictionary<string, MenuCommand> InitCommands()
        {
            if (menuCommands == null)
                menuCommands = new Dictionary<string, MenuCommand>();
            return menuCommands;
        }
    }
}

