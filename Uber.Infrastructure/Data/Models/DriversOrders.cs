using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uber.Infrastructure.Data.Models
{
    [Comment("This is a class that describes the mapping Entity between the Driver and the Order")]
    public class DriversOrders
    {
        [Key]
        [Required]
        [Comment("Used to describe the 'many-to-many' relationship between the Driver and the Order. Used both as primary key and foregin to make the relationship with the driver.")]
        public int DriverId { get; set; }
        [ForeignKey(nameof(DriverId))]
        public Driver Driver { get; set; } = null!;

        [Key]
        [Required]
        [Comment("Used to describe the 'many-to-many' relationship between the Driver and the Order. Used both as primary key and foregin to make the relationship with the order.")]
        public int OrderId { get; set; }
        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; } = null!;
    }
}
