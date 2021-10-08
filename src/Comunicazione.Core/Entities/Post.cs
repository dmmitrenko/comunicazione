using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicazione.Core.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get;  set; }
        public DateTime DateUpdated { get; set; }
        public User User { get; set; }

        // Navigation prop
        public int UserId => this.User.Id;
        public List<Comment> Comments { get; set; }
    }
}
