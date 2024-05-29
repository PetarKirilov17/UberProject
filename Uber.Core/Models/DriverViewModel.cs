using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uber.Core.Models
{
    /// <summary>
    /// This view model has the purpose to transfer data needed for the creation of a driver
    /// </summary>
    public class DriverViewModel
    {
        public int Id { get; set; } 

        [Required]
        [StringLength(10, MinimumLength = 10)]
        public string DrivingLicence { get; set; } = null!;

        [Required]
        public int YearsOfExperience { get; set; }

        public double Latitude { get; set; }
            
        public double Longitude { get; set; }

        public List<int> VehicleTypeIds { get; set; }
    }
}
