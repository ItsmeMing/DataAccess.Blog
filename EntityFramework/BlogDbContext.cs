using DataAccess.Blog.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Blog.EntityFramework
{
	public class BlogDbContext: DbContext
	{
		public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options) 
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}

		public virtual DbSet<Post> Posts { get; set; }
		public virtual DbSet<Category> Categories { get; set; }
	}
}
