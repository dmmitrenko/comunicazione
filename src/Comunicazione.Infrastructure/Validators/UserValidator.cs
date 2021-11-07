using Comunicazione.Core.Entities;
using Comunicazione.Core.Views;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicazione.Infrastructure.Validators
{
    public class UserValidator : AbstractValidator<UserViewModelForCreation>
    {
        public UserValidator()
        {
           

            RuleFor(m => m.FirstName).NotEmpty().Matches(@"^[a-zA-Z]+$");
            RuleFor(m => m.LastName).NotEmpty().Matches(@"^[a-zA-Z]+$");
            RuleFor(m => m.Email).NotEmpty().WithMessage("Email address is required")
                .EmailAddress().WithMessage("A valid email is required");
            RuleFor(m => m.Role).Must(str => CorrectRoleCategory(str))
                .WithMessage("Select from the list of available categories");
            RuleFor(m => m.Status).MaximumLength(50)
                .WithMessage("Too long a status");
            RuleFor(m => m.Password).NotEmpty().Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$")
                .WithMessage("Invalid format: " +
                " 8 and 15 characters long," +
                " at least one number," +
                " at least one uppercase letter," +
                " at least one lowercase letter," +
                " at least one special character");
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
