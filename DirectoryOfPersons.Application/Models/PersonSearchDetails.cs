using System;
using System.Collections.Generic;
using System.Text;

namespace DirectoryOfPersons.Application.Models
{

    public class PersonSearchDetails : PersonBase
    {
        public int? GenderId { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? CityId { get; set; }
        public string PhoneNumber { get; set; }
    }
}
