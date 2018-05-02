using System;
using System.Collections;
using System.Collections.Generic;

namespace Ovning_Garage10.Entities
{
    internal class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        private Vehicle[] vehicles;

        private int NbrOfParkingLots { get; }

        public Garage(int nbrOfParkingLots)
        {
            NbrOfParkingLots = nbrOfParkingLots;
            vehicles = new Vehicle[nbrOfParkingLots];
        }

        internal bool AddVehicle()
        {
            Console.WriteLine($"vehicles.Length: {vehicles.Length}, IsFull: {GetIsFull()}");
            if (GetIsFull()) return false;
            Vehicle vehicle = new Vehicle("Car");
            int freeSpot = GetFreeParkingSpotPosition(vehicles);
            vehicles.SetValue(vehicle, freeSpot);
            Console.WriteLine("Adding new vehicle done!");
            return true;
        }

        public bool GetIsFull()
        {
            bool isFull = true;
            foreach (var item in vehicles)
            {
                if (item == null)
                {
                    isFull = false;
                    break;
                }
            }
            Console.WriteLine("GetIsFull: " + isFull);
            return isFull;
        }

        private int GetFreeParkingSpotPosition(Vehicle[] vehicles)
        {
            int position = 0;
            for (int i = 0; i < NbrOfParkingLots; i++)
            {
                var v = vehicles[i];
                if (v == null)
                {
                    position = i;
                    break;
                }
                v.ToString();
            }
            Console.WriteLine("Returning free position: " + position);
            return position;
        }

        internal int GetNbrOfFreeSpots()
        {
            int count = 0;
            foreach (var item in this)
            {
                if (item == null)
                    count++;
            }
            return count;
        }

        internal void ListAllVehicles()
        {
            foreach (var item in this)
            {
                if (item != null)
                    Console.WriteLine("item: " + item.ToString());
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in vehicles)
            {
                yield return (T)item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}