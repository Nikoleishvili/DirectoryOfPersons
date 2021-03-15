using System;
using DirectoryOfPersons.Domain.Common;
using DirectoryOfPersons.Domain.Interfaces;

namespace DirectoryOfPersons.Domain.Entities
{
    public class PhoneNumber : BaseEntity<int>
    {
        public int PersonId { get; set; }
        public int TypeId { get; set; }
        public string Number { get; set; }

        public PhoneNumberType Type { get; set; }
        public Person Person { get; set; }
    }
}