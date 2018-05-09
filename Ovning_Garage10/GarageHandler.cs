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
        private Dictionary<string, MenuCommand> cmdDict;

        internal void Run()
        {
            Init();

            MenuHandler.PrintMainMenu();
            do
            {
                MenuHandler.ReadAndExecuteCommand(cmdDict);
            } while (run);

        }

        private void Init()
        {
            InitMessages();
            InitCommands();
            UI.WriteLine(MessageHandler.message("noGarageAddNew"));
            CreateNewGarage();
        }

        private void InitMessages()
        {
            MessageHandler.InitMessages();
        }

        private void InitCommands()
        {
            cmdDict = MenuHandler.InitMainMenuCommands();

            MenuHandler.Add(cmdDict, "L", new MenuCommand { Description = "L", Method = () => ListAllVehicles() });
            MenuHandler.Add(cmdDict, "T", new MenuCommand { Description = "T", Method = () => ListVehicleTypes() });
            MenuHandler.Add(cmdDict, "A", new MenuCommand { Description = "A", Method = () => AddVehicle() });
            MenuHandler.Add(cmdDict, "R", new MenuCommand { Description = "R", Method = () => RemoveVehicle() });
            MenuHandler.Add(cmdDict, "S", new MenuCommand { Description = "S", Method = () => SearchVehicleByRegNo() });
            MenuHandler.Add(cmdDict, "C", new MenuCommand { Description = "C", Method = () => CreateNewGarage() });
            MenuHandler.Add(cmdDict, "F", new MenuCommand { Description = "F", Method = () => PrintNbrOfFreeSpots() });
            MenuHandler.Add(cmdDict, "M", new MenuCommand { Description = "M", Method = () => MenuHandler.PrintMainMenu() });
            MenuHandler.Add(cmdDict, "Q", new MenuCommand { Description = "Q", Method = () => run = false });
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
            int nbrOfParkingLots = UI.AskForInt(MessageHandler.message("nbrParkingSpots"));
            garage = new Garage<Vehicle>(nbrOfParkingLots);
            UI.WriteLine(MessageHandler.message("newGarageCreated"), nbrOfParkingLots);
        }

        private void SearchVehicleByRegNo()
        {
            throw new NotImplementedException();
        }

        private void RemoveVehicle()
        {
            Vehicle vehicle = new Car();

            garage.RemoveVehile(vehicle);
        }

        private bool AddVehicle()
        {

            Vehicle vehicle = new Car();
            Console.WriteLine("Nytt fordon: " + vehicle.GetType().Name + " " + MessageHandler.message(vehicle.GetType().Name));
            bool retval = garage.AddVehicle(vehicle);
            if (retval)
                Console.WriteLine(MessageHandler.message("vehicleIsParked"), GetNbrOfFreeSpots());
            else
                Console.WriteLine(MessageHandler.message("noFreeSpots"), GetNbrOfFreeSpots());
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

