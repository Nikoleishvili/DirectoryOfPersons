using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DirectoryOfPersons.Application.Interfaces
{
    public interface ISampleDataSeeder
    {
        Task SeedAllAsync(CancellationToken cancellationToken);
    }
}
