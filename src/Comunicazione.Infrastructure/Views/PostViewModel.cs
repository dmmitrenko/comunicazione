using Comunicazione.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicazione.Infrastructure.Views
{
    public class PostViewModel
    {
        public string Content { get; set; }
        public int UserId { get; set; }
    }

    public class PostAddModel
    {
        public string Content { get; set; }
    }
}
