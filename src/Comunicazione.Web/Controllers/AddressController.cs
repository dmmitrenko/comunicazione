using AutoMapper;
using Comunicazione.Core.Entities;
using Comunicazione.Core.Repositories;
using Comunicazione.Core.Services;
using Comunicazione.Core.Views.Adrresses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comunicazione.Web.Controllers
{
    public class AddressController : Controller
    {
        private IAddressService _addressService;
        private readonly IMapper _mapper;
        public AddressController(IAddressService addressService, IMapper mapper)
        {
            _mapper = mapper;
            _addressService = addressService;

        }

        [HttpPost("[action]")]
        public IActionResult AddAddress([FromBody]AddressViewModelForCreation address)
        {
            var _address = _mapper.Map<Address>(address);
            _addressService.AddAddress(_address);
            return Ok();
        }

        [HttpPost("[action]")]
        public IActionResult AddRange([FromBody] IEnumerable<AddressViewModelForCreation> addresses)
        {
            var _addresses = _mapper.Map<IEnumerable<Address>>(addresses);
            _addressService.AddRange(_addresses);
            return Ok();
        }

        [HttpGet("[action]/{userId}")]
        public IActionResult GetAddressByUserId(int userId)
        {
            var address = _addressService.GetAddress(userId);
            var response = _mapper.Map<AddressViewModel>(address);
            return Ok(response);
        }

        [HttpDelete("[action]/{userId}")]
        public IActionResult DeleteAddress(int userId)
        {
            _addressService.DeleteAddress(userId);
            return Ok();
        }
    }
}
