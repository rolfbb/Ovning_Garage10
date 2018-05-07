using System;
using System.Collections.Generic;
using Ovning_Garage10.Entities;

namespace Ovning_Garage10.Examples
{
    class AdrianExampleVehicleFactory
    {
        private readonly string type;
        private readonly string color;

        public AdrianExampleVehicleFactory(string type, string color)
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
            var vf = new AdrianExampleVehicleFactory(type, color);

            string wheels = "round";
            Vehicle vehicle = vf.CreateCar(wheels);

            //alternativt, :
            //vf.GetCar();
            //fråga vf: vad behöver du för data vf.GetCarProperties() (dictionary, cyl/int, 
            //color/string, etc ENUM?); vf.AddProperty... vf.GetVehicle()
        }
    }



    // Adrian example of doing composite solution:
    ////enum VehicleEnum
    ////{
    ////    Car, Motorcycle
    ////}

    //class VehicleCreator
    //{
    //    public static VehicleBase Car()
    //    {
    //        var v = new VehicleBase()
    //        {
    //            VehicleType = VehicleEnum.Car.ToString()
    //        };
    //        v.Properties.Add(new KeyValuePair<string, string>("Cylindervolym", ""));
    //        return v;
    //    }
    //}

    //class VehicleBase
    //{
    //    /*
    //     * Istället för subklasser, fyller på properties för de olika typerna
    //     */
    //    public string VehicleType { get; set; }
    //    public List<KeyValuePair<string, string>> Properties { get; set; }
    //}
}



