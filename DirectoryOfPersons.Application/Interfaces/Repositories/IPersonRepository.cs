using DirectoryOfPersons.Application.Features.Queries.Persons;
using DirectoryOfPersons.Application.Models;
using DirectoryOfPersons.Application.Models.Responses;
using DirectoryOfPersons.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DirectoryOfPersons.Application.Interfaces.Repositories
{
    public interface IPersonRepository : IGenericRepository<Person>
    {
        Task<PersonResponseModel> GetPersonAsync(int id, CancellationToken cancellationToken);
        Task<IQueryable<PersonResponseModel>> GetPersonsAsync(string fastSearch, PersonSearchDetails details, CancellationToken cancellationToken);
    }
}
