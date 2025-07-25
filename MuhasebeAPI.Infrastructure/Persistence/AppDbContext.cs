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
        public DbSet<AccountCategory> AccountCategories => Set<AccountCategory>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Supplier> Suppliers => Set<Supplier>();
        public DbSet<BankAccount> BankAccounts => Set<BankAccount>();
        public DbSet<Document> Documents { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Singular table names
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Company>().ToTable("Company");
            modelBuilder.Entity<UserCompany>().ToTable("UserCompany");
            modelBuilder.Entity<Stock>().ToTable("Stock");
            modelBuilder.Entity<Account>().ToTable("Account");
            modelBuilder.Entity<Invoice>().ToTable("Invoice");
            modelBuilder.Entity<InvoiceItem>().ToTable("InvoiceItem");
            modelBuilder.Entity<CashTransaction>().ToTable("CashTransaction");
            modelBuilder.Entity<Log>().ToTable("Log");
            modelBuilder.Entity<AccountCategory>().ToTable("AccountCategory");
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Supplier>().ToTable("Supplier");
            modelBuilder.Entity<BankAccount>().ToTable("BankAccount");

            modelBuilder.Entity<AccountCategory>().HasData(
                new AccountCategory { Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), Name = "Satıcılar" },
                new AccountCategory { Id = Guid.Parse("22222222-2222-2222-2222-222222222222"), Name = "Alıcılar" },
                new AccountCategory { Id = Guid.Parse("33333333-3333-3333-3333-333333333333"), Name = "Banka Hesapları" },
                new AccountCategory { Id = Guid.Parse("44444444-4444-4444-4444-444444444444"), Name = "Ödenecek Vergiler" },
                new AccountCategory { Id = Guid.Parse("55555555-5555-5555-5555-555555555555"), Name = "Peşin Ödemeler" },
                new AccountCategory { Id = Guid.Parse("66666666-6666-6666-6666-666666666666"), Name = "Nakit (Kasa)" }
            );

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
                .HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CashTransaction>()
                .HasOne(ct => ct.LinkedInvoice)
                .WithMany(i => i.CashTransactions)
                .HasForeignKey(ct => ct.LinkedInvoiceId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Account>()
                .HasOne(a => a.AccountCategory)
                .WithMany(ac => ac.Accounts)
                .HasForeignKey(a => a.AccountCategoryId);

            modelBuilder.Entity<Account>()
                .HasOne(a => a.Customer)
                .WithMany(c => c.Accounts)
                .HasForeignKey(a => a.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Account>()
                .HasOne(a => a.Supplier)
                .WithMany(s => s.Accounts)
                .HasForeignKey(a => a.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Account>()
                .HasOne(a => a.BankAccount)
                .WithMany(b => b.Accounts)
                .HasForeignKey(a => a.BankAccountId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<User>()
                .Property(u => u.UserType)
                .HasConversion<string>();
        }
    }
}
