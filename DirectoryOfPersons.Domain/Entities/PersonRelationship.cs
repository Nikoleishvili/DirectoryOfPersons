using System;
using DirectoryOfPersons.Domain.Common;
using DirectoryOfPersons.Domain.Interfaces;

namespace DirectoryOfPersons.Domain.Entities
{
    public class PersonRelationship : BaseEntity<int>, IDeletable
    {
        public int RelatedForPersonId { get; set; }
        public int RelationshipTypeId { get; set; }
        public int RelatedPersonId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateDeleted { get; set; }

        public Person RelatedForPerson { get; set; }
        public Person RelatedPerson { get; set; }
        public RelationshipType RelationshipType { get; set; }
    }
}