using System;
using System.Collections;
using System.Collections.Generic;

namespace Ovning_Garage10.Entities
{
    internal class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        private T[] vehicles;

        private int NbrOfParkingLots { get; }

        public Garage(int nbrOfParkingLots)
        {
            NbrOfParkingLots = nbrOfParkingLots;
            vehicles = new T[nbrOfParkingLots];
        }

        internal bool AddVehicle(T vehicle)
        {
            if (GetIsFull()) return false;
            vehicles.SetValue(vehicle, GetFreeParkingSpotPosition());
            return true;
        }

        public bool GetIsFull()
        {
            foreach (var item in vehicles)
            {
                if (item == null) return false;
            }
            return true;
        }

        private int GetFreeParkingSpotPosition()
        {
            //NOTE: GetIsFull must be called first!
            int position = 0;
            for (int i = 0; i < NbrOfParkingLots; i++)
            {
                if (vehicles[i] == null)
                {
                    position = i;
                    break;
                }
            }
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
                    Console.WriteLine(MessageHandler.message("vehicleColon") + item.ToString());
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in vehicles)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        internal void RemoveVehile(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }
    }
}