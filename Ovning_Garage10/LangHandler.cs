using Ovning_Garage10.Utilities;
using System;
using System.Collections.Generic;

namespace Ovning_Garage10
{
    internal class LangUtil
    {
        private static Dictionary<string, MenuCommand> menuCommands;

        internal static bool AskAndSetLanguage()
        {
            bool retval;
            InitLangCommands();

            MenuHandler.PrintLangMenu();
            retval = MenuHandler.ReadAndExecuteCommand(init: true);

            return retval;
        }


        private static void InitLangCommands()
        {
            SetLangLANG();
            InitMessages();
            menuCommands = MenuHandler.InitCommands();
            menuCommands.Add("S", new MenuCommand { Description = "S", Method = () => SetLangSE() });
            menuCommands.Add("E", new MenuCommand { Description = "E", Method = () => SetLangEN() });

            PrintMenuCommands();
        }

        private static void PrintMenuCommands()
        {
            foreach (var item in menuCommands)
            {
                Console.WriteLine("LANG commands: " + item.Key + ": " + menuCommands[item.Key].Description);
            }
        }

        private static void InitMessages()
        {
            Msg.InitMessages();
        }

        private static void SetLangLANG()
        {
            Msg.SetLang("LANG");
        }

        private static void SetLangEN()
        {
            Msg.SetLang("EN");
        }

        private static void SetLangSE()
        {
            Msg.SetLang("SE");
        }

    }
}