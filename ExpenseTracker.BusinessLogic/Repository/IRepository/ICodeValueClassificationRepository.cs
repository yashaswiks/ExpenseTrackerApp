using ExpenseTracker.BusinessLogic.Model;

namespace ExpenseTracker.BusinessLogic.Repository.IRepository;

public interface ICodeValueClassificationRepository
{
    Task<int?> InsertAsync(string value);

    Task<List<CodeValueClassifications>> GetAllAsync();
}