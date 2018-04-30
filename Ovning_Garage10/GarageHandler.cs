using Ovning_Garage10.Entities;
using Ovning_Garage10.Utilities;
using System;

namespace Ovning_Garage10
{
    internal class GarageHandler
    {
        internal void Run()
        {
            bool run = true;
            MenuHandler.PrintMainMenu();
            do
            {
                //TODO: Göra om till Dictionary, key/method?
                var key = Console.ReadKey(intercept: true).Key;
                switch (key)
                {
                    case ConsoleKey.F: MenuHandler.PrintMainMenuCommandForKey(key); ListAllVehicles(); break;
                    case ConsoleKey.T: MenuHandler.PrintMainMenuCommandForKey(key); ListVehicleTypes(); break;
                    case ConsoleKey.L: MenuHandler.PrintMainMenuCommandForKey(key); AddVehicle(); break;
                    case ConsoleKey.R: MenuHandler.PrintMainMenuCommandForKey(key); RemoveVehicle(); break;
                    case ConsoleKey.S: MenuHandler.PrintMainMenuCommandForKey(key); SearchVehicleByRegNo(); break;
                    case ConsoleKey.C: MenuHandler.PrintMainMenuCommandForKey(key); CreateNewGarage(); break;
                    case ConsoleKey.Q: MenuHandler.PrintMainMenuCommandForKey(key); run = false; break;
                }
            } while (run);

        }

        private void CreateNewGarage()
        {
            int nbrOfParkingLots = UI.AskForInt("Hur många parkeringslatser ska det vara i det nya garaget?");
            Garage<Vehicle> garage = new Garage<Vehicle>(nbrOfParkingLots);

        }

        private void SearchVehicleByRegNo()
        {
            throw new NotImplementedException();
        }

        private void RemoveVehicle()
        {
            throw new NotImplementedException();
        }

        private void AddVehicle()
        {
            throw new NotImplementedException();
        }

        private void ListVehicleTypes()
        {
            throw new NotImplementedException();
        }

        private void ListAllVehicles()
        {
            throw new NotImplementedException();
        }
    }
}

//Console.WriteLine("*           1: Lista samtliga parkerade fordon                              *");
//Console.WriteLine("*           2: Lista fordonstyper och hur många av varje som står i garaget *");
//Console.WriteLine("*           3: Lägg till fordon                                             *");
//Console.WriteLine("*           4: Ta bort fordon                                               *");
//Console.WriteLine("*           M: Sök fordon via registreringsnumret                           *");
//Console.WriteLine("*           Q: Avsluta                                                      *");
