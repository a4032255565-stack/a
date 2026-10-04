namespace SaqerAccountingSystem.Domain.Entities;

public class Account : BaseEntity
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string AccountType { get; set; } = string.Empty; // Assets, Liabilities, Equity, Revenue, Expense
    public int? ParentAccountId { get; set; }
    public Account? ParentAccount { get; set; }
    public bool IsActive { get; set; } = true;
    public decimal OpeningBalance { get; set; }
    public int CompanyId { get; set; }
    public Company? Company { get; set; }
}
