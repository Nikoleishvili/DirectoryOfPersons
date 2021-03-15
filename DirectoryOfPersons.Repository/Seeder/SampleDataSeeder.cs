using DirectoryOfPersons.Application.Enums;
using DirectoryOfPersons.Application.Interfaces;
using DirectoryOfPersons.Domain.Entities;
using DirectoryOfPersons.Persistance.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DirectoryOfPersons.Repository.Seeder
{
    public class SampleDataSeeder : ISampleDataSeeder
    {
        private readonly ApplicationDbContext _context;
        public SampleDataSeeder(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task SeedAllAsync(CancellationToken cancellationToken)
        {
            if (!_context.Gender.Any())
                await SeedGenderAsync(cancellationToken);
            if (!_context.City.Any())
                await SeedCityAsync(cancellationToken);
            if (!_context.PhoneNumberType.Any())
                await SeedPhoneNumberTypeAsync(cancellationToken);
            if (!_context.RelationshipType.Any())
                await SeedRelationshipTypeAsync(cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedRelationshipTypeAsync(CancellationToken cancellationToken)
        {
            var relationshipTypes = new [] {
                new RelationshipType{Id = (int)RelationshipTypeEnum.Colleague, Name= "კოლეგა" },
                new RelationshipType{Id = (int)RelationshipTypeEnum.Familiar, Name= "ნაცნობი" },
                new RelationshipType{Id = (int)RelationshipTypeEnum.Relative, Name= "ნათესავი" },
                new RelationshipType{Id = (int)RelationshipTypeEnum.Other, Name= "სხვა" }
            };
            await _context.RelationshipType.AddRangeAsync(relationshipTypes, cancellationToken);
        }

        private async Task SeedPhoneNumberTypeAsync(CancellationToken cancellationToken)
        {
            var phoneNumberTypes = new [] {
                new PhoneNumberType{Id = (int)PhoneNumberTypeEnum.Mobile, Name= "მობილური" },
                new PhoneNumberType{Id = (int)PhoneNumberTypeEnum.Office, Name= "ოფისი" },
                new PhoneNumberType{Id = (int)PhoneNumberTypeEnum.Home, Name= "სახლი" }
            };
            await _context.PhoneNumberType.AddRangeAsync(phoneNumberTypes, cancellationToken);
        }

        private async Task SeedCityAsync(CancellationToken cancellationToken)
        {
            var cities = new [] {
                new City{ Name= "თბილისი" },
                new City{ Name= "ქუთაისი" },
                new City{ Name= "ბათუმი" }
            };
            await _context.City.AddRangeAsync(cities, cancellationToken);
        }

        private async Task SeedGenderAsync(CancellationToken cancellationToken)
        {
            var genders = new [] {
                new Gender{Id = (int)GenderEnum.Female, Name= "ქალი" },
                new Gender{Id = (int)GenderEnum.Male, Name= "კაცი" }
            };
            await _context.Gender.AddRangeAsync(genders, cancellationToken);
        }
    }
}
