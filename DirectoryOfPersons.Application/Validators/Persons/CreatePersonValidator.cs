using DirectoryOfPersons.Application.Features.Commands.Persons;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DirectoryOfPersons.Application.Validators.Persons
{
    public class CreatePersonValidator : AbstractValidator<CreatePersonCommand>
    {
        public CreatePersonValidator()
        {
            RuleFor(o => o).SetValidator(new PersonBaseValidator());
        }
    }
}
