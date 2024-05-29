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
    [Comment("This is a class that describes the Vehicle Entity in the application.")]
    public class Vehicle
    {
        public Vehicle()
        {
            this.Drivers = new List<Driver>();
        }

        [Key]
        [Comment("Primary Key for the Vehicle Entity.")]
        public int VehicleId { get; set; }

        [Required]
        [StringLength(50)]
        [Comment("Field that describes the brand of the vehicle.")]
        public string Brand { get; set; } = null!;

        [Required]
        [StringLength(50)]
        [Comment("Field that describes the model of the vehicle.")]
        public string Model { get; set; } = null!;

        [Comment("Field that saves the max count of the vehicle seats.")]
        public short MaxSeats { get; set; }

        [Comment("Field that saves the year of the production the vehicle seats.")]
        public short YearOfProduction { get; set; }

        [Comment("Field that tells whether the vehice is free at the moment.")]
        public bool IsFree { get; set; }

        [Required]
        [Comment("Foreign Key that describes a 'one-to-many' relationship between the Vehicle and the VehicleType. Contains information about the type of the vehicle.")]
        public int VehicleTypeId { get; set; }
        [ForeignKey(nameof(VehicleTypeId))]
        public VehicleType VehicleType { get; set; } = null!;

        [Comment("Collection that describes the 'many-to-many' relationship between the Vehicle and the Driver.")]
        public ICollection<Driver> Drivers { get; set; }
    }
}