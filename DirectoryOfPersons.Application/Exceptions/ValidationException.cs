using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirectoryOfPersons.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException() : base("One or more validation failures have occurred.")
        {
            Errors = new List<string>();
        }
        public ValidationException(List<string> errors) : base("One or more validation failures have occurred.")
        {
            Errors = errors;
        }
        public List<string> Errors { get; }
        public ValidationException(IEnumerable<ValidationFailure> failures)
            : this()
        {
            foreach (var failure in failures)
            {
                Errors.Add(failure.ErrorMessage);
            }
        }

    }
}
