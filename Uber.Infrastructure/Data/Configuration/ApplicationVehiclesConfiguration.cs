using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uber.Infrastructure.Data.Models;

namespace Uber.Infrastructure.Data.Configuration
{
    public class ApplicationVehiclesConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("Vehicles", "public");
            builder.HasData(SeedHelper.SeedData<Vehicle>("VehiclesSeeder.json"));
        }
    }
}
