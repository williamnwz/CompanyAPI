using Company.Domain.Entities;
using Company.Infra.Maps;
using Microsoft.EntityFrameworkCore;

namespace Company.Infra
{
    public class DatabaseContext : DbContext
    {
        private readonly DatabaseSettings databaseSettings;

        public DatabaseContext(DbContextOptions opt, DatabaseSettings databaseSettings)
              : base(opt)
        {
            this.databaseSettings = databaseSettings;
        }

        public DbSet<CompanyRecord> CompanyRecords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(databaseSettings.ConnectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyRecordMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
