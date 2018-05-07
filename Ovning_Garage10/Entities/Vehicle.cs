using System;

namespace Ovning_Garage10.Entities
{
    internal class Vehicle
    {
        public Vehicle()
        {
        }

        public Vehicle(string color, float length, int noOfWheels, int noOfSeats)
        {
            Color = color;
            Length = length;
            NoOfWheels = noOfWheels;
            NoOfSeats = noOfSeats;
        }

        internal string Color { get; set; }
        internal float Length { get; set; }
        internal int NoOfWheels { get; set; }
        internal int NoOfSeats { get; set; }
    }

    internal partial class MotorVehicle : Vehicle
    {
        public MotorVehicle()
        {
        }

        public MotorVehicle(//string color, float length, int noOfWheels, int noOfSeats,
                               string fuel, string regNo, int cylinderVolume, int noOfEngines)
        {
            //Color = color;
            //Length = length;
            //NoOfWheels = noOfWheels;
            //NoOfSeats = noOfSeats;

            Fuel = fuel;
            RegNo = regNo;
            CylinderVolume = cylinderVolume;
            NoOfEngines = noOfEngines;
        }

        internal string Fuel { get; set; }
        internal string RegNo { get; set; }
        internal int CylinderVolume { get; set; }
        internal int NoOfEngines { get; set; }
    }

    internal class Car : MotorVehicle
    {
    }

    internal class Bus : MotorVehicle
    {
    }

    internal class Motorcycle : MotorVehicle
    {
    }

    internal class Airplane : MotorVehicle
    {
		public Airplane()
		{
		}
		//protected Airplane(string fuel, string regNo, int cylinderVolume, int noOfEngines) : base(fuel, regNo, cylinderVolume, noOfEngines)
		//{
		//}
		
    }
    internal partial class Boat : Vehicle
    {
        public Boat(int typeOfBoat)
        {
            TypeOfBoat = typeOfBoat;
        }

        internal int TypeOfBoat { get; set; }
    }
}

