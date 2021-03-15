using DirectoryOfPersons.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirectoryOfPersons.Persistance.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(o => o.LastName).IsRequired().HasMaxLength(50);
            builder.Property(o => o.GenderId).IsRequired();
            builder.Property(o => o.IdentityNumber).IsRequired().HasMaxLength(11);
            builder.Property(o => o.DateOfBirth).IsRequired();
            builder.Property(o => o.CityId).IsRequired();
            builder.Property(o => o.DateCreated).IsRequired();

            builder.HasOne(o => o.Gender).WithMany().HasForeignKey(o => o.GenderId);
            builder.HasOne(o => o.City).WithMany().HasForeignKey(o => o.CityId);
        }
    }
}
