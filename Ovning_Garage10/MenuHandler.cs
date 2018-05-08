using Ovning_Garage10.Utilities;
using System;
using System.Collections.Generic;

namespace Ovning_Garage10
{
    internal class MenuHandler
    {
		private static Dictionary<string, MenuCommand> langMenuCommands;
        private static Dictionary<string, MenuCommand> mainMenuCommands;
        //private static Dictionary<string, MenuCommand> addVehicleMenuCommands;
        //private static Dictionary<string, MenuCommand> searchVehicleMenuCommands;
        //private static Dictionary<string, MenuCommand> removeVehicleMenuCommands;

		internal static void PrintLangMenu()
		{
			PrintMenu("langMenuHeader", langMenuCommands);
		}
		
        internal static void PrintMainMenu()
        {
            PrintMenu("mainMenuHeader", mainMenuCommands);
        }

        internal static void PrintMenu(string menu, Dictionary<string, MenuCommand> menuCommands)
        {
            UI.WriteLine(Msg.message("menuSeparator"));
            UI.WriteLine(Msg.message(menu + "Header"));
            UI.WriteLine(Msg.message("menuSeparator"));

            foreach (var item in menuCommands)
            {
                Console.WriteLine(item.Key + ": " + menuCommands[item.Key].Description);
            }
            UI.WriteLine(Msg.message("menuSeparator"));
        }

        internal static Dictionary<string, MenuCommand> InitCommands()
        {
            mainMenuCommands = new Dictionary<string, MenuCommand>();
            return mainMenuCommands;
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

        internal static bool ReadAndExecuteCommand()
        {
            return ReadAndExecuteCommand(false);
        }

        internal static bool ReadAndExecuteCommand(bool init)
        {
            bool retval; // Kludge alert!
            var key = Console.ReadKey(intercept: true).Key;
            string answerValue = key.ToString();
            try
            {
                Console.WriteLine("Key: " + key + ", " + answerValue);
                if (mainMenuCommands.ContainsKey(answerValue))
                    mainMenuCommands[key.ToString()].Method();
                else
                    UI.WriteLine(Msg.message("nonExistingCommand"), answerValue);

                retval = true;
            }
            catch (KeyNotFoundException)
            {
                retval = false;
                UI.WriteLine(Msg.message("nonExistingCommand"), answerValue);

                //OS X check...
                if (init && answerValue == "0")
                    UI.WriteLine("Running on Mac? Set 'Run on external console' in Project options");
            }

            return retval;
        }

    }
}

