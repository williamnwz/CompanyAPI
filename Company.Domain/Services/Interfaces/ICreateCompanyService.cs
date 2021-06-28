using Company.Domain.Entities;
using System.Threading.Tasks;

namespace Company.Domain.Services.Interfaces
{
    public interface ICreateCompanyService
    {
        Task Create(CompanyRecord companyRecord);
    }
}
