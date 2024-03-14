using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Blog.Entities
{
	public class CreatePost
	{
		public string title { get; set; }

		public string content { get; set; }

		public int category_id { get; set; }
	}
}
