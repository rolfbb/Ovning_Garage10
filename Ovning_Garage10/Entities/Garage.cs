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
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}