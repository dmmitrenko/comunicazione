using AutoMapper;
using Comunicazione.Core.Entities;
using Comunicazione.Core.Repositories;
using Comunicazione.Infrastructure.DTO;
using Comunicazione.Infrastructure.Validators;
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
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
   
        public UserController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("get-users")]
        public IActionResult GetPopularUsers([FromQuery]int count)
        {
            var popularUsers = _unitOfWork.Users.GetPopularUsers(count);
            return Ok(popularUsers);
        }
        
        [HttpGet("get-user-by-id")]
        public IActionResult GetUserById([FromQuery] int id)
        {
            var user = _unitOfWork.Users.GetById(id);
            var responce = _mapper.Map<UserViewModel>(user);
            return Ok(responce);
        }

        [HttpPost("add-user")]
        public IActionResult AddUser([FromBody]UserViewModel model)
        {
            var validator = new UserValidator();
            var result = validator.Validate(model);
            if (result.IsValid)
            {
                var user = new User()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Status = model.Status,
                    Role = model.Role
                };
                _unitOfWork.Users.Add(user);
                _unitOfWork.Complete();
                return Ok();
            }
            return BadRequest(result.Errors);
        }

        [HttpDelete("delete-user")]
        public IActionResult DeleteUser([FromQuery]int id)
        {
            _unitOfWork.Users.Remove(_unitOfWork.Users.GetById(id));
            _unitOfWork.Complete();
            return Ok();
        }

        [HttpPost]
        public IActionResult AddUserAndPost()
        {
            var user = new User
            {
                FirstName = "Alexander",
                LastName = "Pushkin",
                Email = "alexander@dm.com",
                Password = "IuO90ut1",
                Role = "Russian poet, playwright, and novelist",
                Status = "in the process of writing The Captain's Daughter",
                DateCreated = new DateTime(1818, 7, 20, 17, 54, 25),
                DateUpdated = new DateTime(1835, 2, 2, 23, 24, 38)

            };

            var post = new Post
            {
                Content = "my historical novel. coming soon.",
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
                User = user
            };
            _unitOfWork.Users.Add(user);
            _unitOfWork.Posts.Add(post);
            _unitOfWork.Complete();
            return Ok();
        }
 
    }
}
