using Microsoft.Extensions.DependencyInjection;
using ObrasBibliograficas.Application.AutoMapper;
using System;
using AutoMapper;

namespace ObrasBibliograficas.API.Configs
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfig(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(DomainToModelMapping), typeof(ModelToDomainMapping));
        }
    }
}
