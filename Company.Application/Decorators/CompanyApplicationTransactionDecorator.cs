using Company.Application.Dtos;
using Company.Application.Services;
using Company.Infra;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Company.Application.Decorators
{
    public class CompanyApplicationTransactionDecorator : ICompanyApplicationService
    {
        private readonly ICompanyApplicationService companyApplicationService;
        private readonly DatabaseContext databaseContext;
        public CompanyApplicationTransactionDecorator(
            ICompanyApplicationService companyApplicationService,
            DatabaseContext databaseContext)
        {
            this.companyApplicationService = companyApplicationService;
            this.databaseContext = databaseContext;
        }

        public async Task<List<CompanyRecordDto>> All()
        {
            return await this.companyApplicationService.All();
        }

        public async Task<CompanyRecordDto> GetById(Guid id)
        {
            return await this.companyApplicationService.GetById(id);
        }

        public async Task<CompanyRecordDto> GetByIdIsin(string isni)
        {
            return await this.companyApplicationService.GetByIdIsin(isni);
        }

        public async Task Remove(Guid id)
        {
            using (IDbContextTransaction transaction = databaseContext.Database.BeginTransaction())
            {
                try
                {
                    await companyApplicationService.Remove(id);

                    await databaseContext.SaveChangesAsync();

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public async Task Create(CompanyRecordDto companyRecordDto)
        {
            using (IDbContextTransaction transaction = databaseContext.Database.BeginTransaction())
            {
                try
                {
                    await companyApplicationService.Create(companyRecordDto);

                    await databaseContext.SaveChangesAsync();

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public async Task Update(CompanyRecordDto companyRecordDto)
        {
            using (IDbContextTransaction transaction = databaseContext.Database.BeginTransaction())
            {
                try
                {
                    await companyApplicationService.Update(companyRecordDto);

                    await databaseContext.SaveChangesAsync();

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
