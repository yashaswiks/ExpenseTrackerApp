using ExpenseTracker.BusinessLogic.Repository.IRepository.Model;

namespace ExpenseTracker.BusinessLogic.Repository.IRepository;

public interface ICodeValuesRepository
{
    Task<int?> InsertAsync(InsertCodeValuesDto insertDto);

    Task<List<CodeValues>> GetAllAsync();
}

public record InsertCodeValuesDto(int CodeValueClassificationId, string Value);