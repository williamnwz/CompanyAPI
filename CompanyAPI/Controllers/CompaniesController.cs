using Company.Application.Dtos;
using Company.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace CompanyAPI.Controllers
{
    [ApiController]
    [Route("companies")]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyApplicationService companyApplicationService;

        public CompaniesController(ICompanyApplicationService companyApplicationService)
        {
            this.companyApplicationService = companyApplicationService;
        }

        [HttpPost]
        [Route("create")]
        public async Task Create(CompanyRecordDto companyRecordDto)
        {
            await companyApplicationService.Create(companyRecordDto);
        }

        [HttpPut]
        [Route("update")]
        public async Task Update(CompanyRecordDto companyRecordDto)
        {
            await companyApplicationService.Update(companyRecordDto);
        }

        [HttpDelete]
        [Route("Remove")]
        public async Task Remove(Guid id)
        {
            await companyApplicationService.Remove(id);
        }

        [HttpGet]
        [Route("by/id/{id}")]
        public async Task<CompanyRecordDto> GetById(Guid id)
        {
            return await  companyApplicationService.GetById(id);
        }

        [HttpGet]
        [Route("by/isin/{isin}")]
        public async Task<CompanyRecordDto> Save(string isin)
        {
            return await companyApplicationService.GetByIdIsin(isin);
        }

        [HttpGet]
        [Route("all")]
        public async Task<List<CompanyRecordDto>> All()
        {
            return await companyApplicationService.All();
        }
    }
}
