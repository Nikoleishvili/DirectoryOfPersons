using DirectoryOfPersons.Application.Features.CommandHandlers.System;
using DirectoryOfPersons.Application.Filters;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DirectoryOfPersons.Application
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddMvc(o => o.Filters.Add<GlobalValidationFilter>())
                .AddFluentValidation(Configuration => Configuration.RegisterValidatorsFromAssemblyContaining<GlobalValidationFilter>());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
