using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Models.Binding;
using Vehicles.Models.Dbo;
using Vehicles.Services.Interfaces;

namespace Vehicles.UnitTest
{
    public class VehicleServiceUnitTest : VehicleSetup
    {
        private readonly IVehicleService vehicleService;

        public VehicleServiceUnitTest()
        {
            this.vehicleService = GetVehicleService();
        }

        [Fact]
        public void AddNewVehicle_AddsNewVehicleInbase_ReturnsViewModel()
        {
            var result = vehicleService.AddVehicle(new Models.Binding.VehicleBinding()
            {
                Brand = "VW",
                Model = "Arteon",
                Type = "Sedan",
                DoorNumber = 4
            });
            Assert.NotNull(result);
        }

        [Fact]
        public void GetAllVehicles_GetsAllVehicles_ReturnsListQuantity()
        {
            var response = vehicleService.GetAllVehicles();
            Assert.NotEmpty(response);
            Assert.Equal(5, response.Count);
        }

        [Fact]
        public void GetVehicleById_GetsVehicleById_ReturnsSelectedVehicle()
        {
            var response = vehicleService.GetVehicleById(2);
            Assert.NotNull(response);
            Assert.Equal(2, response.Id);
        }

        [Fact]
        public void DeleteVehicle_GetsAllVehiclesAndDeletesFirstVehicle_VehicleIsDeleted()
        {
            var vehicles = vehicleService.GetAllVehicles();
            int vehicleId = vehicles[0].Id;

            Assert.NotEmpty(vehicles);
            Assert.Equal(5, vehicles.Count());

            vehicleService.DeleteVehicle(vehicleId);
            vehicles = vehicleService.GetAllVehicles();
            var deletedVehicle = vehicles.FirstOrDefault(v => v.Id == vehicleId);

            Assert.Null(deletedVehicle);
            
        }

        [Fact]
        public void EditVehicle_UpdatesVehicleInforimation_ReturnsUpdatedVehicle()
        {
            var vehicles = vehicleService.GetAllVehicles();
            int vehicleId = vehicles[0].Id;
            VehicleUpdateBinding input = new VehicleUpdateBinding()
            {
                Brand = "Audi",
                Model = "A4",
                Type = "Coupe",
                Id = vehicleId
            };

            vehicleService.EditVehicle(input);
            var vehicle = vehicleService.GetVehicleById(vehicleId);
            Assert.NotNull(vehicle);

            Assert.Equal(input.Id, vehicle.Id);

        }
    }
}
