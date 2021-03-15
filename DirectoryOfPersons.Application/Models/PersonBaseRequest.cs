using DirectoryOfPersons.Application.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirectoryOfPersons.Application.Models
{
    public class PersonBaseRequest : PersonBase
    {
        public int? GenderId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? CityId { get; set; }
        public List<TypeData<PhoneNumberTypeEnum>> PhoneNumbers { get; set; }
    }
}
