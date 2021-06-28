using Company.Application.Dtos;
using Company.Application.Mappers;
using Company.Domain.Entities;
using Company.Domain.Repositories;
using Company.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Application.Services
{
    public class CompanyApplicationService : ICompanyApplicationService
    {
        private readonly ICreateCompanyService createCompanyService;
        private readonly IUpdateCompanyService updateCompanyService;
        private readonly ICompanyRecordRepository companyRecordRepository;
        private readonly IMapper<CompanyRecord, CompanyRecordDto> mapperToDomain;
        private readonly IMapper<CompanyRecordDto, CompanyRecord> mapperToDto;

        public CompanyApplicationService(
            ICreateCompanyService createCompanyService,
            IUpdateCompanyService updateCompanyService,
            ICompanyRecordRepository companyRecordRepository,
            IMapper<CompanyRecord, CompanyRecordDto> mapperToDomain,
            IMapper<CompanyRecordDto, CompanyRecord> mapperToDto)
        {
            this.createCompanyService = createCompanyService;
            this.updateCompanyService = updateCompanyService;
            this.mapperToDomain = mapperToDomain;
            this.mapperToDto = mapperToDto;
            this.companyRecordRepository = companyRecordRepository;
        }

        public async Task<List<CompanyRecordDto>> All()
        {
            List<CompanyRecord> companyRecords = await companyRecordRepository.All();

            return companyRecords
                .Select(companyRecord => mapperToDto.Convert(companyRecord))
                .ToList();
        }

        public async Task Create(CompanyRecordDto companyRecordDto)
        {
            CompanyRecord companyRecord = mapperToDomain.Convert(companyRecordDto);

            await createCompanyService.Create(companyRecord);
        }

        public async Task<CompanyRecordDto> GetById(Guid id)
        {
            CompanyRecord companyRecord = await companyRecordRepository.GetById(id);

            return mapperToDto.Convert(companyRecord);
        }

        public async Task<CompanyRecordDto> GetByIdIsin(string isni)
        {
            CompanyRecord companyRecord = await companyRecordRepository.GetByIdIsin(isni);

            return mapperToDto.Convert(companyRecord);
        }

        public async Task Remove(Guid id)
        {
            CompanyRecord companyRecord = await companyRecordRepository.GetById(id);

            if (companyRecord != null)
                await companyRecordRepository.Delete(companyRecord);
        }

 
        public async Task Update(CompanyRecordDto companyRecordDto)
        {
            CompanyRecord companyRecord = mapperToDomain.Convert(companyRecordDto);

            await updateCompanyService.Update(companyRecord);
        }
    }
}
