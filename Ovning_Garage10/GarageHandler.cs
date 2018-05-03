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
                    Console.WriteLine($"Kommando '{key.ToString()}' finns ej!");
                }
            } while (run);

        }

        private void Init()
        {
            InitMessages();
            InitCommands();
            Console.WriteLine("Det finns inget garage - ett nytt garage behöver skapas.");
            CreateNewGarage();
        }

        private void InitMessages()
        {
            Msg.InitMessages();
        }

        private void InitCommands()
        {
            menuCommands = MenuHandler.InitCommands();
            menuCommands.Add("F", new MenuCommand { Description = "Listar samtliga parkerade fordon", Method = () => ListAllVehicles() });
            menuCommands.Add("T", new MenuCommand { Description = "Listar fordonstyper och hur många av varje som står i garaget", Method = () => ListVehicleTypes() });
            menuCommands.Add("L", new MenuCommand { Description = "Lägg till fordon", Method = () => AddVehicle() });
            menuCommands.Add("R", new MenuCommand { Description = "Ta bort fordon", Method = () => RemoveVehicle() });
            menuCommands.Add("S", new MenuCommand { Description = "Sök fordon via registreringsnumret", Method = () => SearchVehicleByRegNo() });
            menuCommands.Add("C", new MenuCommand { Description = "Skapa nytt garage", Method = () => CreateNewGarage() });
            menuCommands.Add("G", new MenuCommand { Description = "Antal lediga parkeringsplatser", Method = () => PrintNbrOfFreeSpots() });
            menuCommands.Add("M", new MenuCommand { Description = "Huvudmeny", Method = () => MenuHandler.PrintMainMenu() });
            menuCommands.Add("Q", new MenuCommand { Description = "Du har valt att avsluta programmet", Method = () => run = false });
        }

        private int GetNbrOfFreeSpots()
        {
            return garage.GetNbrOfFreeSpots();
        }

        private void PrintNbrOfFreeSpots()
        {
            Console.WriteLine("Antal lediga parkeringsplatser: " + GetNbrOfFreeSpots());
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
            Vehicle vehicle = new Vehicle("Car");

            garage.RemoveVehile(vehicle);
        }

        private bool AddVehicle()
        {

            Vehicle vehicle = new Car();
            Console.WriteLine("Nytt fordon: " + vehicle.GetType().Name + " " + Msg.message(vehicle.GetType().Name));
            bool retval = garage.AddVehicle(vehicle);
            if(retval)
                Console.WriteLine($"Fordonet är parkerat. Det finns {GetNbrOfFreeSpots()} platser kvar.");
            else
                Console.WriteLine($"Det går inte att parkera; det finns {GetNbrOfFreeSpots()} platser kvar.");
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

