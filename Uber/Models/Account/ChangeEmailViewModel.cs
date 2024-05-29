using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Uber.Models.Account
{
    public class ChangeEmailViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Current Email")]
        public string CurrentEmail { get; set; } = null!;

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "New Email")]
        public string NewEmail { get; set; } = null!;

        public bool IsEmailConfirmed { get; set; }
    }
}
