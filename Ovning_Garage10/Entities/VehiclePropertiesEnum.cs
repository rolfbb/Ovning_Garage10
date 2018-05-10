using System.ComponentModel;

namespace Ovning_Garage10.Entities
{
    internal partial class Vehicle
    {
        public enum VehiclePropertiesEnum 
		{ 
			[Description("string")]
			Color, 
			[Description("int")]
			Lenght, 
			[Description("int")]
			NbrOfWheels, 
			[Description("int")]
			NbrOfSeats 
		}
    }
}

