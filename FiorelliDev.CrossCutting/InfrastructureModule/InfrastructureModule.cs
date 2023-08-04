using FiorelliDev.Data.DatabaseContext;
using FiorelliDev.Data.Repositories;
using FiorelliDev.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FiorelliDev.CrossCutting.InfrastructureModule
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddRepositories();

            services.AddDbContext<ApplicationDbContext>(opts => opts
                    .UseMySql(configuration.GetConnectionString("DbConnection"),
                     ServerVersion.AutoDetect(configuration.GetConnectionString("DbConnection")),
                     b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            return services;
        }
        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IProdutoRepository), typeof(ProdutoRepository));
            services.AddScoped(typeof(ICategoriaReository), typeof(CategoriaRepository));



            return services;
        }
    }
}
