using DirectoryOfPersons.Application.Extensions;
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
    public class PersonQueryHandler : IRequestHandler<GetPersonQuery, PersonResponseModel>,
                                      IRequestHandler<GetPersonsQuery, PagedData<PersonResponseModel>>
    {
        private readonly IUnitOfWork _uow;

        public PersonQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<PersonResponseModel> Handle(GetPersonQuery request, CancellationToken cancellationToken)
        {
            var data = await _uow.Persons.GetPersonAsync(request.Id, cancellationToken);

            return data;
        }
        public async Task<PagedData<PersonResponseModel>> Handle(GetPersonsQuery request, CancellationToken cancellationToken)
        {
            var data = await _uow.Persons.GetPersonsAsync(request.FastSearch, request.Details, cancellationToken);
            var result = await data.GetPagedData(request.PageNumber, request.PageSize, cancellationToken);

            return result;
        }
    }
}
