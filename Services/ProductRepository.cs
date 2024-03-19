using DataAccess.Blog.Entities;
using DataAccess.Blog.EntityFramework;
using DataAccess.Blog.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Blog.Services
{
    public class ProductRepository: IProductRepository
    {
        private BlogDbContext _context;
        
        public ProductRepository(BlogDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProducts(string? product_id)
        {
            var list = new List<Product>();
            try
            {
                if (product_id == null)
                {
                    list = _context.Products.ToList();
                }
                else
                {
                    list = _context.Products.ToList().FindAll(product => product.id == int.Parse(product_id));
                }
            } 
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }
    }
}
