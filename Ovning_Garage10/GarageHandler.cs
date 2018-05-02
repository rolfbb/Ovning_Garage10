using Ovning_Garage10.Entities;
using Ovning_Garage10.Utilities;
using System;

namespace Ovning_Garage10
{
    internal class GarageHandler
    {
        private Garage<Vehicle> garage;

        internal void Run()
        {
            if (garage == null)
            {
                Console.WriteLine("Det finns inget garage - ett nytt garage behöver skapas.");
                CreateNewGarage();
            }

            bool run = true;
            MenuHandler.PrintMainMenu();
            do
            {
                //TODO: Göra om till Dictionary, key/method?
                var key = Console.ReadKey(intercept: true).Key;
                switch (key)
                {
                    case ConsoleKey.F: MenuHandler.PrintMainMenuCommandForKey(key, false); ListAllVehicles(); break;
                    case ConsoleKey.T: MenuHandler.PrintMainMenuCommandForKey(key, false); ListVehicleTypes(); break;
                    case ConsoleKey.L: MenuHandler.PrintMainMenuCommandForKey(key, false); AddVehicle(); break;
                    case ConsoleKey.R: MenuHandler.PrintMainMenuCommandForKey(key, false); RemoveVehicle(); break;
                    case ConsoleKey.S: MenuHandler.PrintMainMenuCommandForKey(key, false); SearchVehicleByRegNo(); break;
                    case ConsoleKey.C: MenuHandler.PrintMainMenuCommandForKey(key, false); CreateNewGarage(); break;
                    case ConsoleKey.G: MenuHandler.PrintMainMenuCommandForKey(key, false); GetNbrOfFreeSpots(); break;
                    case ConsoleKey.M: MenuHandler.PrintMainMenuCommandForKey(key, false); MenuHandler.PrintMainMenu(); break;
                    case ConsoleKey.Q: MenuHandler.PrintMainMenuCommandForKey(key, false); run = false; break;
                }
            } while (run);

        }

        private void GetNbrOfFreeSpots()
        {
            Console.WriteLine("Antal lediga parkeringsplatser: " + garage.GetNbrOfFreeSpots());
        }

        private void CreateNewGarage()
        {
            int nbrOfParkingLots = UI.AskForInt("Hur många parkeringslatser ska det vara i det nya garaget?");
            garage = new Garage<Vehicle>(nbrOfParkingLots);
            Console.WriteLine($"Nytt garage med {nbrOfParkingLots} är skapat.");
        }

        private void SearchVehicleByRegNo()
        {
            throw new NotImplementedException();
        }

        private void RemoveVehicle()
        {
            throw new NotImplementedException();
        }

        private bool AddVehicle()
        {
            Console.WriteLine("AddVehicle");
            return garage.AddVehicle();
        }

        private void ListVehicleTypes()
        {
            throw new NotImplementedException();
        }

        private void ListAllVehicles()
        {
            garage.ListAllVehicles();
        }
    }
}

