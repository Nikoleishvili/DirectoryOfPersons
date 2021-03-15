using DirectoryOfPersons.Application.Interfaces;
using DirectoryOfPersons.Application.Interfaces.Repositories;
using DirectoryOfPersons.Repository.Repositories;
using DirectoryOfPersons.Repository.Seeder;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DirectoryOfPersons.Repository
{
    public static class ServiceCollectionExtension
    {
        public static void AddRepositoryLayer(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPersonRelationshipRepository, PersonRelationshipRepository>();
            services.AddScoped<ISampleDataSeeder, SampleDataSeeder>();
        }
    }
}
