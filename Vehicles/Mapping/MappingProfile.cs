using AutoMapper;
using Vehicles.Models.Binding;
using Vehicles.Models.Dbo;
using Vehicles.Models.ViewModel;

namespace Vehicles.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<VehicleBinding, Vehicle>();
            CreateMap<VehicleUpdateBinding, Vehicle>();
            CreateMap<Vehicle, VehicleViewModel>();
            CreateMap<VehicleUpdateBinding, VehicleViewModel>();
        }
    }
}
