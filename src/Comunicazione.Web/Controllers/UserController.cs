using AutoMapper;
using Comunicazione.Core.Entities;
using Comunicazione.Core.Repositories;
using Comunicazione.Core.Services;
using Comunicazione.Core.Views;
using Comunicazione.Infrastructure.Services;
using Comunicazione.Infrastructure.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comunicazione.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        
        private UserValidator _validator;

        public UserController(IUserService userService)
        {
            _userService = userService;
            _validator = new UserValidator();
        }

        [HttpGet("[action]/{count}")]
        public async Task<IActionResult> GetPopularUsers(int count)
        {
            var users = await _userService.GetPopularUsers(count);
            return Ok(users);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound($"User with id: {id} doesn't exist in the database");
            }
            return Ok(user);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddRange([FromBody] IEnumerable<UserViewModelForCreation> users)
        {
            foreach(var item in users)
            {
                var result = _validator.Validate(item);
                if (!result.IsValid)
                {
                    return BadRequest(result.Errors);
                }
            }
            await _userService.AddRange(users);
            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddUser([FromBody] UserViewModelForCreation model)
        {
            var result = _validator.Validate(model);
            
            if (result.IsValid)
            {
                await _userService.AddUser(model);
                return Ok();
            }
            
            return BadRequest(result.Errors);
        }

        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> UpdateInformation(int id, [FromBody] UserViewModelForCreation information)
        {
            var result = _validator.Validate(information);
            if (result.IsValid)
            {
                await _userService.UpdateInformation(id, information);
                return Ok();
            }
            return BadRequest(result.Errors);
        }

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUser(id);
            return Ok();
        }
    }
}
