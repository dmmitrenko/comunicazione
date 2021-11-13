using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicazione.Core.Views
{
    public class CommentViewModelForCreation
    {
        public string Content { get; set; }
        public int UserId { get; set; }
        public int? ParentCommentId { get; set; }
        public int PostId { get; set; }

        public DateTime DateUpdated { get { return DateTime.Now; } }
        public DateTime DateCreated { get { return DateTime.Now; } }
    }
}
