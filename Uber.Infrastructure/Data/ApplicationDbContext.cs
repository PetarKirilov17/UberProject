using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System.Reflection.Emit;
using Uber.Infrastructure.Data.Configuration;
using Uber.Infrastructure.Data.Models;

namespace Uber.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<DriversOrders>().HasKey(drOr => new { drOr.DriverId, drOr.OrderId });
            builder.ApplyConfiguration(new ApplicationVehicleTypeConfiguration());
            builder.ApplyConfiguration(new ApplicationVehiclesConfiguration());
            builder.ApplyConfiguration(new ApplicationOrderStatusConfiguration());
        }


        public DbSet<Person> People { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
    }
}