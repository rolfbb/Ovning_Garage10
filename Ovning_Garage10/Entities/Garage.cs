using System.Collections;
using System.Collections.Generic;

namespace Ovning_Garage10.Entities
{
    internal class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        private int nbrOfParkingLots;
        private Vehicle[] vehicles;

        public Garage(int noParkingLots)
        {
            this.nbrOfParkingLots = noParkingLots;
            vehicles = new Vehicle[noParkingLots];

        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in vehicles)
            {
                yield return (T) item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}