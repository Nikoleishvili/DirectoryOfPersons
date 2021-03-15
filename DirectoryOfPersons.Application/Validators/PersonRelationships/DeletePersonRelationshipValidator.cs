using DirectoryOfPersons.Application.Features.Commands.PersonRelationships;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirectoryOfPersons.Application.Validators.PersonRelationships
{
    public class DeletePersonRelationshipValidator : AbstractValidator<DeletePersonRelationshipCommand>
    {
        public DeletePersonRelationshipValidator()
        {
            RuleFor(o => o.Id).NotNull().GreaterThan(0);
        }
    }
}
