using AutoMapper;
using Vehicles.Context;
using Vehicles.Models.Binding;
using Vehicles.Models.Dbo;
using Vehicles.Models.ViewModel;
using Vehicles.Services.Interfaces;

namespace Vehicles.Services.Implementations
{
    public class VehicleService : IVehicleService
    {
        private readonly IMapper mapper;
        private readonly ApplicationDbContext db;

        public VehicleService(IMapper mapper, ApplicationDbContext db)
        {
            this.mapper = mapper;
            this.db = db;
        }
        /// <summary>
        /// Gets All Vehicles
        /// </summary>
        /// <returns></returns>
        public List<VehicleViewModel> GetAllVehicles()
        {
            var dbo = db.Vehicles.ToList();
            return dbo.Select(v => mapper.Map<VehicleViewModel>(v)).ToList();
        }

        /// <summary>
        /// Gets Vehicle By Id
        /// </summary>
        /// <returns></returns>
        public VehicleViewModel GetVehicleById(int id)
        {
            var dbo = db.Vehicles.FirstOrDefault(v => v.Id == id);
            return mapper.Map<VehicleViewModel>(dbo);
        }

        /// <summary>
        /// Adds Vehicle
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public VehicleViewModel AddVehicle(VehicleBinding model)
        {
            var dbo = mapper.Map<Vehicle>(model);
            db.Vehicles.Add(dbo);
            db.SaveChanges();
            return mapper.Map<VehicleViewModel>(dbo);
        }

        /// <summary>
        /// Edit Vehicle
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public VehicleViewModel EditVehicle(VehicleUpdateBinding model)
        {
            var dbo = db.Vehicles.FirstOrDefault(v => v.Id == model.Id);
            mapper.Map(model, dbo);
            db.SaveChanges();
            return mapper.Map<VehicleViewModel>(dbo);
        }
        
        /// <summary>
        /// Deletes Vehicle by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public VehicleViewModel DeleteVehicle(int id)
        {
            var dbo = db.Vehicles.FirstOrDefault(v => v.Id == id);
            db.Vehicles.Remove(dbo);
            db.SaveChanges();
            return mapper.Map<VehicleViewModel>(dbo);
        }
    }
}
