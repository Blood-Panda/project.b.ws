using Microsoft.Extensions.DependencyInjection;
using project.b.service.Service;
using project.b.repository.Repository;
using project.b.repository.Repository.Impl;
using project.b.repository.Entity;
using project.b.service.Service.Impl;

namespace project.b.ws.Middleware
{
    public static class Ioc
    {
        public static IServiceCollection AddDependencyRepository(this IServiceCollection services)
        {
            services.AddTransient<IConfiguractionOracleConnection, ConfiguractionOracleConnection>();
            services.AddTransient<IProductoRepository, ProductoRepository>();
            services.AddTransient<ITipoRepository, TipoRepository>();
            services.AddTransient<IPaisRepository, PaisRepository>();
            return services;
        }

        public static IServiceCollection AddDependencyService(this IServiceCollection services)
        {
            services.AddTransient<IProductoService, ProductoService>();
            services.AddTransient<ITipoService, TipoService>();
            services.AddTransient<IPaisService, PaisService>();
            return services;
        }
    }
}
