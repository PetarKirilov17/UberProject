using NuGet.Protocol.Core.Types;
using System.ComponentModel.DataAnnotations;

namespace Uber.Models.Driver
{
    public class ProceedOrderViewModel
    {
        [Key]
        public int OrderId { get; set; }
        public string ClientName { get; set; } = null!;
        public double CurrentAddressLatitude { get; set; } 
        public double CurrentAddressLongitude { get; set; }
        public string CurrentAddressLabel { get; set; } = null!;
        public double DestinationAddressLatitude { get; set; }
        public double DestinationAddressLongitude { get; set; }
        public string DestinationAddressLabel { get; set; } = null!;
        public int CountOfSeats { get; set; }
    }
}
