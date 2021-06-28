using Company.Domain.Entities;
using Company.Domain.Exceptions;
using Company.Domain.Repositories;
using Company.Domain.Services.Interfaces;
using System.Threading.Tasks;

namespace Company.Domain.Services
{
    public class CreateCompanyService : ICreateCompanyService
    {
        private readonly ICompanyRecordRepository companyRecordRepository;
        public CreateCompanyService(ICompanyRecordRepository companyRecordRepository)
        {
            this.companyRecordRepository = companyRecordRepository;
        }
        public async Task Create(CompanyRecord companyRecord)
        {
            if (companyRecord.Isin.IsValid() == false)
                throw new DomainException("The first two characters of an ISIN must be letters / non numeric");

            bool companyAlreadyExist = await this.companyRecordRepository.AnyBy(companyRecord.Isin.Value);

            if (companyAlreadyExist)
                throw new DomainException("You are not allowed create two Companies with the same ISIN");

            companyAlreadyExist = await this.companyRecordRepository.AnyBy(companyRecord.Id);

            if (companyAlreadyExist)
                throw new DomainException($"You are not allowed create two Companies with the same {companyRecord.Id} ID ");

            await companyRecordRepository.Save(companyRecord);
        }
    }
}
