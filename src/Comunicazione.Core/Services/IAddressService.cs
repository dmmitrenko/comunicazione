using Comunicazione.Core.Entities;
using Comunicazione.Core.Views.Adrresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicazione.Core.Services
{
    public interface IAddressService
    {
        Task AddAddress(AddressViewModelForCreation address);
        Task UpdateAddress(int userId, AddressViewModelForCreation address);
        Task DeleteAddress(int userId);
        Task AddRange(IEnumerable<AddressViewModelForCreation> addresses);
        Task<AddressViewModel> GetAddress(int userId);

    }
}
