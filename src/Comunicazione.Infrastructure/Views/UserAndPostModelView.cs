using Comunicazione.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicazione.Infrastructure.DTO
{
    public class UserAndPostModelView
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Dictionary<int, PostViewModel> UserPosts { get; set; }
    }
}
