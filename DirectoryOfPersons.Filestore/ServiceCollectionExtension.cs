using DirectoryOfPersons.Application.Interfaces;
using DirectoryOfPersons.Filestore.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DirectoryOfPersons.Filestore
{
    public static class ServiceCollectionExtension
    {
        public static void AddFilestore(this IServiceCollection services)
        {
            services.AddTransient<IFileService, FileService>();
        }
    }
}
