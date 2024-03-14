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
				else if (post_id == null && category_id != null)
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

		public async Task<ReturnData> CreatePost(CreatePost post)
		{
			var returnData = new ReturnData();
			try
			{
				if (post == null)
				{
					returnData.ReturnCode = -1;
					returnData.ReturnMsg = "Dữ liệu đầu vào không hợp lệ";
					return returnData;
				}
				if (post.category_id <= 0)
				{
					returnData.ReturnCode = -1;
					returnData.ReturnMsg = "Category không hợp lệ";
					return returnData;
				}
				else
				{
					var postEntity = new Post();

					postEntity.title = post.title;
					postEntity.content = post.content;
					postEntity.category_id = post.category_id;

					_context.Posts.Add(postEntity);
					_context.SaveChanges();
				}
				return returnData;
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		public async Task<ReturnData> UpdatePost(int post_id, CreatePost post)
		{
			var returnData = new ReturnData();
			try
			{
				if (post_id <= 0)
				{
					returnData.ReturnCode = -1;
					returnData.ReturnMsg = "Id post không hợp lệ";
					return returnData;
				}

				if (post == null)
				{
					returnData.ReturnCode = -1;
					returnData.ReturnMsg = "Dữ liệu đầu vào không hợp lệ";
					return returnData;
				}

				else
				{
					var selectedPost = _context.Posts.SingleOrDefault(b => b.post_id == post_id);

					if (selectedPost == null)
					{
						returnData.ReturnCode = -2;
						returnData.ReturnMsg = "Không tồn tại post cần xóa";
						return returnData;
					}

					selectedPost.title = post.title;
					selectedPost.content = post.content;
					selectedPost.category_id = post.category_id;

					_context.SaveChanges();
				}
				return returnData;
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		public async Task<ReturnData> DeletePost(int post_id)
		{
			var returnData = new ReturnData();
			try
			{
				// step 1 : Kiểm tra đầu vào hợp lệ 

				if (post_id <= 0)
				{
					returnData.ReturnCode = -1;
					returnData.ReturnMsg = "Dữ liệu đầu vào không hợp lệ";
					return returnData;
				}

				// step 2 : Kiểm tra dữ liệu tồn tại không

				var product = _context.Posts.Where(s => s.post_id == post_id).FirstOrDefault();

				if (product == null || product.post_id <= 0)
				{
					returnData.ReturnCode = -2;
					returnData.ReturnMsg = "Không tồn tại sản phẩm cần xóa";
					return returnData;
				}


				// step 3 : Xóa

				_context.Posts.Remove(product);

				var result = _context.SaveChanges();

				if (result < 0)
				{
					returnData.ReturnCode = -11;
					returnData.ReturnMsg = "Xóa sản phẩm thất bại";
					return returnData;
				}


				returnData.ReturnCode = 1;
				returnData.ReturnMsg = "Xóa sản phẩm thành công";
				return returnData;
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}
	}
}
