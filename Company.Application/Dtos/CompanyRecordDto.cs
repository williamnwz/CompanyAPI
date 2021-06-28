using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Application.Dtos
{
    public class CompanyRecordDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string StockTicker { get; set; }
        public string Exchange { get; set; }
        public string Isin { get; set; }
        public string UrlWebSite { get; set; }
    }
}
