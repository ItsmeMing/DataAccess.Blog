using DataAccess.Blog.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Blog.EntityFramework
{
	public class BlogDbContext: DbContext
	{
		public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options) 
		{
		
		}

		// protected override void OnModelCreating(ModelBuilder modelBuilder)
		// {
		// 	base.OnModelCreating(modelBuilder);
		// }
		

		public virtual DbSet<Post> posts { get; set; }
		public virtual DbSet<Category> categories { get; set; }
		public virtual DbSet<Product> products { get; set; }
		public virtual DbSet<Order> orders { get; set; }
		public virtual DbSet<OrderDetail> order_details { get; set; }
	}
}
