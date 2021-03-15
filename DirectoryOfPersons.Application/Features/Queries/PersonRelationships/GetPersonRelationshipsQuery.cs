using DirectoryOfPersons.Application.Models;
using DirectoryOfPersons.Application.Models.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirectoryOfPersons.Application.Features.Queries.PersonRelationships
{
    public class GetPersonRelationshipsQuery : IRequest<PagedData<PersonRealtionshipResponseModel>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
