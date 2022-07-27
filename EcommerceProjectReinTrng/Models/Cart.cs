using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceProjectReinTrng.Models
{
    [Table("Cart")]
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        public int Id { get; set; }
        public int UserId { get; set; }
    }
}
