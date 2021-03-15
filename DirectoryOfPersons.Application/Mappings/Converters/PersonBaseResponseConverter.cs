using AutoMapper;
using DirectoryOfPersons.Application.Models.Responses;
using DirectoryOfPersons.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DirectoryOfPersons.Application.Mappings.Converters
{
    public class PersonBaseResponseConverter : IMappingAction<Person, PersonBaseResponseModel>
    {
        public void Process(Person source, PersonBaseResponseModel destination, ResolutionContext context)
        {
            destination.Gender = source.Gender.Name;
            destination.City = source.City.Name;
            destination.PhoneNumbers = source.PhoneNumbers.Select(o => new PhoneNumberResponseModel
            {
                Type = o.Type.Name,
                Number = o.Number
            }).ToList();
        }
    }
}
