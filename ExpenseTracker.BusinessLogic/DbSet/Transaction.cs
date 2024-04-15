using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.BusinessLogic.DbSet;

public class Transaction
{
    public int Id { get; set; }
    public int TransactionTypeId { get; set; }
    public CodeValue TransactionType { get; set; }

    [Column(TypeName = "decimal(19, 6)")]
    public decimal Amount { get; set; }

    public int CategoryId { get; set; }
    public CodeValue Category { get; set; }
    public int MoneySourceId { get; set; }
    public CodeValue MoneySource { get; set; }
    public DateTime Date { get; set; }
    public string Notes { get; set; }
    public bool IsReversed { get; set; }
}