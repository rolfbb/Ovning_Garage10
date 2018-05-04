using System;

namespace Ovning_Garage10.Entities
{
    internal class Vehicle
    {
        //color
        //lenght
        //noOfWheels
        //fuelType
        //noOfSeats

        //cylinderVolume
        //noOfEngines
        //regNo

        public Vehicle()
        {
        }
    }

    internal class MotorVehicle : Vehicle
    {
        public MotorVehicle()
        {
        }
        public Car(string type, string color)
        {
        }
    }

    internal class Bicycle : Vehicle
    {
        public Bicycle()
        {
        }
    }

    internal class Airplane : Vehicle
    {
        public Airplane()
        {
        }
    }

    internal class RegisteredVehicle : Vehicle
    {
        public RegisteredVehicle()
        {
        }
    }

    internal class Car : Vehicle
    {
        public Car()
        {
        }
        public Car(string type, string color)
        {
        }
        public Car(string type, string color, string wheels)
        {
        }
    }
    internal class Bus : Vehicle
    {
        public Bus()
        {
        }
        public Bus(string type, string color)
        {
        }
        public Bus(string type, string color, string passengers)
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

