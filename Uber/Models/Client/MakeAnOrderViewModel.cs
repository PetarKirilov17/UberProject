using System.ComponentModel.DataAnnotations;

namespace Uber.Models.Client
{
    public class MakeAnOrderViewModel
    {
        public double CurrentAddressLatitude { get; set; }
        public double CurrentAddressLongitude { get; set; }
        public string? CurrentAddressDescription { get; set; }
        public double DestinationLatitude { get; set; }
        public double DestinationLongitude { get; set; }
        public string? DestinationDescription { get; set; }

        [Range(1, 7)]
        public short CountOfSeats { get; set; }

    }
}
