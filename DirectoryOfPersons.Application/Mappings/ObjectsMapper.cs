using AutoMapper;
using DirectoryOfPersons.Application.Features.Commands.PersonRelationships;
using DirectoryOfPersons.Application.Features.Commands.Persons;
using DirectoryOfPersons.Application.Mappings.Converters;
using DirectoryOfPersons.Application.Models.Responses;
using DirectoryOfPersons.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirectoryOfPersons.Application.Mappings
{
    public class ObjectsMapper : Profile
    {
        public ObjectsMapper()
        {
            CreateMap<CreatePersonCommand, Person>().
                ForMember(x => x.City, opt => opt.Ignore()).
                ForMember(x => x.PhoneNumbers, opt => opt.Ignore()).
                ForMember(x => x.PersonRelationships, opt => opt.Ignore()).AfterMap<CreatePersonConverter>();
            CreateMap<UpdatePersonCommand, Person>().
                ForMember(x => x.City, opt => opt.Ignore()).
                ForMember(x => x.PhoneNumbers, opt => opt.Ignore()).
                ForMember(x => x.PersonRelationships, opt => opt.Ignore()).AfterMap<UpdatePersonConverter>();
            CreateMap<CreatePersonRelationshipCommand, PersonRelationship>().
                ForMember(x => x.RelatedForPerson, opt => opt.Ignore()).
                ForMember(x => x.RelatedPerson, opt => opt.Ignore()).
                ForMember(x => x.RelationshipType, opt => opt.Ignore());
            CreateMap<UpdatePersonRelationshipCommand, PersonRelationship>().
                ForMember(x => x.RelatedForPerson, opt => opt.Ignore()).
                ForMember(x => x.RelatedPerson, opt => opt.Ignore()).
                ForMember(x => x.RelationshipType, opt => opt.Ignore());
            CreateMap<Person, PersonBaseResponseModel>().AfterMap<PersonBaseResponseConverter>();
        }
    }
}
