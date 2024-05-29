using System.ComponentModel.DataAnnotations;

namespace Uber.Models.Account
{
	public class ForgotPasswordViewModel
	{
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
    }
}
