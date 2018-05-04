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
            if (menuCommands == null)
            {
                Init();
            }

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
            SetLangSE();
            InitMessages();
            InitCommands();
            UI.WriteLine(Msg.message("noGarage"));
            CreateNewGarage();
        }

        private static void SetLangSE()
        {
            Msg.SetLang("SE");
        }

        private static void SetLangEN()
        {
            Msg.SetLang("EN");
        }

        private void InitMessages()
        {
            Msg.InitMessages();
        }

        private void InitCommands()
        {
            menuCommands = MenuHandler.InitCommands();
            menuCommands.Add("F", new MenuCommand { Description = "F", Method = () => ListAllVehicles() });
            menuCommands.Add("T", new MenuCommand { Description = "T", Method = () => ListVehicleTypes() });
            menuCommands.Add("L", new MenuCommand { Description = "L", Method = () => AddVehicle() });
            menuCommands.Add("R", new MenuCommand { Description = "R", Method = () => RemoveVehicle() });
            menuCommands.Add("S", new MenuCommand { Description = "S", Method = () => SearchVehicleByRegNo() });
            menuCommands.Add("C", new MenuCommand { Description = "C", Method = () => CreateNewGarage() });
            menuCommands.Add("G", new MenuCommand { Description = "G", Method = () => PrintNbrOfFreeSpots() });
            menuCommands.Add("M", new MenuCommand { Description = "M", Method = () => MenuHandler.PrintMainMenu() });
            menuCommands.Add("Q", new MenuCommand { Description = "Q", Method = () => run = false });
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

