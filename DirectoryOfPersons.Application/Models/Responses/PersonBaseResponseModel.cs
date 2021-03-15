using System;
using System.Collections.Generic;
using System.Text;

namespace DirectoryOfPersons.Application.Models.Responses
{
    public class PersonBaseResponseModel : PersonBase
    {
        public int Id { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string City { get; set; }
        public string ImagePath { get; set; }
        public List<PhoneNumberResponseModel> PhoneNumbers { get; set; }
    }
    public class PhoneNumberResponseModel
    {
        public string Type { get; set; }
        public string Number { get; set; }
    }
}
