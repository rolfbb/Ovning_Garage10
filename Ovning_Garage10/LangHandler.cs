using Ovning_Garage10.Utilities;
using System;
using System.Collections.Generic;

namespace Ovning_Garage10
{
    internal class LangHandler
    {
        private static Dictionary<string, MenuCommand> langMenuCommands;

        internal static bool AskAndSetLanguage()
        {
            bool retval;
            InitLangCommands();
            MenuHandler.PrintLangMenu();

            do
            {
                retval = MenuHandler.ReadAndExecuteCommand(langMenuCommands, initLang: true);
            } while (!retval);

            return retval;
        }


        private static void InitLangCommands()
        {
            SetLangLANG();
            InitMessages();
            langMenuCommands = MenuHandler.InitLangMenuCommands();
            MenuHandler.Add(langMenuCommands, "S", new MenuCommand { Description = "S", Method = () => SetLangSE() });
            MenuHandler.Add(langMenuCommands, "E", new MenuCommand { Description = "E", Method = () => SetLangEN() });

            PrintMenuCommands();
        }

        private static void PrintMenuCommands()
        {
            foreach (var item in langMenuCommands)
            {
                Console.WriteLine("LANG commands: " + item.Key + ": " + langMenuCommands[item.Key].Description);
            }
        }

        private static void InitMessages()
        {
            MessageHandler.InitMessages();
        }

        private static void SetLangLANG()
        {
            MessageHandler.SetLang("LANG");
        }

        internal static void SetLangEN()
        {
            MessageHandler.SetLang("EN");
        }

        private static void SetLangSE()
        {
            MessageHandler.SetLang("SE");
        }

    }
}