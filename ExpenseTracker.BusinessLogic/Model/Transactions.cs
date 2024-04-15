namespace ExpenseTracker.BusinessLogic.Model;

public class Transactions
{
    public int Id { get; set; }
    public double? Amount { get; set; }
    public int? CategoryId { get; set; }
    public DateTime Date { get; set; }
    public int? IsReversed { get; set; }
    public int? MoneySourceId { get; set; }
    public string Notes { get; set; }
    public int? TransactionTypeId { get; set; }
}