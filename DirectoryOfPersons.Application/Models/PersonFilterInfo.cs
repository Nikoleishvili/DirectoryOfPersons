using System;
using System.Collections.Generic;
using System.Text;

namespace DirectoryOfPersons.Application.Models
{
    public class PersonFilterInfo
    {
        public bool IsDetailedSearch { get; set; }
        public bool FastSearchHasValue { get; set; }
        public bool FirstNameHasValue { get; set; }
        public bool LastNameHasValue { get; set; }
        public bool GenderHasValue { get; set; }
        public bool IdentityNumberHasValue { get; set; }
        public bool DateOfBirthHasValue { get; set; }
        public bool CityHasValue { get; set; }
        public bool PhoneNumberHasValue { get; set; }
    }
}
