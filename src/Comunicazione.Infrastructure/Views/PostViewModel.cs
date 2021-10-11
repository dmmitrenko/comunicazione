using Comunicazione.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicazione.Infrastructure.DTO
{
    public class PostViewModel
    {
        public string Content { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
