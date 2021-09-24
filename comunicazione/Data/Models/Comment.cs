using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace comunicazione.Data.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime DateAdded { get; set; }

        // Navigation Properties
        public int UserId { get; set; }
        public User User { get; set; }
        public int PublicatioId { get; set; }
        public Publication PublicationId { get; set; }

    }
}
