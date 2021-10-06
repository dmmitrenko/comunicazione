using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicazione.Core.Entities
{
    public class User
    {
        public Guid Id { get;  set; }
        public string Email { get;  set; }
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public string Password { get;  set; }
        public string Status { get;  set; }
        public string Role { get;  set; }
        public DateTime DateCreated { get;  set; }
        public DateTime DateUpdated { get;  set; }
        public ICollection<Post> Posts { get;  set; }
    }
}
