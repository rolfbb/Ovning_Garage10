using Ovning_Garage10.Entities;
using Ovning_Garage10.Utilities;
using System;
using System.Collections.Generic;

namespace Ovning_Garage10
{
    internal class GarageHandler
    {
        private bool run = true;
        private Garage<Vehicle> garage;
        private Dictionary<string, MenyCommand> mainMenuCommands;

        internal void Run()
        {
            if (garage == null)
            {
                Init();
            }

            MenuHandler.PrintMainMenu();
            do
            {
                //TODO: Göra om till Dictionary, key/method?
                var key = Console.ReadKey(intercept: true).Key;
                Console.WriteLine(mainMenuCommands[key.ToString()].Description);
                mainMenuCommands[key.ToString()].Method();
                //switch (key)
                //{
                //case ConsoleKey.F: MenuHandler.PrintMainMenuCommandForKey(key, false); ListAllVehicles(); break;
                //case ConsoleKey.T: MenuHandler.PrintMainMenuCommandForKey(key, false); ListVehicleTypes(); break;
                //case ConsoleKey.L: MenuHandler.PrintMainMenuCommandForKey(key, false); AddVehicle(); break;
                //case ConsoleKey.R: MenuHandler.PrintMainMenuCommandForKey(key, false); RemoveVehicle(); break;
                //case ConsoleKey.S: MenuHandler.PrintMainMenuCommandForKey(key, false); SearchVehicleByRegNo(); break;
                //case ConsoleKey.C: MenuHandler.PrintMainMenuCommandForKey(key, false); CreateNewGarage(); break;
                //case ConsoleKey.G: MenuHandler.PrintMainMenuCommandForKey(key, false); GetNbrOfFreeSpots(); break;
                //case ConsoleKey.M: MenuHandler.PrintMainMenuCommandForKey(key, false); MenuHandler.PrintMainMenu(); break;
                //case ConsoleKey.Q: MenuHandler.PrintMainMenuCommandForKey(key, false); run = false; break;
                //Console.WriteLine(mainMenuCommands[key.ToString()].Description);
                //mainMenuCommands[key.ToString()].Method();
                //}
            } while (run);

        }

        private void Init()
        {
            if (garage == null)
            {
                Console.WriteLine("Det finns inget garage - ett nytt garage behöver skapas.");
                CreateNewGarage();

                mainMenuCommands = MenuHandler.InitCommands();
                mainMenuCommands.Add("F", new MenyCommand { Description = "Listar samtliga parkerade fordon", Method = () => ListAllVehicles() });
                mainMenuCommands.Add("T", new MenyCommand { Description = "Listar fordonstyper och hur många av varje som står i garaget", Method = () => ListVehicleTypes() });
                mainMenuCommands.Add("L", new MenyCommand { Description = "Lägg till fordon", Method = () => AddVehicle() });
                mainMenuCommands.Add("R", new MenyCommand { Description = "Ta bort fordon", Method = () => RemoveVehicle() });
                mainMenuCommands.Add("S", new MenyCommand { Description = "Sök fordon via registreringsnumret", Method = () => SearchVehicleByRegNo() });
                mainMenuCommands.Add("C", new MenyCommand { Description = "Skapa nytt garage", Method = () => CreateNewGarage() });
                mainMenuCommands.Add("G", new MenyCommand { Description = "Antal lediga parkeringsplatser", Method = () => GetNbrOfFreeSpots() });
                mainMenuCommands.Add("M", new MenyCommand { Description = "Huvudmeny", Method = () => MenuHandler.PrintMainMenu() });
                mainMenuCommands.Add("Q", new MenyCommand { Description = "Du har valt att avsluta programmet", Method = () => run = false;
            }
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
            Vehicle vehicle = new Vehicle("Car");
            bool retval = garage.AddVehicle(vehicle);
            Console.WriteLine("Adding new vehicle done!");
            return retval;
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

