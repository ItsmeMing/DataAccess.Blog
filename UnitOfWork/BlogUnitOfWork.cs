using DataAccess.Blog.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Blog.EntityFramework;
using DataAccess.Blog.UnitOfWork;

namespace DataAccess.Eshop.UnitOfWork
{
    public class BlogUnitOfWork : IBlogUnitOfWork, IDisposable
    {
        public IProductRepository _productRepository { get; set; }
        public IOrderRepository _orderRepository { get; set; }
        public IPostRepository _postRepository { get; set; }
        public BlogDbContext _blogDbContext;

        public BlogUnitOfWork(IProductRepository productRepository, IOrderRepository orderRepository,
            IPostRepository postRepository, BlogDbContext blogDbContext)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _postRepository = postRepository;
            _blogDbContext = _blogDbContext;
        }


        public async void SaveChanges()
        {
            _blogDbContext.SaveChanges();
        }

        public void Dispose()
        {
            _blogDbContext.Dispose();
        }
    }
}