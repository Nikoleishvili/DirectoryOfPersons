using DirectoryOfPersons.Application.Features.Commands.PersonRelationships;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirectoryOfPersons.Application.Validators.PersonRelationships
{
    public class CreatePersonRelationshipValidator : AbstractValidator<CreatePersonRelationshipCommand>
    {
        public CreatePersonRelationshipValidator()
        {
            RuleFor(o => o.RelatedForPersonId).NotNull().GreaterThan(0);
            RuleFor(o => o.RelatedPersonId).NotNull().GreaterThan(0);
            RuleFor(o => o.RelationshipTypeId).NotNull().GreaterThan(0);
        }
    }
}
