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
    [Comment("This is a class that describes the Client Entity in the apllication. The Client is one of the roles in the application.")]
    public class Client
    {
        [Key]
        [Comment("Primary Key for the Client Entity.")]
        public int ClientId { get; set; }

        //FK
        [Required]
        [Comment("Foreign Key that describes the 'is a' relationship between the Client and the Person.")]
        public int PersonId { get; set; }

        [ForeignKey(nameof(PersonId))]
        public Person Person { get; set; } = null!;

        [Comment("Field that describes whether the client is regular.")]
        public bool isRegularCustomer { get; set; }

        [Comment("Field that contains the current balance of the client")]
        public decimal Balance { get; set; }
    }
}
