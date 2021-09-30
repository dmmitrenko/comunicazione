using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicazione.Data.Models
{
    class Publication
    {
        public Publication()
        {
            this.Comments = new List<Comment>();
            this.TaggedFriends = new List<User>();
        }

        public int PublicationId { get; set; }
        public User Author { get; set; }
        public int AuthorId => this.Author.UserId;
        public DateTime DatePosted { get; set; }
        public string Content { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public ICollection<User> TaggedFriends { get; set; }
    }
}
