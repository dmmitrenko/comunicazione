using Comunicazione.Core.Entities;
using Comunicazione.Infrastructure.DTO;
using Comunicazione.Infrastructure.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicazione.Infrastructure.Services
{
    public class UsersService
    {
        private AppDbContext _context;
        public UsersService(AppDbContext context)
        {
            _context = context;
        }

        public User GetUserPostsById(int id)
        {
            var _user = _context.Users.Where(n => n.Id == id)
                .Select(user => new User()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Status = user.Status,
                    Role = user.Role,
                    Posts = user.Posts
                }).FirstOrDefault();
            return _user;
        }
    }
}
