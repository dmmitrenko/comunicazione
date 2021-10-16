using Comunicazione.Core.Entities;
using Comunicazione.Infrastructure.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicazione.Infrastructure.Validators
{
    public class UserValidator : AbstractValidator<UserViewModel>
    {
        public UserValidator()
        {
           

            RuleFor(m => m.FirstName).NotEmpty().Matches(@"^[a-zA-Z]+$");
            RuleFor(m => m.LastName).NotEmpty().Matches(@"^[a-zA-Z]+$");
            RuleFor(m => m.Email).NotEmpty().WithMessage("Email address is required")
                .EmailAddress().WithMessage("A valid email is required");
            RuleFor(m => m.Role).Must(str => CorrectRoleCategory(str))
                .WithMessage("Such a role is not available");
            RuleFor(m => m.Status).MaximumLength(50)
                .WithMessage("Too long a status");
        }

        private bool CorrectRoleCategory(string role)
        {
            string path = "RoleCategories.txt";
            using(StreamReader sw = new StreamReader(path))
            {
                while(sw.Peek() > -1)
                {
                    if (role == sw.ReadLine())
                        return true;
                }
            }
            return false;
        }
    }
}
