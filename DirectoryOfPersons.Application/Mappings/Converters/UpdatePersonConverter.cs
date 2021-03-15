using AutoMapper;
using DirectoryOfPersons.Application.Features.Commands.Persons;
using DirectoryOfPersons.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DirectoryOfPersons.Application.Mappings.Converters
{
    public class UpdatePersonConverter : IMappingAction<UpdatePersonCommand, Person>
    {
        public void Process(UpdatePersonCommand source, Person destination, ResolutionContext context)
        {
            DeleteOrUpdateSavedPhoneNumbers(source, destination);
            AddNewPhoneNumbers(source, destination);
        }

        private static void DeleteOrUpdateSavedPhoneNumbers(UpdatePersonCommand source, Person destination)
        {
            var numbersToDelete = new List<PhoneNumber>();
            foreach (var savedPhoneNumber in destination.PhoneNumbers)
            {
                var updatedPhoneNumber = source.PhoneNumbers.FirstOrDefault(o => o.Id == savedPhoneNumber.Id);
                if (string.IsNullOrEmpty(updatedPhoneNumber?.Value))
                {
                    numbersToDelete.Add(savedPhoneNumber);
                }
                else
                {
                    savedPhoneNumber.Number = updatedPhoneNumber.Value;
                }
            }
            if (numbersToDelete.Any())
            {
                numbersToDelete.ForEach(o => destination.PhoneNumbers.Remove(o));
            }
        }

        private static void AddNewPhoneNumbers(UpdatePersonCommand source, Person destination)
        {
            var newPhoneNumbers = source.PhoneNumbers
                .Where(o => !destination.PhoneNumbers.Any(i => i.Id == o.Id))
                .Select(o => new PhoneNumber
                {
                    TypeId = (int)o.Type,
                    Number = o.Value
                }).ToList();

            newPhoneNumbers.ForEach(o => destination.PhoneNumbers.Add(o));
        }
    }
}
