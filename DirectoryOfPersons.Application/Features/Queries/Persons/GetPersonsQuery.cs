using DirectoryOfPersons.Application.Models;
using DirectoryOfPersons.Application.Models.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirectoryOfPersons.Application.Features.Queries.Persons
{
    public class GetPersonsQuery : IRequest<PagedData<PersonResponseModel>>
    {
        public string FastSearch { get; set; }
        public PersonSearchDetails Details { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
