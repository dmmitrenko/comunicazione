using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace comunicazione.Data.Models
{
    public class Publication
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }

        // Navigation Properties
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
