using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Country { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string FullName => $"{this.Name} {this.Surname}";
        public string Bio { get; set; }

        // Navigation prop
        public List<Publication> Publications { get; set; }

    }
    public enum Gender 
    { 
    male = 1,
    female =0
    }
}
