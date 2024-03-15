using DataAccess.Blog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Blog.IServices
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProducts(string? product_id);
        
    }
}