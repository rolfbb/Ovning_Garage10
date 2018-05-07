using System;
using System.Collections.Generic;
using Ovning_Garage10.Entities;

namespace Ovning_Garage10.Examples
{
    class VehicleFactory
    {
        private readonly string type;
        private readonly string color;

        public VehicleFactory(string type, string color)
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
            var vf = new VehicleFactory(type, color);

            string wheels = "round";
            Vehicle vehicle = vf.CreateCar(wheels);

            //alternativt, :
            //vf.GetCar();
            //fråga vf: vad behöver du för data vf.GetCarProperties() (dictionary, cyl/int, 
            //color/string, etc ENUM?); vf.AddProperty... vf.GetVehicle()
        }
    }
}
