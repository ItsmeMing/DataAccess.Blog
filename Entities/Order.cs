using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Blog.Entities
{
    public class Order
    {
        [Key]
        public int id { get; set; }

        [Required]
        public Guid order_code { get; set; }
        
        [Required]
        public int customer_id { get; set; }
        
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime created_at { get; set; }

        [Required]
        public int status { get; set; }
    }
}