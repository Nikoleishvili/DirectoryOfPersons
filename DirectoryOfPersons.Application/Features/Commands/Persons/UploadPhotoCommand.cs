using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirectoryOfPersons.Application.Features.Commands.Persons
{
    public class UploadPhotoCommand : IRequest
    {
        public int PersonId { get; set; }
        public IFormFile File { get; set; }
    }
}
