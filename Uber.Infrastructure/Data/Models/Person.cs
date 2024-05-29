using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uber.Infrastructure.Data.Models
{
    [Comment("This is a base entity for a person in the application.")]
    public class Person
    {
        [Key]
        [Comment("Primary Key for the Person entity.")]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Comment("Field for the first name of the person.")]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(50)]
        [Comment("Field for the last name of the person.")]
        public string LastName { get; set; } = null!;

        [Required]
        [StringLength(50)]
        [Comment("Field for the gender of the person.")]
        public string Gender { get; set; } = null!;

        [Required]
        [Comment("Field for the age of the person.")]
        public int Age { get; set; }

        [Required]
        [Comment("Foreign Key that is used to connect the Person Entity with the IdentityUser in the application.")]
        public string UserId { get; set; } = null!;
        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;

    }
}
