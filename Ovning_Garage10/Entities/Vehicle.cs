using System;

namespace Ovning_Garage10.Entities
{
    internal class Vehicle
    {
        private string type;

        public string MyToString { get; set; }

        public Vehicle()
        {
        }

        public Vehicle(string type)
        {
            this.type = type;
        }

        public override string ToString()
        {
            return type; //TODO: Make something meaningfull here...
        }
    }

    internal class Airplane : Vehicle
    {
        public Airplane()
        {

        }
    }
    internal class Car : Vehicle
    {
        public Car()
        {
        }
    }
    internal class Bus : Vehicle
    {
        public Bus()
        {
        }
    }

    internal class Motorcycle : Vehicle
    {
        public Motorcycle()
        {
        }
    }

    internal class Boat : Vehicle
    {
        public Boat()
        {
        }
    }
}

/*
 * Sub classes: 
 *          Car
 *          Airplane
 *          Motorcycle
 *          Bus
 *          Boat
 *  
 */
