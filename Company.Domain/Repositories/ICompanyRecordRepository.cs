using Company.Domain.Entities;
using Company.Domain.ValueObjects;
using System;
using System.Threading.Tasks;

namespace Company.Domain.Repositories
{
    public interface  ICompanyRecordRepository : IRepository<CompanyRecord>
    {
        Task<bool> AnyBy(string isinVO);
        Task<bool> AnyBy(Guid id);
        Task<CompanyRecord> GetByIdIsin(string isin);

        
    }
}
