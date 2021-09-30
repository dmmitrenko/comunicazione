using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicazione.Data.Models
{
    class User
    {
        public User()
        {
            this.Publications = new List<Publication>();
            this.Friends = new List<User>();
            this.Groups = new List<Group>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Country { get; set; }
        public DateTime Birthday { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName => $"{this.Name} {this.Surname}";
        public Gender Gender { get; set; }
        public string Bio { get; set; }


        // Navigation properties
        public ICollection<Publication> Publications { get; set; }
        public ICollection<User> Friends { get; set; }
        public ICollection<Group> Groups { get; set; }
    }
    public enum Gender
    {
        male = 0,
        female = 1
    }
}
