using Company.Domain.Entities;
using Company.Domain.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Infra.Repositories
{
    public class CompanyRecordRepository : Repository<CompanyRecord>, ICompanyRecordRepository
    {
        public CompanyRecordRepository(DatabaseContext context) : base(context) { }

        public async Task<bool> AnyBy(string isin)
        {
            return this.context.CompanyRecords.Any(entity => entity.Isin.Value == isin);
        }

        public async Task<bool> AnyBy(Guid id)
        {
            return this.context.CompanyRecords.Any(entity => entity.Id == id);
        }

        public async Task<CompanyRecord> GetByIdIsin(string isin)
        {
            return this.context.CompanyRecords.FirstOrDefault(entity => entity.Isin.Value == isin);
        }
    }
}
