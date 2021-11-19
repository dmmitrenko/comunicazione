using Comunicazione.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicazione.Core.Services
{
    public interface IAddressService
    {
        void AddAddress(Address address);
        void UpdateAddress(int userId);
        void DeleteAddress(int userId);
        void AddRange(IEnumerable<Address> addresses);
        Address GetAddress(int userId);

    }
}
