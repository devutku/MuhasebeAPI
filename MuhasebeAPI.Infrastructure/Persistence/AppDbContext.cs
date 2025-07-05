using Microsoft.EntityFrameworkCore;
using MuhasebeAPI.Domain.Entities;

namespace MuhasebeAPI.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Company> Companies => Set<Company>();
        public DbSet<UserCompany> UserCompanies => Set<UserCompany>();
        public DbSet<Stock> Stocks => Set<Stock>();
        public DbSet<Account> Accounts => Set<Account>();
        public DbSet<Invoice> Invoices => Set<Invoice>();
        public DbSet<InvoiceItem> InvoiceItems => Set<InvoiceItem>();
        public DbSet<CashTransaction> CashTransactions => Set<CashTransaction>();
        public DbSet<Log> Logs => Set<Log>();
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // UserCompany many-to-many composite key
            modelBuilder.Entity<UserCompany>()
                .HasKey(uc => new { uc.UserId, uc.CompanyId });

            modelBuilder.Entity<UserCompany>()
                .HasOne(uc => uc.User)
                .WithMany(u => u.UserCompanies)
                .HasForeignKey(uc => uc.UserId);

            modelBuilder.Entity<UserCompany>()
                .HasOne(uc => uc.Company)
                .WithMany(c => c.UserCompanies)
                .HasForeignKey(uc => uc.CompanyId);

            // Relations and delete behavior can be configured as needed
            modelBuilder.Entity<Company>()
                .HasOne(c => c.Owner)
                .WithMany()
                .HasForeignKey(c => c.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CashTransaction>()
                .HasOne(ct => ct.LinkedInvoice)
                .WithMany(i => i.CashTransactions)
                .HasForeignKey(ct => ct.LinkedInvoiceId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
