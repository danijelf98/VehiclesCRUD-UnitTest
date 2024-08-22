using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Vehicles.Context;
using Vehicles.Models.Dbo;
using Vehicles.Services.Implementations;
using Vehicles.Services.Interfaces;

namespace Vehicles.UnitTest
{
    public abstract class VehicleSetup
    {
        protected IMapper mapper { get; private set; }
        protected ApplicationDbContext InMemoryDbContext;

        public VehicleSetup()
        {
            SetupInMemoryDbContext();
            GenerateVehicleList(5);
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Mapping.MappingProfile());
            });
            mapper = mappingConfig.CreateMapper();
        }

        protected IVehicleService GetVehicleService(ApplicationDbContext? db = null)
        {
            if (db != null)
            {
                return new VehicleService(mapper, db);
            }
            return new VehicleService(mapper, InMemoryDbContext);
        }

        private void SetupInMemoryDbContext()
        {
            var inMemoryOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;

            InMemoryDbContext = new ApplicationDbContext(inMemoryOptions);
        }

        private List<Vehicle> GenerateVehicleList(int quantity)
        {
            List<Vehicle> vehicleList = new List<Vehicle>();
            Random random = new Random();
            for (int i = 1; i <= quantity; i++)
            {
                vehicleList.Add(
                    new Vehicle
                    {
                        Model = $"Model number {i}",
                        Brand = $"Brand number {i}",
                        Type = $"Type number {i}",
                        DoorNumber = random.Next(1, 5)
                    });
            }
            InMemoryDbContext.AddRange(vehicleList);
            InMemoryDbContext.SaveChanges();
            return vehicleList;
        }

    }
}
