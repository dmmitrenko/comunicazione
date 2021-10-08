using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicazione.Core.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get;  set; }
        public User User { get; set; }
        public DateTime DateCreated { get;  set; }
        public DateTime DateUpdated { get;  set; }

        // Navigation prop
        public int UserId => this.User.Id;

    }
}
