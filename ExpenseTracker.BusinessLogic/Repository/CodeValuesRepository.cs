using Dapper;
using ExpenseTracker.BusinessLogic.Repository.IRepository;
using ExpenseTracker.BusinessLogic.Repository.IRepository.Model;
using Microsoft.Data.Sqlite;
using System.Data;

namespace ExpenseTracker.BusinessLogic.Repository;

public class CodeValuesRepository : ICodeValuesRepository
{
    private readonly IDatabaseOptions _databaseOptions;

    public CodeValuesRepository(IDatabaseOptions databaseOptions)
    {
        _databaseOptions = databaseOptions;
    }

    public Task<List<CodeValues>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<int?> InsertAsync(InsertCodeValuesDto insertDto)
    {
        if (string.IsNullOrWhiteSpace(insertDto?.Value) || insertDto.CodeValueClassificationId is 0) return null;

        using IDbConnection _db = new SqliteConnection(_databaseOptions.ConnectionString);

        _db.Open();

        var param = new
        {
            insertDto.CodeValueClassificationId,
            insertDto.Value,
        };

        var sql = @"INSERT INTO CodeValues (CodeValueClassificationId, Value)
                         VALUES (@CodeValueClassificationId, @Value);
                         SELECT last_insert_rowid();";

        var newId = await _db.ExecuteScalarAsync<int?>(sql, param);
        _db.Close();
        return newId;
    }
}