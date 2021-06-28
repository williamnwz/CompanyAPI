using AutoFixture;
using Company.Application.Dtos;
using Company.Application.Mappers;
using Company.Domain.Entities;
using Company.Domain.Exceptions;
using Company.Domain.Repositories;
using Company.Domain.Services;
using NSubstitute;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Company.Test.Domain.Services
{
    public class CreateCompanyServiceTest
    {
        [SetUp]
        public void Setup() { }

        [Test]
        public async Task Create_ValidCompanyRecord()
        {

            // Arrange
            ICompanyRecordRepository companyRecordRepository = Substitute.For<ICompanyRecordRepository>();

            CreateCompanyService saveCompanyService = new CreateCompanyService(companyRecordRepository);

            CompanyRecordMapper companyRecordMapper = new CompanyRecordMapper();

            Fixture fix = new Fixture();

            string validIsinVO = "NL0000009165";

            CompanyRecordDto companyRecordDto = fix.Build<CompanyRecordDto>()
                .With(company => company.Isin, validIsinVO)
                .Create();

            companyRecordRepository
                .AnyBy(validIsinVO)
                .Returns(false);



            CompanyRecord companyRecord = companyRecordMapper.Convert(companyRecordDto);

            // Act
            await saveCompanyService.Create(companyRecord);

            // Assert
            await companyRecordRepository.Received(1).Save(companyRecord);
        }

        [Test]
        public async Task Create_InvalidCompanyRecord()
        {

            // Arrange
            ICompanyRecordRepository companyRecordRepository = Substitute.For<ICompanyRecordRepository>();

            CreateCompanyService saveCompanyService = new CreateCompanyService(companyRecordRepository);

            CompanyRecordMapper companyRecordMapper = new CompanyRecordMapper();

            Fixture fix = new Fixture();

            string validIsinVO = "asd123";

            CompanyRecordDto companyRecordDto = fix.Build<CompanyRecordDto>()
                .With(company => company.Isin, validIsinVO)
                .Create();

            companyRecordRepository
                .AnyBy(validIsinVO)
                .Returns(false);

            CompanyRecord companyRecord = companyRecordMapper.Convert(companyRecordDto);

            // Act - Assert
            Assert.ThrowsAsync<DomainException>(() => saveCompanyService.Create(companyRecord));
        }

        [Test]
        public async Task Create_AlreadyExistISIN()
        {

            // Arrange
            ICompanyRecordRepository companyRecordRepository = Substitute.For<ICompanyRecordRepository>();

            CreateCompanyService saveCompanyService = new CreateCompanyService(companyRecordRepository);

            CompanyRecordMapper companyRecordMapper = new CompanyRecordMapper();

            Fixture fix = new Fixture();

            string validIsinVO = "NL0000009165";

            CompanyRecordDto companyRecordDto = fix.Build<CompanyRecordDto>()
                .With(company => company.Isin, validIsinVO)
                .Create();

            companyRecordRepository
                .AnyBy(validIsinVO)
                .Returns(true); // Already exist ISIN

            CompanyRecord companyRecord = companyRecordMapper.Convert(companyRecordDto);

            // Act - Assert
            Assert.ThrowsAsync<DomainException>(() => saveCompanyService.Create(companyRecord));
        }
    }
}
