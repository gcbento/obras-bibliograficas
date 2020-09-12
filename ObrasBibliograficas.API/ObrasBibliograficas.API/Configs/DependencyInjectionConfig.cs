using Microsoft.Extensions.DependencyInjection;
using ObrasBibliograficas.Infra.CrossCutting.IoC;
using System;

namespace ObrasBibliograficas.API.Configs
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfig(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
