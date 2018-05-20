using System;
using System.Collections.Generic;
using Ovning_Garage10.Utilities;

namespace Ovning_Garage10.Entities
{
    public partial class VehicleFactory
    {
        private static Dictionary<string, VehiclePropertyStruct> propStructDict = new Dictionary<string, VehiclePropertyStruct>();

        public VehicleFactory()
        {
        }

        public VehicleFactory(string type, string color)
        {
        }

        internal Vehicle CreateVehicle()
        {
            Vehicle vehicle = new Vehicle();
            propStructDict = CreatePropertyStructDict(Vehicle.PropertyTypeDict); //TODO: Should it return the array?

            string inputStr;
            int inputInt;
            foreach (var propStructKvp in propStructDict)
            {
                var propStruct = propStructKvp.Value;
                if (propStruct.PropertyType == "string")
                {
                    inputStr = UI.Ask(propStruct.PropertyQuery);
                    SetProperty(vehicle, propStruct.PropertyName, inputStr);
                }
                else if (propStruct.PropertyType == "int")
                {
                    inputInt = UI.AskForInt(propStruct.PropertyQuery);
                    SetProperty(vehicle, propStruct.PropertyName, inputInt);
                }
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

        private static Dictionary<string, VehiclePropertyStruct> CreatePropertyStructDict(Dictionary<string, string> propTypeDict)
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
                    propStructDict[property] = new VehiclePropertyStruct(property, pType, pMessage);
                    i++;
                }
                catch (Exception ex)
                {
                    UI.ErrorLine("Warning, an error occured when setting descriptive message for property {0}", property);
                    UI.ErrorLine(ex.Message);
                }
            }

            return propStructDict; // TODO: Clone?
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
