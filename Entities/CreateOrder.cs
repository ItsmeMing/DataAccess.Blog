using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Blog.Entities
{
    public class CreateOrder
    {
        public int CustomerId { get; set; }
        public List<OrderDetail> orderDetails { get; set; }
    }
}