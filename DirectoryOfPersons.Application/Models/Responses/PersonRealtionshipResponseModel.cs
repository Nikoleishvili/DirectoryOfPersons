using System;
using System.Collections.Generic;
using System.Text;

namespace DirectoryOfPersons.Application.Models.Responses
{
    public class PersonRealtionshipResponseModel : PersonBase
    {
        public string RelationshipType { get; set; }
        public int RelatedPersonsQuantity { get; set; }
    }
}
