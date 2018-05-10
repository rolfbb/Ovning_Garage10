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
			MenuHandler.Add(cmdDict, "S", new MenuCommand { Description = "S", Method = () => SearchVehicleByRegNbr() });
            MenuHandler.Add(cmdDict, "C", new MenuCommand { Description = "C", Method = () => CreateNewGarage() });
			MenuHandler.Add(cmdDict, "F", new MenuCommand { Description = "F", Method = () => PrintNbrOfFreeSpaces() });
            MenuHandler.Add(cmdDict, "M", new MenuCommand { Description = "M", Method = () => MenuHandler.PrintMainMenu() });
            MenuHandler.Add(cmdDict, "Q", new MenuCommand { Description = "Q", Method = () => run = false });
        }

        private int GetNbrOfFreeSpaces()
        {
            return garage.GetNbrOfFreeSpaces();
        }

        private void PrintNbrOfFreeSpaces()
        {
			UI.WriteLine("nbrFreeSpaces: " + GetNbrOfFreeSpaces());
        }

        private void CreateNewGarage()
        {
			int nbrOfSpaces = UI.AskForInt(MessageHandler.message("nbrSpaces"));
            garage = new Garage<Vehicle>(nbrOfSpaces);
            UI.WriteLine(MessageHandler.message("newGarageCreated"), nbrOfSpaces);
        }

        private void SearchVehicleByRegNbr()
        {
            Console.WriteLine("TODO: SearchVehicleByRegNo");
        }

        private void RemoveVehicle()
        {
            Vehicle vehicle = new Car();

            garage.RemoveVehile(vehicle);
        }

        private bool AddVehicle()
        {
			VehicleFactory vehicleFactory = new VehicleFactory();
			Vehicle vehicle = vehicleFactory.CreateVehicle();

            bool retval = garage.ParkVehicle(vehicle);
            if (retval)
                Console.WriteLine(MessageHandler.message("vehicleIsParked"), GetNbrOfFreeSpaces());
            else
                Console.WriteLine(MessageHandler.message("noFreeSpaces"), GetNbrOfFreeSpaces());
            return retval;
        }

        private void ListVehicleTypes()
        {
            Console.WriteLine("TODO: ListVehicleTypes");
        }

        private void ListAllVehicles()
        {
			foreach (var item in garage)
            {
                if (item != null)
                    Console.WriteLine(MessageHandler.message("vehicleColonLabel") + item.ToString());
            }

        }
    }
}

