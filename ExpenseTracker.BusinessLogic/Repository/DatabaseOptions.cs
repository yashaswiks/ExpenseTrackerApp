using ExpenseTracker.BusinessLogic.Repository.IRepository;
using Microsoft.Extensions.Configuration;

namespace ExpenseTracker.BusinessLogic.Repository;

public class DatabaseOptions : IDatabaseOptions
{
    private readonly IConfiguration _config;

    public DatabaseOptions(IConfiguration configuration)
    {
        _config = configuration;
    }

    public string ConnectionString => _config.GetConnectionString("DefaultConnection");
}