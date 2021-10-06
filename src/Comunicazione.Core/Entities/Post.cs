using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicazione.Core.Entities
{
    class Post
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get;  set; }
        public DateTime DateUpdated { get; set; }
        public Guid UserId { get;  set; }
        public User User { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
