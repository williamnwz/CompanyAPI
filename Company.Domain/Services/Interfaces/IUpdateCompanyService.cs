using Company.Domain.Entities;
using System.Threading.Tasks;

namespace Company.Domain.Services.Interfaces
{
    public interface IUpdateCompanyService
    {
        Task Update(CompanyRecord companyRecord);
    }
}
