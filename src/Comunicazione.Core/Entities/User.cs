﻿using System;
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
            DateUpdated = DateTime.Now;
            Password = "Ytrwq9I";
        }
        public int Id { get;  set; }
        public string Email { get;  set; }
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public string Password { get;  set; }
        public string Status { get;  set; }
        public string Role { get;  set; }
        public DateTime DateCreated { get;  set; }
        public DateTime DateUpdated { get;  set; }

        //Navigation prop
        public IEnumerable<Post> Posts { get;  set; }
    }
}
