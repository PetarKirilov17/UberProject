using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Uber.Core.Models
{
    /// <summary>
    /// This view model has the purpose to transfer data needed for the creation of an order
    /// </summary>
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }

        public int DriverId { get; set; }
        public int CurrentAddressId { get; set; }
        public int DestinationId { get; set; }
        public int CountOfSeats { get; set; }

        public int StatusId { get; set; }
    }
}
