using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirectoryOfPersons.Application.Features.Commands.PersonRelationships
{
    public class CreatePersonRelationshipCommand : IRequest
    {
        public int RelatedForPersonId { get; set; }
        public int RelationshipTypeId { get; set; }
        public int RelatedPersonId { get; set; }
    }
}
