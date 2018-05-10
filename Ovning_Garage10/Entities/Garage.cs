using System;
using System.Collections;
using System.Collections.Generic;

namespace Ovning_Garage10.Entities
{
    internal class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        private T[] vehicles;

		private int NbrOfSpaces { get; }

        public Garage(int nbrOfSpaces)
        {
            NbrOfSpaces = nbrOfSpaces;
            vehicles = new T[nbrOfSpaces];
        }

		internal bool ParkVehicle(T vehicle)
        {
            if (GetIsFull()) return false;
			vehicles.SetValue(vehicle, GetFreeSpacePosition());
            return true;
        }

        public bool GetIsFull()
        {
            foreach (var item in vehicles)
				if (item == null) return false;
			return true;
        }

		private int GetFreeSpacePosition()
        {
            //NOTE: GetIsFull must be called first!
            int position = 0;
            for (int i = 0; i < NbrOfSpaces; i++)
            {
                if (vehicles[i] != null)
					continue;
				position = i;
				break;
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