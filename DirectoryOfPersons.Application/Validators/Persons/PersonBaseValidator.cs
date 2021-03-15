using DirectoryOfPersons.Application.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DirectoryOfPersons.Application.Validators.Persons
{
    public class PersonBaseValidator : AbstractValidator<PersonBaseRequest>
    {
        public PersonBaseValidator()
        {
            RuleFor(o => o.FirstName).MinimumLength(2).MaximumLength(50).Matches(@"(^[a-zA-Z]+$)|(^[ა-ჰ]+$)");
            RuleFor(o => o.LastName).MinimumLength(2).MaximumLength(50).Matches(@"(^[a-zA-Z]+$)|(^[ა-ჰ]+$)");
            RuleFor(o => o.IdentityNumber).NotNull().NotEmpty().Length(11).Matches(@"^\d{11}$");
            RuleFor(o => o.DateOfBirth).NotNull().NotEmpty().Must(o => IsAdult(o));

            When(o => o.PhoneNumbers.Any(), () =>
            {
                RuleForEach(o => o.PhoneNumbers).ChildRules(phoneNumber =>
                {
                    phoneNumber.RuleFor(i => i.Value).MinimumLength(4).MaximumLength(50);
                });
            });
        }

        private static bool IsAdult(DateTime dateOfbirth)
        {
            var today = DateTime.Today;
            var age = today.Year - dateOfbirth.Year;
            if (dateOfbirth.Date > today.AddYears(-age))
                age--;

            return age > 17;
        }
    }
}
