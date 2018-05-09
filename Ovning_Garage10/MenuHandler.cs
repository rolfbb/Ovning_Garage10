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
            Console.Clear();
            PrintMenu("langMenuHeader", langMenuCommands);
        }

        internal static void PrintMainMenu()
        {
            Console.Clear();
            PrintMenu("mainMenuHeader", mainMenuCommands);
        }

        internal static void PrintMenu(string menu, Dictionary<string, MenuCommand> menuCommands)
        {
            UI.WriteLine(MessageHandler.message("menuSeparator"));
            UI.WriteLine(MessageHandler.message(menu));
            UI.WriteLine(MessageHandler.message("menuSeparator"));

            foreach (var item in menuCommands)
            {
                Console.WriteLine(item.Key + ": " + menuCommands[item.Key].Description);
            }
            UI.WriteLine(MessageHandler.message("menuSeparator"));
        }

        internal static Dictionary<string, MenuCommand> InitLangMenuCommands()
        {
            langMenuCommands = new Dictionary<string, MenuCommand>();
            return langMenuCommands;
        }

        internal static Dictionary<string, MenuCommand> InitMainMenuCommands()
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
                UI.ErrorLine("Error when adding command: {0} {1} {2}", key, command.Description, e.Message);
            }
        }

        internal static bool ReadAndExecuteCommand(Dictionary<string, MenuCommand> menuCommands)
        {
            return ReadAndExecuteCommand(menuCommands, initLang: false);
        }

        internal static bool ReadAndExecuteCommand(Dictionary<string, MenuCommand> menuCommands, bool initLang)
        {
            bool success;

            var key = Console.ReadKey(intercept: true).Key;
            string keyString = key.ToString();
            //UI.WriteLine("Key: " + key + ", " + keyString);

            try
            {
                if (menuCommands.ContainsKey(keyString))
                {
                    menuCommands[key.ToString()].Method();
                    success = true;
                }
                else
                {
                    UI.ErrorLine(MessageHandler.message("nonExistingCommand"), key);
                    success = false;

                    //OS X check...
                    if (initLang && keyString == "0")
                        UI.ErrorLine("Running on Mac? Set 'Run on external console' in Project options");
                }
            }
            catch (Exception e)
            {
                success = false;
                UI.ErrorLine(MessageHandler.message("readAndExecuteCommandFailure"), key, e.Message);
            }

            return success;
        }

    }
}

