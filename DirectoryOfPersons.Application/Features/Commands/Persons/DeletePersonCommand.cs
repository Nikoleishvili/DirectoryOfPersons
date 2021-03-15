using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirectoryOfPersons.Application.Features.Commands.Persons
{
    public class DeletePersonCommand : IRequest
    {
        public int Id { get; set; }
    }
}
