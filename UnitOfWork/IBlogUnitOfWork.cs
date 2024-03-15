using DataAccess.Blog.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Blog.UnitOfWork
{
    public interface IBlogUnitOfWork
    {
        public IProductRepository _productRepository { get; set; }
        public IPostRepository _postRepository { get; set; }
        public IOrderRepository _orderRepository { get; set; }
        void SaveChanges();
    }
}
