using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public User Author { get; set; }
        public Publication Publication { get; set; } 
        public string Content { get; set; }

        // Navigation prop
        public int AuthorId => this.Author.Id;
        public int PublicationId => this.Publication.Id;
    }
}
