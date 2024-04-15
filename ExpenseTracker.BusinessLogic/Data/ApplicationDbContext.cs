using ExpenseTracker.BusinessLogic.DbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ExpenseTracker.BusinessLogic.Data;

public class ApplicationDbContext : DbContext
{
    private readonly IConfiguration _config;

    public DbSet<CodeValueClassification> CodeValueClassifications { get; set; }
    public DbSet<CodeValue> CodeValues { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    public ApplicationDbContext(IConfiguration config)
    {
        _config = config;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(_config.GetConnectionString("DefaultConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Transaction>()
            .HasOne(t => t.TransactionType)
            .WithMany(cv => cv.TransactionTypes)
            .HasForeignKey(t => t.TransactionTypeId)
            .IsRequired();

        modelBuilder.Entity<Transaction>()
            .HasOne(t => t.Category)
            .WithMany(cv => cv.Categories)
            .HasForeignKey(t => t.CategoryId)
            .IsRequired();

        modelBuilder.Entity<Transaction>()
            .HasOne(t => t.MoneySource)
            .WithMany(cv => cv.MoneySources)
            .HasForeignKey(t => t.MoneySourceId)
            .IsRequired();
    }
}