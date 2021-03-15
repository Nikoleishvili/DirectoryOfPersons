using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirectoryOfPersons.Application.Features.Commands.PersonRelationships
{
    public class DeletePersonRelationshipCommand : IRequest
    {
        public int Id { get; set; }
    }
}
