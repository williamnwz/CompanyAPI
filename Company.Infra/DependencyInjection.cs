using Company.Domain.Entities;
using Company.Domain.Repositories;
using Company.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Company.Infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfra(this IServiceCollection serviceCollection, DatabaseSettings databaseSettings) { 

            serviceCollection.AddScoped<IRepository<Entity>, Repository<Entity>>();
            serviceCollection.AddScoped<ICompanyRecordRepository, CompanyRecordRepository>();

            serviceCollection.AddDbContext<DatabaseContext>(options => options.UseSqlServer(databaseSettings.ConnectionString, opt =>
            {
                opt.MigrationsAssembly("Company.Infra");
            }));

    

            return serviceCollection;
        }
    }
}
