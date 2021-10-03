using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.ViewModels;

namespace ApplicationCore.Services
{
    public class UserService : IUserService
    {
        private AppDbContext _context;
        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public void AddUser(IUserViewModel user)
        {
            var _user = new User()
            {
                Name = user.Name,
                Surname = user.Surname,
                Username = user.Username,
                Password = user.Password,
                Country = user.Country,
                Bio = user.Bio,
                Email = user.Email
            };

            _context.Users.Add(_user);
            _context.SaveChanges();
        }
    }
}
