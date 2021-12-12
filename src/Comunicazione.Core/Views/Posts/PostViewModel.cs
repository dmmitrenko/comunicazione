using Comunicazione.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comunicazione.Core.Views.Users;

namespace Comunicazione.Core.Views.Posts
{
    public class PostViewModel
    {
        public int PostId { get; set; }
        public string Content { get; set; }
        public string DateUpdated { get; set; }
        public UserFullNameModel Author { get; set; }
        
    }
}
