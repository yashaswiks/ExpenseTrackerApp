using ExpenseTracker.BusinessLogic.Repository.IRepository.Model;

namespace ExpenseTracker.BusinessLogic.Repository.IRepository;

public interface ICodeValueClassificationRepository
{
    Task<int?> InsertAsync(string value);

    Task<List<CodeValueClassifications>> GetAllAsync();
}