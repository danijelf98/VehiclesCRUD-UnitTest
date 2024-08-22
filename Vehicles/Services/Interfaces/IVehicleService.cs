using Vehicles.Models.Binding;
using Vehicles.Models.ViewModel;

namespace Vehicles.Services.Interfaces
{
    public interface IVehicleService
    {
        VehicleViewModel AddVehicle(VehicleBinding model);
        VehicleViewModel DeleteVehicle(int id);
        VehicleViewModel EditVehicle(VehicleUpdateBinding model);
        List<VehicleViewModel> GetAllVehicles();
        VehicleViewModel GetVehicleById(int id);
    }
}