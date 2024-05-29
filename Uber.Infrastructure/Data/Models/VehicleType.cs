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
    [Table("VehicleTypes")]
    [Comment("This is a class that describes the VehicleType Entity in the application.")]
    public class VehicleType
    {

        public VehicleType()
        {
            Drivers = new List<Driver>();
        }
        [Key]
        [Comment("Identfier of the vehicle type.")]
        public int TypeId { get; set; }

        [Required]
        [StringLength(50)]
        [Comment("Label that contains the type.")]
        public string Label { get; set; } = null!;

        [Comment("Collection that contains drivers that which have the rights to drive this type of vehicle")]
        public ICollection<Driver> Drivers { get; set; }
    }
}
