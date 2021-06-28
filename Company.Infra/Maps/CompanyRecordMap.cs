using Company.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.Infra.Maps
{
    public class CompanyRecordMap : IEntityTypeConfiguration<CompanyRecord>
    {
        public void Configure(EntityTypeBuilder<CompanyRecord> builder)
        {
            builder
                .ToTable("COMPANY_RECORD");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("COMPANY_RECORD_ID")
                .ValueGeneratedOnAdd();

            builder
                .Property(x => x.Exchange)
                .HasColumnName("EXCHANGE");

            builder
                .Property(x => x.Name)
                .HasColumnName("NAME");

            builder
                .Property(x => x.UrlWebSite)
                .HasColumnName("URL_WEBSITE");

            builder
                .Property(x => x.StockTicker)
                .HasColumnName("STOCK_TICKER");


            builder.OwnsOne(x => x.Isin, isin =>
            {
                isin.Property(d => d.Value).HasColumnName("ISIN");
            });
        }
    }
}
