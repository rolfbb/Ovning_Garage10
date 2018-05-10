using System;
using System.Collections;
using System.Collections.Generic;

namespace Ovning_Garage10.Entities
{
    internal class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        private T[] vehicles;

        private int NbrOfParkingSpaces { get; }

        public Garage(int nbrOfParkingSpaces)
        {
            NbrOfParkingSpaces = nbrOfParkingSpaces;
            vehicles = new T[nbrOfParkingSpaces];
        }

        internal bool AddVehicle(T vehicle)
        {
            if (GetIsFull()) return false;
			vehicles.SetValue(vehicle, GetFreeParkingSpacePosition());
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

        private int GetFreeParkingSpacePosition()
        {
            //NOTE: GetIsFull must be called first!
            int position = 0;
            for (int i = 0; i < NbrOfParkingSpaces; i++)
            {
                if (vehicles[i] == null)
                {
                    position = i;
                    break;
                }
            }
            return position;
        }

        internal int GetNbrOfFreeSpaces()
        {
            int count = 0;
            foreach (var item in this)
            {
                if (item == null)
                    count++;
            }
            return count;
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