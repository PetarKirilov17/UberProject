using System.ComponentModel.DataAnnotations;

namespace Uber.Models.Account
{
	public class ResetPasswordViewModel
	{
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password must be the same!")]
        public string ConfirmPassword { get; set; } = null!;

        [Required]
        public string Token { get; set; } = null!;
    }
}
