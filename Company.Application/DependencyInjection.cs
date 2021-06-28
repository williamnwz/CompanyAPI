using Company.Application.Decorators;
using Company.Application.Dtos;
using Company.Application.Mappers;
using Company.Application.Services;
using Company.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Company.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
        {
            
            serviceCollection.AddTransient<IMapper<CompanyRecord, CompanyRecordDto>, CompanyRecordMapper>();
            serviceCollection.AddTransient<IMapper<CompanyRecordDto, CompanyRecord>, CompanyRecordMapper>();
            serviceCollection.AddScoped<ICompanyApplicationService, CompanyApplicationService>();

            serviceCollection.Decorate<ICompanyApplicationService, CompanyApplicationTransactionDecorator>();

            return serviceCollection;
        }
    }
}
