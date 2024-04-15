using ExpenseTracker.BusinessLogic.Model;
using ExpenseTracker.BusinessLogic.Repository.IRepository;
using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.WebApp.Components.Pages;

public partial class CodeValue
{
    [Inject]
    private ICodeValueClassificationRepository _codeValueClassificationRepository { get; set; }

    [Inject]
    private ICodeValuesRepository _codeValuesRepository { get; set; }

    [SupplyParameterFromForm]
    private InsertCodeValueDto InsertCodeValueModel { get; set; } = new();

    public List<CodeValueClassifications> CodeValueClassifications { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        CodeValueClassifications = await _codeValueClassificationRepository.GetAllAsync();
    }

    private async Task SubmitAsync()
    {
        var insertDto = new InsertCodeValuesDto(
            InsertCodeValueModel.CodeValueClassificationId.Value,
            InsertCodeValueModel.Value);

        var insertedIdentity = await _codeValuesRepository.InsertAsync(insertDto);

        if (insertedIdentity.HasValue)
        {
            InsertCodeValueModel = new();
        }
    }
}

public class InsertCodeValueDto
{
    [Required]
    public int? CodeValueClassificationId { get; set; }

    [Required]
    [StringLength(200)]
    public string Value { get; set; }
}