using Dapper;
using ExpenseTracker.BusinessLogic.Repository.IRepository;
using Microsoft.Data.Sqlite;
using System.Data;

namespace ExpenseTracker.BusinessLogic.Repository;

public class TransactionsRepository : ITransactionsRepository
{
    private readonly IDatabaseOptions _databaseOptions;

    public TransactionsRepository(IDatabaseOptions databaseOptions)
    {
        _databaseOptions = databaseOptions;
    }

    public async Task<int?> InsertAsync(InsertTransactionsDto insertDto)
    {
        using IDbConnection _db = new SqliteConnection(_databaseOptions.ConnectionString);

        _db.Open();

        var param = new
        {
            insertDto.Amount,
            insertDto.CategoryId,
            insertDto.Date,
            insertDto.IsReversed,
            insertDto.MoneySourceId,
            insertDto.Notes,
            insertDto.TransactionTypeId
        };

        // generate insert sql
        var sql = @"INSERT INTO Transactions (Amount, CategoryId, Date,
                       IsReversed, MoneySourceId, Notes, TransactionTypeId)
                       VALUES (@Amount, @CategoryId, @Date,
                       @IsReversed, @MoneySourceId, @Notes, @TransactionTypeId);
                       SELECT last_insert_rowid();";

        var newId = await _db.ExecuteScalarAsync<int?>(sql, param);
        _db.Close();
        return newId;
    }
}