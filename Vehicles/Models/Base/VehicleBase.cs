namespace Vehicles.Models.Base
{
    public abstract class VehicleBase
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public int DoorNumber { get; set; }
    }
}
