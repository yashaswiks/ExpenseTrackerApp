namespace ExpenseTracker.BusinessLogic.Repository.IRepository;

public interface ITransactionsRepository
{
    Task<int?> InsertAsync(InsertTransactionsDto insertDto);
}

public record InsertTransactionsDto(
    double? Amount,
    int? CategoryId,
    DateTime? Date,
    int? IsReversed,
    int? MoneySourceId,
    string Notes,
    int? TransactionTypeId);