using AutoMapper;
using DirectoryOfPersons.Application.Features.Queries.Persons;
using DirectoryOfPersons.Application.Interfaces.Repositories;
using DirectoryOfPersons.Application.Models;
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
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }

        public async Task<PersonResponseModel> GetPersonAsync(int id, CancellationToken cancellationToken)
        {
            var person = await FindBy(o => o.Id == id)
                .Include(o => o.City).Include(o => o.Gender).Include(o => o.PhoneNumbers).ThenInclude(o => o.Type)
                .FirstOrDefaultAsync();
            var relatedPersonsQuery = await Task.Run(() => _context.PersonRelationship
                .Where(o => o.RelatedForPersonId == id && o.DateDeleted == null));

            var result = new PersonResponseModel
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Gender = person.Gender.Name,
                IdentityNumber = person.IdentityNumber,
                DateOfBirth = person.DateOfBirth,
                City = person.City.Name,
                ImagePath = person.ImagePath,
                PhoneNumbers = person.PhoneNumbers.Select(o => new PhoneNumberResponseModel
                {
                    Type = o.Type.Name,
                    Number = o.Number
                }).ToList()
            };
            AddRelatedPersons(relatedPersonsQuery, result);

            return result;
        }

        public async Task<IQueryable<PersonResponseModel>> GetPersonsAsync(string fastSearch, PersonSearchDetails details, CancellationToken cancellationToken)
        {
            var filterInfo = GetFilterInfo(fastSearch, details);
            var query = await GetPersonsQuery(fastSearch, details, filterInfo);

            var result = query.Select(o => new PersonResponseModel
            {
                Id = o.Id,
                FirstName = o.FirstName,
                LastName = o.LastName,
                Gender = o.Gender.Name,
                IdentityNumber = o.IdentityNumber,
                DateOfBirth = o.DateOfBirth,
                City = o.City.Name,
                ImagePath = o.ImagePath,
                PhoneNumbers = o.PhoneNumbers.Select(p => new PhoneNumberResponseModel
                {
                    Type = p.Type.Name,
                    Number = p.Number
                }).ToList(),
                RelatedPersons = o.PersonRelationships.Where(o => o.DateDeleted == null)
                .Select(i => new PersonBaseResponseModel
                {
                    Id = i.RelatedPerson.Id,
                    FirstName = i.RelatedPerson.FirstName,
                    LastName = i.RelatedPerson.LastName,
                    Gender = i.RelatedPerson.Gender.Name,
                    IdentityNumber = i.RelatedPerson.IdentityNumber,
                    DateOfBirth = i.RelatedPerson.DateOfBirth,
                    City = i.RelatedPerson.City.Name,
                    ImagePath = i.RelatedPerson.ImagePath,
                    PhoneNumbers = i.RelatedPerson.PhoneNumbers.Select(p => new PhoneNumberResponseModel
                    {
                        Type = p.Type.Name,
                        Number = p.Number
                    }).ToList()
                }).ToList()
            });

            return result;
        }

        #region private
        private static void AddRelatedPersons(IQueryable<PersonRelationship> relatedPersonsQuery, PersonResponseModel result)
        {
            result.RelatedPersons = relatedPersonsQuery.Select(o => new PersonBaseResponseModel
            {
                Id = o.RelatedPerson.Id,
                FirstName = o.RelatedPerson.FirstName,
                LastName = o.RelatedPerson.LastName,
                Gender = o.RelatedPerson.Gender.Name,
                IdentityNumber = o.RelatedPerson.IdentityNumber,
                DateOfBirth = o.RelatedPerson.DateOfBirth,
                City = o.RelatedPerson.City.Name,
                ImagePath = o.RelatedPerson.ImagePath,
                PhoneNumbers = o.RelatedPerson.PhoneNumbers.Select(p => new PhoneNumberResponseModel
                {
                    Type = p.Type.Name,
                    Number = p.Number
                }).ToList()
            }).ToList();
        }

        private async Task<IQueryable<Person>> GetPersonsQuery(string fastSearch, PersonSearchDetails details, PersonFilterInfo filterInfo)
        {
            return await Task.Run(() => FindBy(o => o.DateDeleted == null &&
                ((filterInfo.IsDetailedSearch &&
                    (!filterInfo.FirstNameHasValue || o.FirstName.Contains(details.FirstName)) &&
                    (!filterInfo.LastNameHasValue || o.LastName.Contains(details.LastName)) &&
                    (!filterInfo.GenderHasValue || o.GenderId == details.GenderId) &&
                    (!filterInfo.IdentityNumberHasValue || o.IdentityNumber.Contains(details.IdentityNumber)) &&
                    (!filterInfo.DateOfBirthHasValue || o.DateOfBirth == details.DateOfBirth) &&
                    (!filterInfo.CityHasValue || o.CityId == details.CityId) &&
                    (!filterInfo.PhoneNumberHasValue || o.PhoneNumbers.Any(i => i.Number.Contains(details.PhoneNumber)))) ||
                (!filterInfo.IsDetailedSearch && (!filterInfo.FastSearchHasValue ||
                    o.FirstName.Contains(fastSearch) || o.LastName.Contains(fastSearch) || o.IdentityNumber.Contains(fastSearch))))));
        }

        private PersonFilterInfo GetFilterInfo(string fastSearch, PersonSearchDetails details)
        {
            var isDetailedSearch = details != null;
            var result = new PersonFilterInfo
            {
                IsDetailedSearch = isDetailedSearch,
                FastSearchHasValue = !isDetailedSearch && !string.IsNullOrEmpty(fastSearch),
                FirstNameHasValue = isDetailedSearch && !string.IsNullOrEmpty(details.FirstName),
                LastNameHasValue = isDetailedSearch && !string.IsNullOrEmpty(details.LastName),
                GenderHasValue = isDetailedSearch && details.GenderId.HasValue,
                IdentityNumberHasValue = isDetailedSearch && !string.IsNullOrEmpty(details.IdentityNumber),
                DateOfBirthHasValue = isDetailedSearch && details.DateOfBirth.HasValue,
                CityHasValue = isDetailedSearch && details.CityId.HasValue,
                PhoneNumberHasValue = isDetailedSearch && !string.IsNullOrEmpty(details.PhoneNumber)
            };
            return result;
        }
        #endregion
    }
}
