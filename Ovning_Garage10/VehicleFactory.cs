using Ovning_Garage10.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning_Garage10
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
            return new Car(type, color, wheels);
        }

        public Bus CreateBus(string passengers)
        {
            return new Bus(type, color, passengers);
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
            //fråga vf: vad behöver du för data vf.GetCarProperties() (dictionary, cyl/int, color/string, etc ENUM?); vf.AddProperty... vf.GetVehicle()
        }
    }



    enum VehicleType
        {
            Car, Motorcycle
        }

    class VehicleCreator
    {
        public static VehicleBase Car()
        {
            var v = new VehicleBase()
            {
                VehicleType = VehicleType.Car,
            };
            v.Properties.Add(new KeyValuePair<string, string>("Cylindervolym", ""));
            return v;
        }
    }

    class VehicleBase
    {
        /*
         * Istället för subklasser, fyller på properties för de olika typerna
         */ 
        public string VehicleType { get; set; }
        public List<KeyValuePair<string, string>> Properties { get; set; }
    }
}
