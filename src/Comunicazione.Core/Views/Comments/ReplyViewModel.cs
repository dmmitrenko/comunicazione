using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicazione.Core.Views.Comments
{
    public class ReplyViewModel
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public int ParentCommentId { get; set; }
        public string Content { get; set; }
        public string DateUpdated { get; set; }
        //public UserFullNameModel Author { get; set; }
        //public IEnumerable<Comment> MyProperty { get; set; }
    }
}
