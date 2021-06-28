using Company.Domain.Entities;
using Company.Domain.Exceptions;
using Company.Domain.Repositories;
using Company.Domain.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Company.Domain.Services
{
    public class UpdateCompanyService : IUpdateCompanyService
    {
        private readonly ICompanyRecordRepository companyRecordRepository;
        public UpdateCompanyService(ICompanyRecordRepository companyRecordRepository)
        {
            this.companyRecordRepository = companyRecordRepository;
        }

        public async Task Update(CompanyRecord companyRecord)
        {
            if (companyRecord.Isin.IsValid() == false)
                throw new DomainException("The first two characters of an ISIN must be letters / non numeric");

            bool alreadyExist = await companyRecordRepository.AnyBy(companyRecord.Id);

            if (alreadyExist == false)
                throw new DomainException($"The {companyRecord.Id} CompanyRecord ID is invalid");

            await companyRecordRepository.Save(companyRecord);
        }
    }
}
