using DirectoryOfPersons.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirectoryOfPersons.Persistance.Configurations
{
    public class PhoneNumberConfiguration : IEntityTypeConfiguration<PhoneNumber>
    {
        public void Configure(EntityTypeBuilder<PhoneNumber> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Number).IsRequired().HasMaxLength(50);

            builder.HasOne(o => o.Type).WithMany().HasForeignKey(o => o.TypeId);
            builder.HasOne(o => o.Person).WithMany(o => o.PhoneNumbers).HasForeignKey(o => o.PersonId);
        }
    }
}
