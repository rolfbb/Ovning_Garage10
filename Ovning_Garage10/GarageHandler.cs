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
        private Dictionary<string, MenuCommand> menuCommands;

        internal void Run()
        {
            Init();

            MenuHandler.PrintMainMenu();
            do
            {
                var key = Console.ReadKey(intercept: true).Key;
                try
                {
                    menuCommands[key.ToString()].Method();
                }
                catch (KeyNotFoundException)
                {
                    UI.WriteLine(Msg.message("nonExistingCommand"), key.ToString());
                }
            } while (run);

        }

        private void Init()
        {
            Console.WriteLine("GH innan InitMessages");
            InitMessages();
            Console.WriteLine("GH innan InitCommands");
            InitCommands();
            UI.WriteLine(Msg.message("noGarage"));
            CreateNewGarage();
        }

        private void InitMessages()
        {
            Msg.InitMessages();
        }

        private void InitCommands()
        {
            menuCommands = MenuHandler.InitCommands();

            MenuHandler.Add(menuCommands, "F", new MenuCommand { Description = "F", Method = () => ListAllVehicles() });
            MenuHandler.Add(menuCommands, "T", new MenuCommand { Description = "T", Method = () => ListVehicleTypes() });
            MenuHandler.Add(menuCommands, "L", new MenuCommand { Description = "L", Method = () => AddVehicle() });
            MenuHandler.Add(menuCommands, "R", new MenuCommand { Description = "R", Method = () => RemoveVehicle() });
            MenuHandler.Add(menuCommands, "S", new MenuCommand { Description = "S", Method = () => SearchVehicleByRegNo() });
            MenuHandler.Add(menuCommands, "C", new MenuCommand { Description = "C", Method = () => CreateNewGarage() });
            MenuHandler.Add(menuCommands, "G", new MenuCommand { Description = "G", Method = () => PrintNbrOfFreeSpots() });
            MenuHandler.Add(menuCommands, "M", new MenuCommand { Description = "M", Method = () => MenuHandler.PrintMainMenu() });
            MenuHandler.Add(menuCommands, "Q", new MenuCommand { Description = "Q", Method = () => run = false });
        }

        private int GetNbrOfFreeSpots()
        {
            return garage.GetNbrOfFreeSpots();
        }

        private void PrintNbrOfFreeSpots()
        {
            UI.WriteLine("nbrFreeSpots: " + GetNbrOfFreeSpots());
        }

        private void CreateNewGarage()
        {
            int nbrOfParkingLots = UI.AskForInt(Msg.message("nbrParkingSpots"));
            garage = new Garage<Vehicle>(nbrOfParkingLots);
            UI.WriteLine(Msg.message("newGarageCreated"), nbrOfParkingLots);
        }

        private void SearchVehicleByRegNo()
        {
            throw new NotImplementedException();
        }

        private void RemoveVehicle()
        {
            Vehicle vehicle = new Vehicle();

            garage.RemoveVehile(vehicle);
        }

        private bool AddVehicle()
        {

            Vehicle vehicle = new Car();
            Console.WriteLine("Nytt fordon: " + vehicle.GetType().Name + " " + Msg.message(vehicle.GetType().Name));
            bool retval = garage.AddVehicle(vehicle);
            if (retval)
                Console.WriteLine(Msg.message("vehicleIsParked"), GetNbrOfFreeSpots());
            else
                Console.WriteLine(Msg.message("noFreeSpots"), GetNbrOfFreeSpots());
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

