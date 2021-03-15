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
    public interface IPersonRelationshipRepository : IGenericRepository<PersonRelationship>
    {
        Task<IQueryable<PersonRealtionshipResponseModel>> GetReportAsync(CancellationToken cancellationToken);
    }
}
