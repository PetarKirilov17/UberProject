using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Uber.Models.Driver
{
    public class DriverIndexViewModel
    {
        [Key]
        public int DriverId { get; set; }

        [Display(Name = "Driving Licence Id")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Your drving licence should be 10 symbols")]
        public string DrivingLicence { get; set; } = null!;

        [Display(Name = "Years of experience as a driver")]
        public int YearsOfExperience { get; set; }

        [Display(Name = "Vehicle categories that you are able to drive")]
        public IList<string> VehicleCategoriesLabels { get; set; } = null!;

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public bool IsApproved { get; set; }
    }
}
