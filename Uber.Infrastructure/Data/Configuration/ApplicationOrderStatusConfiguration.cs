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
    public class ApplicationOrderStatusConfiguration : IEntityTypeConfiguration<OrderStatus>
    {
        public void Configure(EntityTypeBuilder<OrderStatus> builder)
        {
            builder.ToTable("OrderStatus");
            builder.HasData(SeedHelper.SeedData<OrderStatus>("OrderStatusSeeder.json"));
        }
    }
}
