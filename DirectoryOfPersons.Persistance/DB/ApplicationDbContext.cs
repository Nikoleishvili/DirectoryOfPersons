using DirectoryOfPersons.Application.Interfaces;
using DirectoryOfPersons.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryOfPersons.Persistance.DB
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Gender> Gender { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<PhoneNumber> PhoneNumber { get; set; }
        public DbSet<PhoneNumberType> PhoneNumberType { get; set; }
        public DbSet<RelationshipType> RelationshipType { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<PersonRelationship> PersonRelationship { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public async Task<int> SaveChangesAsync()
        {
            return await SaveChangesAsync();
        }
    }
}
