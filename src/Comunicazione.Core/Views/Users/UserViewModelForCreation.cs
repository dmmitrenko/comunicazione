using Comunicazione.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicazione.Core.Views.Users
{
    public class UserViewModelForCreation
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public DateTime DateUpdated { get { return DateTime.Now; } }
    }

}
