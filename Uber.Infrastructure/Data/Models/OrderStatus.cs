using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uber.Infrastructure.Data.Models
{
    [Comment("This is a class that describes the OrderStatus Entity in the application.")]
    public class OrderStatus
    {
        [Key]
        [Comment("Identfier of the status.")]
        public int StatusId { get; set; }

        [Required]
        [StringLength(50)]
        [Comment("Label that contains the value of the status.")]
        public string Label { get; set; } = null!;
    }
}
