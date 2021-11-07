using Comunicazione.Core.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicazione.Core.Views
{
    public class UserAndPostModelView
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Dictionary<int, PostViewModel> UserPosts { get; set; }
    }
}
