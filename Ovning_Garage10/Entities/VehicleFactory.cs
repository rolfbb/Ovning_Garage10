using System;
using System.Collections.Generic;
using Ovning_Garage10.Utilities;

namespace Ovning_Garage10.Entities
{
	public class VehicleFactory
	{
        // Array used for asking property queries to the user
        //private static KeyValuePair<string, string>[] propQArr = new KeyValuePair<string, string>[4]; //name/type

        // Property query dictionary: dictKey=property, kvpKey=type, kvpValue=input query text
        private static Dictionary<string, KeyValuePair<string, string>> propQueryDict = new Dictionary<string, KeyValuePair<string, string>>();

		public VehicleFactory()
		{
		}

		public VehicleFactory(string type, string color)
		{
		}

		internal Vehicle CreateVehicle()
		{
			Vehicle vehicle = new Vehicle();
            CreatePropertyQueryDict(Vehicle.PropertyTypeDict); //TODO: Should it return the array?

			Console.WriteLine("CreateVehicleArr: ");
			string input;
			foreach (var kvp in propQDict)
			{
				input = UI.Ask(kvp.Value);
				string property = kvp.Value;
				//vehicle.(kvp.Value) = input;
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
                default:
                    break;
            }
        }

        private static void SetProperty(Vehicle vehicle, string pName, int pValue)
        {
            switch (pName)
            {
                case "Length":
                    vehicle.Length = pValue; //int 
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

        private static KeyValuePair<string, string>[] CreatePropertyQueryDict(Dictionary<string, string> propTypeDict)
        {
            
            string pType;
            string pMessage;
            var propKeys = propTypeDict.Keys;
            int i = 0;

            foreach (string property in propKeys)
            {
                try
                {
					pType = propTypeDict[property];
                    pMessage = MessageHandler.message(property + "Msg");
                    KeyValuePair<string, string> propertyMessageKvp = new KeyValuePair<string, string>(property, pType);
                    propQArr[i] = propertyMessageKvp;
                    i++;
                }
                catch (Exception ex)
                {
                    UI.ErrorLine("Warning, an error occured when setting descriptive message for property {0}", pNameß);
                    UI.ErrorLine(ex.Message);
                }
            }

            return propQArr; // TODO: Clone?
        }

		private static KeyValuePair<string, string>[] GetCreateVehicleInputListByENUM(KeyValuePair<string, string>[] propQArr)
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
                    propQArr[i] = propertyMessageKvp;
                }
                catch (Exception ex)
                {
                    UI.ErrorLine("Warning, an error occured when setting descriptive message for property {0}", pNameß);
                    UI.ErrorLine(ex.Message);
                }
            }

            return (KeyValuePair<string, string>[])propQArr.Clone();
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
