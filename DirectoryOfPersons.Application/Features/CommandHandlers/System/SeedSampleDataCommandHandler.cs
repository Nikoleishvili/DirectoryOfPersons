using DirectoryOfPersons.Application.Features.Commands.System;
using DirectoryOfPersons.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DirectoryOfPersons.Application.Features.CommandHandlers.System
{
    public class SeedSampleDataCommandHandler : IRequestHandler<SeedSampleDataCommand>
    {
        private readonly ISampleDataSeeder _seeder;
        public SeedSampleDataCommandHandler(ISampleDataSeeder seeder)
        {
            _seeder = seeder;
        }

        public async Task<Unit> Handle(SeedSampleDataCommand request, CancellationToken cancellationToken)
        {
            await _seeder.SeedAllAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
