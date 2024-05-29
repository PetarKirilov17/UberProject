using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using Uber.Infrastructure.Data.Models;

namespace Uber.Models.Client
{
    public class ApplyForDriverViewModel
    {
        [Required]
        [Display(Name = "Driving Licence Id")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Your drving licence should be 10 symbols")]
        public string DrivingLicence { get; set; } = null!;

        [Required]
        [Display(Name = "Years of experience as a driver")]
        public int YearsOfExperience { get; set; }

        [Display(Name ="Vehicle categories that you are able to drive")]
        public IList<SelectListItem> VehicleCategories { get; set; } = null!;

        public double Latitude { get; set; }

        public double Longitude { get; set; }

    }
}
