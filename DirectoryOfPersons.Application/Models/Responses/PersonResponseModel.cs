using System;
using System.Collections.Generic;
using System.Text;

namespace DirectoryOfPersons.Application.Models.Responses
{
    public class PersonResponseModel : PersonBaseResponseModel
    {
        public List<PersonBaseResponseModel> RelatedPersons { get; set; }
    }
}
