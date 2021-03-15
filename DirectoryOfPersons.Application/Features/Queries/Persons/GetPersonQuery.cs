using DirectoryOfPersons.Application.Models;
using DirectoryOfPersons.Application.Models.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirectoryOfPersons.Application.Features.Queries.Persons
{
    public class GetPersonQuery : IRequest<PersonResponseModel>
    {
        public int Id { get; set; }
    }
}
