using AutoMapper;
using Comunicazione.Core.Entities;
using Comunicazione.Core.Repositories;
using Comunicazione.Infrastructure.DTO;
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
   
        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult GetPopularUsers([FromQuery]int count)
        {
            var popularUsers = _unitOfWork.Users.GetPopularUsers(count);
            return Ok(popularUsers);
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
