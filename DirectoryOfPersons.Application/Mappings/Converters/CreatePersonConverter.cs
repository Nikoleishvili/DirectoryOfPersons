using AutoMapper;
using DirectoryOfPersons.Application.Features.Commands.Persons;
using DirectoryOfPersons.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DirectoryOfPersons.Application.Mappings.Converters
{
    public class CreatePersonConverter : IMappingAction<CreatePersonCommand, Person>
    {
        public void Process(CreatePersonCommand source, Person destination, ResolutionContext context)
        {
            destination.DateCreated = DateTime.Now;
            destination.PhoneNumbers = source.PhoneNumbers.Select(o => new PhoneNumber
            {
                TypeId = (int)o.Type,
                Number = o.Value
            }).ToList();
        }
    }
}
