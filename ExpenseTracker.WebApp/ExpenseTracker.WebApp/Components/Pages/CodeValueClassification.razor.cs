using ExpenseTracker.BusinessLogic.Repository.IRepository;
using ExpenseTracker.BusinessLogic.Repository.IRepository.Model;
using Microsoft.AspNetCore.Components;

namespace ExpenseTracker.WebApp.Components.Pages;

public partial class CodeValueClassification
{
    [Inject]
    private ICodeValueClassificationRepository _codeValueClassificationRepository { get; set; }

    private string NewCodeValueClassificationValue { get; set; }

    private List<CodeValueClassifications> ExistingCodeValueClassifications { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        await PopulateClassificationsAsync();
    }

    private async Task AddNewCodeClassificationValueAsync()
    {
        if (string.IsNullOrWhiteSpace(NewCodeValueClassificationValue)) return;

        await _codeValueClassificationRepository.InsertAsync(NewCodeValueClassificationValue);

        NewCodeValueClassificationValue = "";
        await PopulateClassificationsAsync();
    }

    private async Task PopulateClassificationsAsync()
    {
        ExistingCodeValueClassifications = new();
        ExistingCodeValueClassifications = await _codeValueClassificationRepository.GetAllAsync();
    }
}