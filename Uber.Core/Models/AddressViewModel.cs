using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uber.Core.Models
{
    public class AddressViewModel
    {
        public int Id { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string? Description { get; set; }
    }
}
