using AutoMapper;
using DirectoryOfPersons.Application.Features.Commands.Persons;
using DirectoryOfPersons.Application.Interfaces;
using DirectoryOfPersons.Domain.Entities;
using MediatR;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DirectoryOfPersons.Application.Features.CommandHandlers.Persons
{
    public class PersonHandler : IRequestHandler<CreatePersonCommand>,
                                 IRequestHandler<UpdatePersonCommand>,
                                 IRequestHandler<DeletePersonCommand>,
                                 IRequestHandler<UploadPhotoCommand>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly IFileService _fileService;

        public PersonHandler(IUnitOfWork uow, IMapper mapper, IFileService fileService)
        {
            _mapper = mapper;
            _uow = uow;
            _fileService = fileService;
        }

        public async Task<Unit> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = _mapper.Map<Person>(request);
            await _uow.Persons.AddAsync(person);
            await _uow.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
        public async Task<Unit> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var query = await Task.Run(() => _uow.Persons.FindBy(x => x.Id == request.Id).Include(o => o.PhoneNumbers));
            var person = query.FirstOrDefault();
            _mapper.Map(request, person);
            await _uow.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
        public async Task<Unit> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            await _uow.Persons.DeleteAsync(request.Id);
            await _uow.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
        public async Task<Unit> Handle(UploadPhotoCommand request, CancellationToken cancellationToken)
        {
            var query = await Task.Run(() => _uow.Persons.FindBy(x => x.Id == request.PersonId));
            var person = query.FirstOrDefault();
            string imagePath;
            if (string.IsNullOrEmpty(person.ImagePath))
            {
                imagePath = _fileService.Upload(request.File, person.Id.ToString());
            }
            else
            {
                _fileService.Delete(person.ImagePath);
                imagePath = _fileService.Upload(request.File, person.Id.ToString());
            }
            person.ImagePath = imagePath;
            await _uow.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
