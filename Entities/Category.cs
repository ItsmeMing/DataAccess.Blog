using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Blog.Entities
{
	public class Category
	{
		[Key]
		public int category_id { get; set; }

		[Required]
		[StringLength(100)]
		public string name { get; set; }
	}
}
