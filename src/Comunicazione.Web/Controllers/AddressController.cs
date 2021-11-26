using AutoMapper;
using Comunicazione.Core.Entities;
using Comunicazione.Core.Repositories;
using Comunicazione.Core.Services;
using Comunicazione.Core.Views.Adrresses;
using Comunicazione.Infrastructure.Validators;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comunicazione.Web.Controllers
{
    [Route("api/[controller]")]
    public class AddressController : Controller
    {
        private IAddressService _addressService;
        
        private AddressValidator _validator; 

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
            _validator = new AddressValidator();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddAddress([FromBody]AddressViewModelForCreation address)
        {
            var result = _validator.Validate(address);
            if (!result.IsValid)
                return BadRequest(result.Errors);

            await _addressService.AddAddress(address);
            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddRange([FromBody] IEnumerable<AddressViewModelForCreation> addresses)
        {
            await _addressService.AddRange(addresses);
            return Ok();
        }

        [HttpGet("[action]/{userId}")]
        public async Task<IActionResult> GetAddressByUserId(int userId)
        {
            var address = await _addressService.GetAddress(userId);
            return Ok(address);
        }

        [HttpPut("[action]/{userId}")]
        public async Task<IActionResult> UpdateAddress(int userId, AddressViewModelForCreation address)
        {
            var result = _validator.Validate(address);
            if (!result.IsValid)
                return BadRequest(result.Errors);

            await _addressService.UpdateAddress(userId, address);
            return Ok();
        }

        [HttpDelete("[action]/{userId}")]
        public async Task<IActionResult> DeleteAddress(int userId)
        {
            await _addressService.DeleteAddress(userId);
            return Ok();
        }
    }
}
