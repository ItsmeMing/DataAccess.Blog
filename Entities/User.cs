using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Blog.Entities
{
    public class User
    {
        public int id { get; set; }

        [Required] [StringLength(50)] public string username { get; set; }

        [Required] [StringLength(100)] public string password { get; set; }


        public bool is_admin { get; set; }

        [Required] [StringLength(100)] public string refresh_token { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime refresh_token_expired_date { get; set; }
    }
}