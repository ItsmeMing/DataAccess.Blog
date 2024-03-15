using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Blog.Entities
{
    public class OrderDetail
    {
        [Key]
        public int id { get; set; }

        [Required]
        [ForeignKey("order_id")]
        public int order_id { get; set; }
        
        [Required]
        [ForeignKey("product_id")]
        public int product_id { get; set; }
        
        [Required]
        public int quantity { get; set; }
    }
}