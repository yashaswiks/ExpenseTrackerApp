using Dapper;
using ExpenseTracker.BusinessLogic.Repository.IRepository;
using ExpenseTracker.BusinessLogic.Repository.IRepository.Model;
using Microsoft.Data.Sqlite;
using System.Data;

namespace ExpenseTracker.BusinessLogic.Repository;

public class CodeValueClassificationRepository : ICodeValueClassificationRepository
{
    private readonly IDatabaseOptions _databaseOptions;

    public CodeValueClassificationRepository(IDatabaseOptions databaseOptions)
    {
        _databaseOptions = databaseOptions;
    }

    public async Task<List<CodeValueClassifications>> GetAllAsync()
    {
        using IDbConnection _db = new SqliteConnection(_databaseOptions.ConnectionString);

        _db.Open();

        var sql = @"SELECT * FROM CodeValueClassifications;";

        var details = await _db.QueryAsync<CodeValueClassifications>(sql);

        return details?.ToList();
    }

    public async Task<int?> InsertAsync(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) return null;

        using IDbConnection _db = new SqliteConnection(_databaseOptions.ConnectionString);

        _db.Open();

        var param = new { Value = value };

        var sql = @"INSERT INTO CodeValueClassifications (Value)
                         VALUES (@Value);
                         SELECT last_insert_rowid();";

        var newId = await _db.ExecuteScalarAsync<int?>(sql, param);
        _db.Close();
        return newId;
    }
}