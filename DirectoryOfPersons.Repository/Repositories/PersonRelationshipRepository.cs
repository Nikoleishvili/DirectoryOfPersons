using DirectoryOfPersons.Application.Interfaces.Repositories;
using DirectoryOfPersons.Application.Models.Responses;
using DirectoryOfPersons.Domain.Entities;
using DirectoryOfPersons.Persistance.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DirectoryOfPersons.Repository.Repositories
{
    public class PersonRelationshipRepository : GenericRepository<PersonRelationship>, IPersonRelationshipRepository
    {
        public PersonRelationshipRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }

        public async Task<IQueryable<PersonRealtionshipResponseModel>> GetReportAsync(CancellationToken cancellationToken)
        {
            var query = await Task.Run(() =>
                _dbSet.Where(o => o.DateDeleted == null)
                .GroupBy(o => new
                {
                    o.RelatedForPersonId,
                    o.RelatedForPerson.FirstName,
                    o.RelatedForPerson.LastName,
                    o.RelatedForPerson.IdentityNumber,
                    RelationshipType = o.RelationshipType.Name,
                    o.RelationshipTypeId
                }));

            var result = query.Select(o => new PersonRealtionshipResponseModel
            {
                FirstName = o.Key.FirstName,
                LastName = o.Key.LastName,
                IdentityNumber = o.Key.IdentityNumber,
                RelationshipType = o.Key.RelationshipType,
                RelatedPersonsQuantity = o.Count()
            });

            return result;
        }
    }
}
