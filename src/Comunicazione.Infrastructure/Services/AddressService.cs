using Comunicazione.Core.Entities;
using Comunicazione.Core.Repositories;
using Comunicazione.Core.Services;
using Comunicazione.Core.Views.Adrresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicazione.Infrastructure.Services
{
    public class AddressService : IAddressService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddressService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddAddress(Address address)
        {
            _unitOfWork.Addresses.Add(address);
            _unitOfWork.Complete();
        }

        public void AddRange(IEnumerable<Address> addresses)
        {
            _unitOfWork.Addresses.AddRange(addresses);
            _unitOfWork.Complete();
        }

        public void DeleteAddress(int userId)
        {
            var entity = GetAddress(userId);
            _unitOfWork.Addresses.Remove(entity);
            _unitOfWork.Complete();
        }

        public Address GetAddress(int userId) =>
            _unitOfWork.Addresses.GetAddress(userId);
        

        public void UpdateAddress(int userId, AddressViewModelForCreation address)
        {
            var entity = _unitOfWork.Addresses.GetAddress(userId);
            _unitOfWork.Addresses.Update(entity, entity);
            _unitOfWork.Complete();
        }
    }
}
