using ExpenseTracker.BusinessLogic.DbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ExpenseTracker.BusinessLogic.Data;

public class ApplicationDbContext : DbContext
{
    private readonly IConfiguration _config;

    public DbSet<CodeValueClassification> CodeValueClassifications { get; set; }
    public DbSet<CodeValue> CodeValues { get; set; }

    public ApplicationDbContext(IConfiguration config)
    {
        _config = config;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(_config.GetConnectionString("DefaultConnection"));
    }
}