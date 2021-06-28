using Company.Domain.Services;
using Company.Domain.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Company.Domain
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDomain(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICreateCompanyService, CreateCompanyService>();
            serviceCollection.AddScoped<IUpdateCompanyService, UpdateCompanyService>();

            return serviceCollection;
        }
    }
}
