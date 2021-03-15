using DirectoryOfPersons.Application.Features.Commands.Persons;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DirectoryOfPersons.Application.Validators.Persons
{
    public class UpdatePersonValidator : AbstractValidator<UpdatePersonCommand>
    {
        public UpdatePersonValidator()
        {
            RuleFor(o => o.Id).NotNull().GreaterThan(0);
            RuleFor(o => o).SetValidator(new PersonBaseValidator());
        }
    }
}
