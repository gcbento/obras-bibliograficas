using Microsoft.Extensions.DependencyInjection;
using ObrasBibliograficas.Application.Interfaces;
using ObrasBibliograficas.Application.Services;
using ObrasBibliograficas.Domain.Interfaces;
using ObrasBibliograficas.Domain.Validations;
using ObrasBibliograficas.Domain.Validations.Interfaces;
using ObrasBibliograficas.Infra.Data.Context;
using ObrasBibliograficas.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ObrasBibliograficas.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IPessoaApplication, PessoaApplication>();
            services.AddScoped<IPessoaValidation, PessoaValidation>();
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddDbContext<ObrasBibliograficasContext>(ServiceLifetime.Transient);
        }
    }
}
