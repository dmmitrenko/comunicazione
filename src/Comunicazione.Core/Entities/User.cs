using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicazione.Core.Entities
{
    public class User
    {
        public User()
        {
            DateCreated = DateTime.Now; 
        }
        public int UserId { get;  set; }
        public string Email { get;  set; }
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public string Password { get;  set; }
        public string Status { get;  set; }
        public string Role { get;  set; }
        public DateTime DateCreated { get;  set; }
        public DateTime DateUpdated { get;  set; }

        // Navigation properties
        public IEnumerable<Follow> Follower { get; set; }
        public IEnumerable<Follow> Followee { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public Address Address { get; set; }
        public  IEnumerable<Post> Posts { get;  set; }
    }
}
