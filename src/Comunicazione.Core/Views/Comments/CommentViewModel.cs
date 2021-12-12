using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comunicazione.Core.Views.Users;

namespace Comunicazione.Core.Views.Comments
{
    public class CommentViewModel
    {
        public string Content { get; set; }
        public int PostId { get; set; }
        public UserFullNameModel Author { get; set; }
    }
}
