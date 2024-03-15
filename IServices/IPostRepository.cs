using DataAccess.Blog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Blog.IServices
{
	public interface IPostRepository
	{
		Task<List<Post>> GetPosts(int? post_id, int? category_id);
		Task<ReturnData> CreatePost(CreatePost post);
		Task<ReturnData> UpdatePost(int post_id, CreatePost post);
		Task<ReturnData> DeletePost(int post_id);
	}
}
	