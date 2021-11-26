using AutoMapper;
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
        private readonly IMapper _mapper;
        public AddressService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddAddress(AddressViewModelForCreation address)
        {
            var _address = _mapper.Map<Address>(address);
            await _unitOfWork.Addresses.Add(_address);
            await _unitOfWork.CompleteAsync();
        }

        public async Task AddRange(IEnumerable<AddressViewModelForCreation> addresses)
        {
            var _addresses = _mapper.Map<IEnumerable<Address>>(addresses);
            await _unitOfWork.Addresses.AddRange(_addresses);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAddress(int userId)
        {
            var entity = await _unitOfWork.Addresses.GetAddress(userId);
            _unitOfWork.Addresses.Remove(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<AddressViewModel> GetAddress(int userId)
        {
            var address = await _unitOfWork.Addresses.GetAddress(userId);
            return _mapper.Map<AddressViewModel>(address);
        }
        

        public async Task UpdateAddress(int userId, AddressViewModelForCreation address)
        {
            var entity = await _unitOfWork.Addresses.GetAddress(userId);
            _unitOfWork.Addresses.Update(entity, entity);
            await _unitOfWork.CompleteAsync();
        }
    }
}
