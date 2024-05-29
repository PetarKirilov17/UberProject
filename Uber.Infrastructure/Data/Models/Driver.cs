using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uber.Infrastructure.Data.Models
{
    [Comment("This is a class that describes the Driver Entity in the apllication. The Driver is one of the roles in the application.")]
    public class Driver
    {
        public Driver()
        {
            this.VehicleCategories = new List<VehicleType>();
            this.Vehicles = new List<Vehicle>();
            this.CancelledOrders = new List<DriversOrders>();
        }

        [Key]
        [Comment("Primary Key for the Driver Entity.")]
        public int DriverId { get; set; }

        //FK
        [Required]
        [Comment("Foreign Key that describes the 'is a' relationship between the Driver and the Person.")]
        public int PersonId { get; set; }
        [ForeignKey(nameof(PersonId))]
        public Person Person { get; set; } = null!;

        [Required]
        [StringLength(10)]
        [Comment("Field that contains information about the driving licence of the driver.")]
        public string DrivingLicence { get; set; } = null!;

        [Required]
        [Comment("Filed for the years of experience of the driver.")]
        public int Experience { get; set; }

        [Comment("Field that describes the current locaion of the driver by x and y coordinates.")]
        public NpgsqlTypes.NpgsqlPoint? CurrentPosition { get; set; }

        [Required]
        [Comment("Field that tells whether the driver is approved by the admin")]
        public bool IsDriverApproved { get; set; }

        [Required]
        [Comment("Field that tells whether the driver is free and therefore has the opportunity to accpet the order")]
        public bool IsFree { get; set; }

        [Comment("Field that contains the profit that the driver has made from their orders")]
        public decimal Profit { get; set; }

        [Comment("Collection that contains the types of vehicles that the driver has rights to drive.")]
        public ICollection<VehicleType> VehicleCategories { get; set; }

        [Comment("Collection that describes the 'many-to-many' relationship between the Driver and the Vehicle.")]
        public ICollection<Vehicle> Vehicles { get; set; }

        [Comment("Collection that contains information about the orders which the driver has been cancelled.")]
        public ICollection<DriversOrders> CancelledOrders;
    }
}
