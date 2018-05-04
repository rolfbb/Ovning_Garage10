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
            //InitCommands();

            UI.WriteLine("=============================================================================");
            UI.WriteLine(Msg.message("mainMenuHeader"));
            UI.WriteLine("=============================================================================");
            UI.WriteLine(menuCommands.Count.ToString());
            foreach (var item in menuCommands)
            {
                Console.WriteLine(item.Key + ": " + menuCommands[item.Key].Description);
            }
            UI.WriteLine("=============================================================================");
        }

        internal static void PrintLangMenu()
        {
            //InitCommands();

            UI.WriteLine("=============================================================================");
            UI.WriteLine(Msg.message("langMenuHeader"));
            UI.WriteLine("=============================================================================");
            foreach (var item in menuCommands)
            {
                Console.WriteLine(item.Key + ": " + menuCommands[item.Key].Description);
            }
            UI.WriteLine("=============================================================================");
        }

        internal static Dictionary<string, MenuCommand> InitCommands()
        {
            //if (menuCommands == null)
                menuCommands = new Dictionary<string, MenuCommand>();
            return menuCommands;
        }

        internal static void Add(Dictionary<string, MenuCommand> menuCommands, string key, MenuCommand command)
        {
            try
            {
                menuCommands.Add(key, command);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Error when adding command: {key} {command.Description} {e.Message}");
            }
        }


    }
}

