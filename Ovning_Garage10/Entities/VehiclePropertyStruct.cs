namespace Ovning_Garage10.Entities
{
    public partial class VehicleFactory
    {
        internal struct VehiclePropertyStruct
        {
            public VehiclePropertyStruct(string propertyName, string propertyType, string propertyQuery) : this()
            {
                PropertyName = propertyName;
                PropertyType = propertyType;
                PropertyQuery = propertyQuery;
            }

            public string PropertyName
            {
                get;
                //set;
            }
            public string PropertyType
            {
                get;
                //set;
            }
            public string PropertyQuery
            {
                get;
                //set;
            }
        }
    }
}
