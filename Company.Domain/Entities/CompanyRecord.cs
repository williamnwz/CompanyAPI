using Company.Domain.ValueObjects;
using System;

namespace Company.Domain.Entities
{
    public class CompanyRecord : Entity
    {
        protected CompanyRecord() { }
        public CompanyRecord(
            Guid id,
            string name,
            string stockTicker,
            string exchange,
            string isin,
            string urlWebSite)
        {
            this.Id = id;
            this.Name = name;
            this.StockTicker = stockTicker;
            this.Exchange = exchange;
            this.Isin = new IsinVO(isin);
            this.UrlWebSite = urlWebSite;
        }
        public virtual string Name { get; protected set; }
        public virtual string StockTicker { get; protected set; }
        public virtual string Exchange { get; protected set; }
        public virtual IsinVO Isin { get; protected set; }
        public virtual string UrlWebSite { get; protected set; }
    }
}
