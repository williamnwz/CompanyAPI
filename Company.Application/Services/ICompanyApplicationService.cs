using Company.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Company.Application.Services
{
    public interface ICompanyApplicationService
    {
        /// <summary>
        /// Create a Company record specifying the Name, Stock Ticker, Exchange, ISIN, and optionally a website URL. 
        /// You are not allowed create two Companies with the same ISIN. The first two characters of an ISIN must be letters / non numeric.
        /// Update an existing Company
        /// </summary>
        /// <param name="companyRecordDto"></param>
        /// <returns></returns>
        Task Create(CompanyRecordDto companyRecordDto);

        /// <summary>
        /// Retrieve an existing Company by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<CompanyRecordDto> GetById(Guid id);

        /// <summary>
        /// Retrieve a Company by ISIN
        /// </summary>
        /// <param name="isni"></param>
        /// <returns></returns>
        Task<CompanyRecordDto> GetByIdIsin(string isni);

        /// <summary>
        /// Retrieve a collection of all Companies
        /// </summary>
        /// <returns></returns>
        Task<List<CompanyRecordDto>> All();

        Task Remove(Guid id);

        Task Update(CompanyRecordDto companyRecordDto);
        

    }
}
