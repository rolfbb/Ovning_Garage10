using Ovning_Garage10.Utilities;
using System;
using System.Collections.Generic;

namespace Ovning_Garage10
{
    internal class MenuHandler
    {
		private static Dictionary<string, MenuCommand> langMenuCommands;
        private static Dictionary<string, MenuCommand> mainMenuCommands;
        private static Dictionary<string, MenuCommand> addVehicleMenuCommands;
        private static Dictionary<string, MenuCommand> searchVehicleMenuCommands;
        private static Dictionary<string, MenuCommand> removeVehicleMenuCommands;

        internal static void PrintMainMenu()
        {
            //InitCommands();

            UI.WriteLine("=============================================================================");
            UI.WriteLine(Msg.message("mainMenuHeader"));
            UI.WriteLine("=============================================================================");
            UI.WriteLine(mainMenuCommands.Count.ToString());
            foreach (var item in mainMenuCommands)
            {
                Console.WriteLine(item.Key + ": " + mainMenuCommands[item.Key].Description);
            }
            UI.WriteLine("=============================================================================");
        }

        internal static void PrintLangMenu()
        {
            //InitCommands();

            UI.WriteLine("=============================================================================");
            UI.WriteLine(Msg.message("langMenuHeader"));
            UI.WriteLine("=============================================================================");
            foreach (var item in mainMenuCommands)
            {
                Console.WriteLine(item.Key + ": " + mainMenuCommands[item.Key].Description);
            }
            UI.WriteLine("=============================================================================");
        }

        internal static Dictionary<string, MenuCommand> InitCommands()
        {
            //if (menuCommands == null)
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

