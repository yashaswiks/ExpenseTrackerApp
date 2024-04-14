using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.BusinessLogic.DbSet;

public class CodeValue
{
    public int Id { get; set; }
    public int CodeValueClassificationId { get; set; }
    public CodeValueClassification CodeValueClassification { get; set; }

    [Column(TypeName = "varchar(200)")]
    public string Value { get; set; }
}