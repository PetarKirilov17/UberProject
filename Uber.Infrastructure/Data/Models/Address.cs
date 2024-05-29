using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uber.Infrastructure.Data.Models
{
    [Comment("This is a class that describes the Address Entity in the application.")]
    public class Address
    {
        [Key]
        [Comment("Primary Key of the Address Entity.")]
        public int AddressId { get; set; }

        [StringLength(200)]
        [Comment("Field that is used to make addtional description for the Address Entity which is optional.")]
        public string? Description { get; set; }

        [Comment("Field that describes the exact locaion of the address by x and y coordinates.")]
        public NpgsqlTypes.NpgsqlPoint? Location { get; set; }
    }
}
