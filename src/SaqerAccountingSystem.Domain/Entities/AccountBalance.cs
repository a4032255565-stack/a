namespace SaqerAccountingSystem.Domain.Entities;

public class AccountBalance : BaseEntity
{
    public int AccountId { get; set; }
    public Account? Account { get; set; }
    public decimal OpeningBalance { get; set; }
    public decimal Debit { get; set; }
    public decimal Credit { get; set; }
    public decimal CurrentBalance { get; set; }
    public DateTime AsOfDate { get; set; } = DateTime.UtcNow;
}
