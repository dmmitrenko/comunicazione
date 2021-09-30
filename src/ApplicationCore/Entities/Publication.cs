using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Publication
    {
        public int Id { get; set; }
        public User Author { get; set; }
        public DateTime DatePosted { get; set; }
        public string Content { get; set; }

        // Navigation prop
        public int AuthorId => this.Author.Id;
        public List<Comment> Commentaries { get; set; }

    }
}
