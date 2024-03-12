using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Blog.Entities
{
	public class Post
	{
		[Key]
		public int post_id { get; set; }

		[Required]
		[StringLength(255)]
		public string title { get; set; }

		[Required]	
		public string content { get; set; }

		[Required]
		public DateTime created_at { get; set; }

		[ForeignKey("category_id")]
		public int category_id { get; set; }
	}
}
