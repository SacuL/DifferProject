using Differ.Application.Interfaces;
using Differ.Application.Services;
using Differ.Domain.Interfaces;
using Differ.Domain.Services;
using Differ.Infra.Data.Context;
using Differ.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Differ.Services.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            RegisterServices(services);
        }

        private static void RegisterServices(IServiceCollection services)
        {
            // Application
            services.AddScoped<IDiffAppService, DiffAppService>();

            // Infra - Data
            services.AddScoped<IDiffRepository, DiffRepository>();
            services.AddScoped<DifferContext>();

            // Domain - Services
            services.AddScoped<IDiffDomainService, DiffDomainService>();
        }
    }
}