using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicazione.Core.Views.Adrresses
{
    public class AddressViewModelForCreation
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int UserId { get; set; }
        public DateTime DateCreated { get {return DateTime.Now; } }
        public DateTime DateUpdated { get { return DateTime.Now; } }
    }
}
