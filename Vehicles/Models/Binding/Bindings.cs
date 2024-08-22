using Vehicles.Models.Base;

namespace Vehicles.Models.Binding
{
    public class VehicleBinding : VehicleBase
    {

    }
    public class VehicleUpdateBinding : VehicleBase
    {
        public int Id { get; set; }
    }
}
