using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicazione.Core.Entities
{
    public class Post
    {
        public Post()
        {
            DateCreated = DateTime.Now;
            DateUpdated = DateTime.Now;
        }
        public int PostId { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get;  set; }
        public DateTime DateUpdated { get; set; }


        // Navigation prop
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
