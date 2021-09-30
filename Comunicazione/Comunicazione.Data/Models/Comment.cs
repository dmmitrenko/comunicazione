using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicazione.Data.Models
{
    class Comment
    {
        public Comment()
        {
            this.TaggedFriends = new List<User>();
        }

        public int CommentId { get; set; }
        public User Author { get; set; }
        public int AuthorId => this.Author.UserId;
        public string Content { get; set; }
        public DateTime DatePosted { get; set; }

        public ICollection<User> TaggedFriends { get; set; }
    }
}
