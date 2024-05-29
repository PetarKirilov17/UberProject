using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uber.Core.Models
{
	public class PersonViewModel
	{
		public int Id { get; set; }

		[Required]
		[StringLength(50)]
		public string FirstName { get; set; } = null!;

		[Required]
		[StringLength(50)]
		public string LastName { get; set; } = null!;

		[Required]
		[StringLength(50)]
		public string Gender { get; set; } = null!;

		[Required]
		public int Age { get; set; }
	}
}
