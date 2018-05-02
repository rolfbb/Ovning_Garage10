using System;
using System.Collections.Generic;

namespace Ovning_Garage10
{
    internal class MenuHandler
    {
        private static Dictionary<string, string> mainMenuCommands;

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

        internal static Dictionary<string, MenyCommand> InitCommands()
        {
            //if (mainMenuCommands == null)
            //{
            //    //mainMenuCommands = new Dictionary<string, string>();
            //    //mainMenuCommands.Add("F", "Listar samtliga parkerade fordon");
            //    //mainMenuCommands.Add("T", "Listar fordonstyper och hur många av varje som står i garaget");
            //    //mainMenuCommands.Add("L", "Lägg till fordon");
            //    //mainMenuCommands.Add("R", "Ta bort fordon");
            //    //mainMenuCommands.Add("S", "Sök fordon via registreringsnumret");
            //    //mainMenuCommands.Add("C", "Skapa nytt garage");
            //    //mainMenuCommands.Add("G", "Antal lediga parkeringsplatser");
            //    //mainMenuCommands.Add("M", "Huvudmeny");
            //    //mainMenuCommands.Add("Q", "Du har valt att avsluta programmet");

            //    //Dictionary<string, MenyCommand> mainMenuCommands = new Dictionary<string, MenyCommand>();
            //    //mainMenuCommands.Add("F", new MenyCommand { Description = "Listar samtliga parkerade fordon", Method = () => ListAllVehicles() });
            //    //mainMenuCommands.Add("T", new MenyCommand { Description = "Listar fordonstyper och hur många av varje som står i garaget", Method = () => ListVehicleTypes() });
            //    //mainMenuCommands.Add("L", new MenyCommand { Description = "Lägg till fordon", Method = () => AddVehicle() });
            //    //mainMenuCommands.Add("R", new MenyCommand { Description = "Ta bort fordon", Method = () => RemoveVehicle() });
            //    //mainMenuCommands.Add("S", new MenyCommand { Description = "Sök fordon via registreringsnumret", Method = () => SearchVehicleByRegNo() });
            //    //mainMenuCommands.Add("C", new MenyCommand { Description = "Skapa nytt garage", Method = () => CreateNewGarage() });
            //    //mainMenuCommands.Add("G", new MenyCommand { Description = "Antal lediga parkeringsplatser", Method = () => GetNbrOfFreeSpots() });
            //    //mainMenuCommands.Add("M", new MenyCommand { Description = "Huvudmeny", Method = () => MenuHandler.PrintMainMenu() });
            //    //mainMenuCommands.Add("Q", new MenyCommand { Description = "Du har valt att avsluta programmet", Method = () => run = false;
            //}
            Dictionary<string, MenyCommand> mainMenuCommands = new Dictionary<string, MenyCommand>();

            return mainMenuCommands;

            //Console.WriteLine(mainMenuCommands["F"].Description);
            //mainMenuCommands["F"].Method();
        }

        public static void Print()
        {
            Console.WriteLine("Hej, hej!");
        }

        internal static void PrintMainMenuCommandForKey(ConsoleKey key, bool print)
        {
            if (print)
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
