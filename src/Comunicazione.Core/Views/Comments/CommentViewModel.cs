using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicazione.Core.Views
{
    public class CommentViewModel
    {
        public string Content { get; set; }
        public int PostId { get; set; }
        public UserFullNameModel Author { get; set; }
    }
}
