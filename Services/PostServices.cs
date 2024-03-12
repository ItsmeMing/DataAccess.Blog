using DataAccess.Blog.Entities;
using DataAccess.Blog.EntityFramework;
using DataAccess.Blog.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Blog.Services
{
	public class PostServices: IPostServices
	{
		private BlogDbContext _context;

		public PostServices(BlogDbContext context)
		{
			_context = context;
		}

		public async Task<List<Post>> GetPosts(int? post_id, int? category_id)
		{
			var list = new List<Post>();
			try
			{
				if (post_id == null && category_id == null)		
				{
					list = _context.Posts.ToList();
				}
				else if (post_id != null && category_id == null)
				{
					list = _context.Posts.ToList().FindAll(post => post.post_id == post_id);
				}
				else if(post_id == null && category_id != null)
				{
					list = _context.Posts.ToList().FindAll(post => post.category_id == category_id);
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
