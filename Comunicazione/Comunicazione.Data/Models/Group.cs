using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicazione.Data.Models
{
    class Group
    {
        public Group()
        {
            this.Members = new List<User>();
            this.Admins = new List<User>();
            this.Publications = new List<Publication>();
        }

        public int GroupId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public ICollection<User> Members { get; set; }
        public ICollection<User> Admins { get; set; }
        public ICollection<Publication> Publications { get; set; }
    }
}
