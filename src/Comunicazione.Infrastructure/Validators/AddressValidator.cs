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
            RuleFor(m => m.Country).NotEmpty().Matches(@"^[a-zA-Z]+$")
                .WithMessage("The name of a country cannot consist of numbers");
            RuleFor(m => m.City).Matches(@"^[a-zA-Z]+$")
                .WithMessage("The name of a city cannot consist of numbers");
            RuleFor(m => m.Street).Matches(@"^[a-zA-Z]+$")
                .WithMessage("A street name cannot consist of numbers");
        }
    }
}
