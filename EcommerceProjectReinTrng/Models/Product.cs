using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceProjectReinTrng.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public int CartId { get; set; }
        public int UserId { get; set; }
    }

}
