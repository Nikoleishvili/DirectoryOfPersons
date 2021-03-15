using DirectoryOfPersons.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirectoryOfPersons.Application.Features.Commands.Persons
{
    public class CreatePersonCommand : PersonBaseRequest, IRequest
    {
    }
}
