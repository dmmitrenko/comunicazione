using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicazione.Core.Entities
{
    public class Address
    {
        public Guid Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get;  set; }
        public double Longitude { get;  set; }
        public double Latitude { get;  set; }
        public DateTime DateCreated { get;  set; }
        public DateTime DateUpdated { get;  set; }

    }
}
