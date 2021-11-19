using Comunicazione.Core.Views.Adrresses;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicazione.Infrastructure.Validators
{
    public class AddressValidator : AbstractValidator<AddressViewModelForCreation>
    {
        public AddressValidator()
        {
            RuleFor(m => m.Country).NotEmpty().Matches(@"^[a-zA-Z]+$");
            RuleFor(m => m.City).Matches(@"^[a-zA-Z]+$");
            RuleFor(m => m.City).Matches(@"^[a-zA-Z]+$");
        }
    }
}
