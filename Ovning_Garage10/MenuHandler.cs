using System;
using System.Collections.Generic;

namespace Ovning_Garage10
{
    internal class MenuHandler
    {
        private static Dictionary<string, string> mainMenuCommands = new Dictionary<string, string>();

        internal static void PrintMainMenu()
        {
            InitCommands();

            Console.WriteLine("=============================================================================");
            Console.WriteLine("*         Garage - Huvudmeny                                              ");
            Console.WriteLine("=============================================================================");
            foreach (KeyValuePair<string, string> command in mainMenuCommands)
            {
                Console.WriteLine($"*      {command.Key}: {command.Value}");
            }
            Console.WriteLine("=============================================================================");

        }

        private static void InitCommands()
        {
            mainMenuCommands.Add("F", "Listar samtliga parkerade fordon");
            mainMenuCommands.Add("T", "Listar fordonstyper och hur många av varje som står i garaget");
            mainMenuCommands.Add("L", "Lägg till fordon");
            mainMenuCommands.Add("R", "Ta bort fordon");
            mainMenuCommands.Add("S", "Sök fordon via registreringsnumret");
            mainMenuCommands.Add("C", "Skapa nytt garage");
            mainMenuCommands.Add("Q", "Du har valt att avsluta programmet");
        }

        internal static void PrintMainMenuCommandForKey(ConsoleKey key)
        {
            Console.WriteLine(key.ToString() + ": " + GetMainMenuCommandForKey(key));
        }

        internal static string GetMainMenuCommandForKey(ConsoleKey key)
        {
            return mainMenuCommands[key.ToString()];
        }
    }
}

/*
Lista samtliga parkerade fordon
Lista fordonstyper och hur många av varje som står i garaget
Lägg till fordon
Ta bort fordon
Sök fordon via registreringsnumret
Sök fordon utifrån egenskap (undermeny)
        - alla svarta fordon med fyra hjul
Skapa nytt garage (kunna sätta en kapacitet(antal parkeringsplatser) vid instansieringen av ett nytt garage
*/
