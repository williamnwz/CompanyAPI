using AutoFixture;
using Company.Application.Dtos;
using Company.Application.Mappers;
using Company.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace Company.Test.Domain.Mappers
{
    public class CompanyRecordMapperTest
    {

        [Test]
        public void Convert_ValidCompanyRecord()
        {
            CompanyRecordMapper companyRecordMapper = new CompanyRecordMapper();

            Fixture fix = new Fixture();

            CompanyRecordDto companyRecordDto = fix
                .Build<CompanyRecordDto>()
                .Create();

            CompanyRecord companyRecord = companyRecordMapper.Convert(companyRecordDto);

            companyRecord.Id.Should().Be(companyRecordDto.Id);
            companyRecord.Isin.Value.Should().Be(companyRecordDto.Isin);
            companyRecord.StockTicker.Should().Be(companyRecordDto.StockTicker);
            companyRecord.UrlWebSite.Should().Be(companyRecordDto.UrlWebSite);
            companyRecord.Exchange.Should().Be(companyRecordDto.Exchange);
        }
    }
}
