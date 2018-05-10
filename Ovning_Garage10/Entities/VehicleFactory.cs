using System;
using System.Collections.Generic;
using Ovning_Garage10.Utilities;

namespace Ovning_Garage10.Entities
{
	public class VehicleFactory
	{
		KeyValuePair<string, string>[] createVehicleArr = new KeyValuePair<string, string>[4];

		public VehicleFactory()
		{
		}

		public VehicleFactory(string type, string color)
		{
		}

		internal Vehicle CreateVehicle()
		{
			Vehicle vehicle = new Vehicle();
			GetCreateVehicleInputList(createVehicleArr); //TODO: Should it return the array?

			Console.WriteLine("CreateVehicleArr: ");
			string input;
			foreach (var kvp in createVehicleArr)
			{
				input = UI.Ask(kvp.Value);
				string property = kvp.Value;
				vehicle.(kvp.Value) = input;
			}

			return vehicle;
		}

		private static void SetProperty(Vehicle vehicle, string pName, string pValue)
		{
			switch (pName)
			{
				case "Color": 
					vehicle.Color = pValue; 
					break;
				case "Length": 
					vehicle.Length = pValue; 
					break;
				case "NbrOfWheels": 
					vehicle.NbrOfWheels = pValue; 
					break;
				case "NbrOfSeats": 
					vehicle.NbrOfSeats = pValue; 
					break;
				default:
					break;
			}
		}

		private static KeyValuePair<string, string>[] GetCreateVehicleInputList(KeyValuePair<string, string>[] qArr)
		{
			string pName;
			string pMessage;
			var vehicleProperties = Enum.GetValues(typeof(Vehicle.VehiclePropertiesEnum));

			for (int i = 0; i < vehicleProperties.Length; i++)
			{
				pName = vehicleProperties.GetValue(i).ToString();
				try
				{
					pMessage = MessageHandler.message(pName + "Msg");
					KeyValuePair<string, string> propertyMessageKvp = new KeyValuePair<string, string>(pName, pMessage);
					qArr[i] = propertyMessageKvp;
				}
				catch (Exception ex)
				{
					UI.ErrorLine("Warning, an error occured when setting descriptive message for property {0}", pNameß);
					UI.ErrorLine(ex.Message);
				}
			}

			return (KeyValuePair<string, string>[])qArr.Clone();
		}

		internal Car CreateCar(string wheels)
		{
			return new Car();
		}

		internal Bus CreateBus(string passengers)
		{
			return new Bus();
		}

		private void Testing()
		{
			string type = "CAR";
			string color = "green";
			var vf = new VehicleFactory(type, color);

			string wheels = "round";
			Vehicle vehicle = vf.CreateCar(wheels);

			//alternativt, :
			//vf.GetCar();
			//fråga vf: vad behöver du för data vf.GetCarProperties() (dictionary, cyl/int, 
			//color/string, etc ENUM?); vf.AddProperty... vf.GetVehicle()
		}
	}

	class VehicleFactoryAdrian
	{
		private readonly string type;
		private readonly string color;

		public VehicleFactoryAdrian(string type, string color)
		{
			this.type = type;
			this.color = color;
		}

		public Car CreateCar(string wheels)
		{
			return new Car();
		}

		public Bus CreateBus(string passengers)
		{
			return new Bus();
		}

		private void Testing()
		{
			string type = "CAR";
			string color = "green";
			var vf = new VehicleFactoryAdrian(type, color);

			string wheels = "round";
			Vehicle vehicle = vf.CreateCar(wheels);

			//alternativt, :
			//vf.GetCar();
			//fråga vf: vad behöver du för data vf.GetCarProperties() (dictionary, cyl/int, 
			//color/string, etc ENUM?); vf.AddProperty... vf.GetVehicle()
		}
	}
}
