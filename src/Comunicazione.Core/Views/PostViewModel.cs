using Comunicazione.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicazione.Core.Views
{
    public class PostViewModel
    {
        public int PostId { get; set; }
        public string Content { get; set; }
        public string DateUpdated { get; set; }
        public UserFullNameModel Author { get; set; }
        
    }
}
