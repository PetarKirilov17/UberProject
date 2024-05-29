using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Uber.Models.Account
{
    public class RegisterViewModel
    {
        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required]
        public string Gender { get; set; } = null!;

        [Required]
        public int Age { get; set; }

        // Only for the client
        public bool isRegularCustomer { get; set; }

        // Only for the driver
        public string? DrivingLicence { get; set; }

        // Only for the driver
        public DateTime DrivingLicenceDateofIssue { get; set; } // used to calculate the experience the driver

        // Only for the driver
        public List<string>? VehicleCategories { get; set; }

        public string? ReturnUrl { get; set; }

        [TempData]
        public string? ErrorMessage { get; set; }

        public IList<AuthenticationScheme>? ExternalLogins { get; set; }



    }
}
