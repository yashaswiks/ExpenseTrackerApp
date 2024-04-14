using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.BusinessLogic.DbSet;

public class CodeValueClassification
{
    public int Id { get; set; }

    [Column(TypeName = "varchar(200)")]
    public string Value { get; set; }
    public ICollection<CodeValue> CodeValues { get; set; } = new List<CodeValue>();
}