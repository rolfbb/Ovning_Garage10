using System;

namespace Ovning_Garage10.Entities
{
    internal class Vehicle
    {
        private string type;

        public string MyToString { get; set; }

        public Vehicle(string type)
        {
            this.type = type;
        }

        public override string ToString()
        {
            return type; //TODO: Make something meaningfull here...
        }
    }
}

/*
 * Sub classes: 
 *  
 */