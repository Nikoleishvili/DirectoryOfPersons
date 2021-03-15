using DirectoryOfPersons.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DirectoryOfPersons.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPersonRepository Persons { get; }
        IPersonRelationshipRepository PersonRelationships { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
