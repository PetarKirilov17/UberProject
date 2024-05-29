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
    [Comment("This is a class that describes the Order Entity in the application.")]
    public class Order
    {
        public Order()
        {
            this.DriversWhoHaveCancelled = new List<DriversOrders>();
        }
        [Key]
        [Comment("Primary Key of the Order Entity.")]
        public int OdrerId { get; set; }

        //FK
        [Required]
        [Comment("Foreign Key that describes a 'one-to-many' relationship between the Order and the Address. Contains information about the current address of the order.")]
        public int CurrentAddressId { get; set; }
        [ForeignKey(nameof(CurrentAddressId))]
        public Address CurrentAddress { get; set; } = null!;

        //FK
        [Required]
        [Comment("Foreign Key that describes a 'one-to-many' relationship between the Order and the Address. Contains information about the destination address of the order.")]
        public int DestinationId { get; set; }
        [ForeignKey(nameof(DestinationId))]
        public Address Destination { get; set; } = null!;

        [Comment("Field that saves the count of the passengers of the order.")]
        public short CountOfPassengers { get; set; }

        //FK
        [Required]
        [Comment("Foreign Key that describes a 'one-to-many' relationship between the Order and the Vehicle. Contains information about the vehicle with which the order will be run.")]
        public int VehicleId { get; set; }
        [ForeignKey(nameof(VehicleId))]
        public Vehicle Vehicle { get; set; } = null!;

        //FK
        [Required]
        [Comment("Foreign Key that describes a 'one-to-many' relationship between the Order and the Client. Contains information about the client that made the order.")]
        public int ClientId { get; set; }
        [ForeignKey(nameof(ClientId))]
        public Client Client { get; set; } = null!;

        //FK
        [Required]
        [Comment("Foreign Key that describes a 'one-to-many' relationship between the Order and Driver. Contains information about the driver that will run the order.")]
        public int DriverId { get; set; }
        [ForeignKey(nameof(DriverId))]
        public Driver Driver { get; set; } = null!;

        [Required]
        [Comment("Foreign Key that describes a 'one-to-many' relationship between the Order and the OrderStatus. Contains information about the current status of the order.")]
        public int OrderStatusId { get; set; }
        [ForeignKey(nameof(OrderStatusId))]
        public OrderStatus OrderStatus { get; set; } = null!;

        [Comment("Collection that contains information about the drivers who have cancelled the order.")]
        public ICollection<DriversOrders> DriversWhoHaveCancelled { get; set; }

    }
}
