using AutoMapper;
using MediatR;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DirectoryOfPersons.Application.Features.Commands.PersonRelationships;
using DirectoryOfPersons.Application.Interfaces;
using DirectoryOfPersons.Domain.Entities;

namespace DirectoryOfPersonRelationships.Application.Features.CommandHandlers.PersonRelationships
{
    public class PersonRelationshipHandler : IRequestHandler<CreatePersonRelationshipCommand>,
                                 IRequestHandler<UpdatePersonRelationshipCommand>,
                                 IRequestHandler<DeletePersonRelationshipCommand>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public PersonRelationshipHandler(IUnitOfWork uow, IMapper mapper)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<Unit> Handle(CreatePersonRelationshipCommand request, CancellationToken cancellationToken)
        {
            var personRelationship = _mapper.Map<PersonRelationship>(request);
            personRelationship.DateCreated = DateTime.Now;
            await _uow.PersonRelationships.AddAsync(personRelationship);
            await _uow.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
        public async Task<Unit> Handle(UpdatePersonRelationshipCommand request, CancellationToken cancellationToken)
        {
            var query = await Task.Run(() => _uow.PersonRelationships.FindBy(x => x.Id == request.Id));
            var personRelationship = query.FirstOrDefault();
            _mapper.Map(request, personRelationship);
            await _uow.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
        public async Task<Unit> Handle(DeletePersonRelationshipCommand request, CancellationToken cancellationToken)
        {
            await _uow.PersonRelationships.DeleteAsync(request.Id);
            await _uow.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
