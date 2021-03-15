using DirectoryOfPersons.Application.Features.Commands.Persons;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DirectoryOfPersons.Application.Validators.Persons
{
    public class UploadPhotoValidator : AbstractValidator<UploadPhotoCommand>
    {
        public UploadPhotoValidator()
        {
            RuleFor(o => o.PersonId).NotNull().GreaterThan(0);
            RuleFor(o => o.File).NotNull().Must(i => i.ContentType.Equals("image/jpeg") || i.ContentType.Equals("image/jpg") || i.ContentType.Equals("image/png"));
        }
    }
}
