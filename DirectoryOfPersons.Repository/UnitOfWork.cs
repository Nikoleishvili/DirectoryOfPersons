using DirectoryOfPersons.Application.Interfaces;
using DirectoryOfPersons.Application.Interfaces.Repositories;
using DirectoryOfPersons.Persistance.DB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DirectoryOfPersons.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IPersonRepository Persons { get; }
        public IPersonRelationshipRepository PersonRelationships { get; }

        public UnitOfWork(ApplicationDbContext context,
            IPersonRepository persons,
            IPersonRelationshipRepository personRelationships)
        {
            _context = context;
            Persons = persons;
            PersonRelationships = personRelationships;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
