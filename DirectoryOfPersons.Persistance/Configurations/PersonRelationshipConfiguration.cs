using DirectoryOfPersons.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirectoryOfPersons.Persistance.Configurations
{
    public class PersonRelationshipConfiguration : IEntityTypeConfiguration<PersonRelationship>
    {
        public void Configure(EntityTypeBuilder<PersonRelationship> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.RelatedForPersonId).IsRequired();
            builder.Property(o => o.RelatedPersonId).IsRequired();
            builder.Property(o => o.RelationshipTypeId).IsRequired();

            builder.HasOne(o => o.RelatedForPerson).WithMany(o => o.PersonRelationships)
                .HasForeignKey(o => o.RelatedForPersonId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(o => o.RelatedPerson).WithMany().HasForeignKey(o => o.RelatedPersonId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(o => o.RelationshipType).WithMany().HasForeignKey(o => o.RelationshipTypeId);
        }
    }
}
