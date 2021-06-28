using Company.Application.Dtos;
using Company.Domain.Entities;

namespace Company.Application.Mappers
{
    public class CompanyRecordMapper : IMapper<CompanyRecord, CompanyRecordDto>, IMapper<CompanyRecordDto, CompanyRecord>
    {
        public CompanyRecord Convert(CompanyRecordDto source)
        {
            if (source == null)
                return null;

            return new CompanyRecord(
                source.Id, 
                source.Name, 
                source.StockTicker, 
                source.Exchange, 
                source.Isin, 
                source.UrlWebSite);
        }

        public CompanyRecordDto Convert(CompanyRecord source)
        {
            if (source == null)
                return null;

            return new CompanyRecordDto()
            {
                Exchange = source.Exchange,
                Id = source.Id,
                Isin = source.Isin != null ? source.Isin.Value : string.Empty,
                Name = source.Name,
                StockTicker = source.StockTicker,
                UrlWebSite = source.UrlWebSite
            };
        }
    }
}
