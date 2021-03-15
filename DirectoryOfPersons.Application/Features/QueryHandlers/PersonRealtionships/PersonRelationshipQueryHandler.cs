using DirectoryOfPersons.Application.Extensions;
using DirectoryOfPersons.Application.Features.Queries.PersonRelationships;
using DirectoryOfPersons.Application.Features.Queries.Persons;
using DirectoryOfPersons.Application.Interfaces;
using DirectoryOfPersons.Application.Models;
using DirectoryOfPersons.Application.Models.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DirectoryOfPersons.Application.Features.QueryHandlers.Persons
{
    public class PersonRelationshipQueryHandler : IRequestHandler<GetPersonRelationshipsQuery, PagedData<PersonRealtionshipResponseModel>>
    {
        private readonly IUnitOfWork _uow;

        public PersonRelationshipQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<PagedData<PersonRealtionshipResponseModel>> Handle(GetPersonRelationshipsQuery request, CancellationToken cancellationToken)
        {
            var data = await _uow.PersonRelationships.GetReportAsync(cancellationToken);
            var result = await data.GetPagedData(request.PageNumber, request.PageSize, cancellationToken);

            return result;
        }
    }
}
