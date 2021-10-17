using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicazione.Core.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        //Navigation prop
        public Post Post { get; set; }
        public int PostId { get; set; }

        public List<Comment> Replies { get; set; }
        public Comment ParentComment { get; set; }
        public int? ParentCommentId { get; set; }


    }
}
