using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Blog.Entities
{
    public class CreateOrderDetail
    {
        
        public int order_id { get; set; }
        public int product_id { get; set; }
        public int quantity { get; set; }
    }
}