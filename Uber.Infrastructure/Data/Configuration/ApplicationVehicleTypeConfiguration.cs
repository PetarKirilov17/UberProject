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
    public class ApplicationVehicleTypeConfiguration : IEntityTypeConfiguration<VehicleType>
    {
        public void Configure(EntityTypeBuilder<VehicleType> builder)
        {
            builder.ToTable("VehicleType");
            builder.HasData(SeedHelper.SeedData<VehicleType>("VehicleTypeSeeder.json"));
        }
    }
}
