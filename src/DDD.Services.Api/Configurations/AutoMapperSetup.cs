using System;
using DDD.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace DDD.Services.Api.Configurations
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            services.AddAutoMapper(AutoMapperConfig.RegisterMappings());
        }
    }
}
