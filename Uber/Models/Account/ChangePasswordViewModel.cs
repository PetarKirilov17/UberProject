using System.ComponentModel.DataAnnotations;

namespace Uber.Models.Account
{
	public class ChangePasswordViewModel
	{
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current Password")]
        public string CurrentPassword { get; set; } = null!;

		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "New Password")]
		public string NewPassword { get; set; } = null!;

		[Required]
		[Display(Name = "Confirm New Password")]
		[Compare("NewPassword", ErrorMessage = "New Password and Confirm New Password must be the same!")] // the compare value must be the same the name of the field
		public string ConfirmNewPassword { get; set;} = null!;
	}
}
