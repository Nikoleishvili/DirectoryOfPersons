using DirectoryOfPersons.Domain.Common;
using DirectoryOfPersons.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirectoryOfPersons.Domain.Entities
{
    public class Person : BaseEntity<int>, IDeletable
    {
        public Person()
        {
            PhoneNumbers = new HashSet<PhoneNumber>();
            PersonRelationships = new HashSet<PersonRelationship>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GenderId { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int CityId { get; set; }
        public string ImagePath { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateDeleted { get; set; }

        public Gender Gender { get; set; }
        public City City { get; set; }
        public ICollection<PhoneNumber> PhoneNumbers { get; set; }
        public ICollection<PersonRelationship> PersonRelationships { get; set; }
    }
}
