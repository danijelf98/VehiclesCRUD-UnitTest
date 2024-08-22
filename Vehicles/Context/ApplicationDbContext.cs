using Microsoft.EntityFrameworkCore;
using Vehicles.Models.Dbo;

namespace Vehicles.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
