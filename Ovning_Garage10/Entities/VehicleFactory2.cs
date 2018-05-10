using System;
using System.Collections.Generic;
using Ovning_Garage10.Entities;
using Ovning_Garage10.Utilities;

namespace Ovning_Garage10.Examples
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

			return vehicle;
		}

		private static KeyValuePair<string, string>[] GetCreateVehicleInputList(KeyValuePair<string, string>[] qArr)
		{
			string pName;
			string pMessage;
			string property;
			var vehicleProperties = Enum.GetValues(typeof(Vehicle.VehiclePropertiesEnum));

			for (int i = 0; i < vehicleProperties.Length; i++)
			{
				property = vehicleProperties.GetValue(i).ToString();
				try
				{
					pName = MessageHandler.message(property);
					pMessage = MessageHandler.message(property) + "Message";
					KeyValuePair<string, string> propertyMessageKvp = new KeyValuePair<string, string>(pName, pMessage);
					qArr[i] = propertyMessageKvp;
				}
				catch (Exception ex)
				{
					UI.ErrorLine("Warning, an error occured when setting descriptive message for property {0}", property);
					UI.ErrorLine(ex.Message);

                    //Fallback, set default value...
					KeyValuePair<string, string> propertyMessageKvp = 
						new KeyValuePair<string, string>(property, String.Format("Set value for {0}", property));
                    qArr[i] = propertyMessageKvp;
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
