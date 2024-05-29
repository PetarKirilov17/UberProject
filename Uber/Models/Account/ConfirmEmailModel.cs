using System.ComponentModel.DataAnnotations;

namespace Uber.Models.Account
{
	public class ConfirmEmailModel
	{
		[Required]
		public string StatusMessage { get; set; } = null!;
    }
}
