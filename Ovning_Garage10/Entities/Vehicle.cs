using System;

namespace Ovning_Garage10.Entities
{
	internal partial class Vehicle
    {
		internal string Color { get; set; }
		internal float Length { get; set; }
		internal int NbrOfWheels { get; set; }
		internal int NbrOfSeats { get; set; }
  
		public Vehicle()
        {
        }

		public Vehicle(string color, float length, int nbrOfWheels, int nbrOfSeats)
        {
            Color = color;
            Length = length;
            NbrOfWheels = nbrOfWheels;
            NbrOfSeats = nbrOfSeats;
        }
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
		public Car()
		{
		}

		public Car(string fuel, string regNo, int cylinderVolume, int noOfEngines) : base(fuel, regNo, cylinderVolume, noOfEngines)
		{
		}
	}

	internal class Bus : MotorVehicle
	{
		public Bus()
		{
		}

		public Bus(string fuel, string regNo, int cylinderVolume, int noOfEngines) : base(fuel, regNo, cylinderVolume, noOfEngines)
		{
		}
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

