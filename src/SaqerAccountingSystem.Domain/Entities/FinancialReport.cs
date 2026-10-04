namespace SaqerAccountingSystem.Domain.Entities;

public class FinancialReport : BaseEntity
{
    public string ReportName { get; set; } = string.Empty;
    public string ReportType { get; set; } = "IncomeStatement";
    public DateTime ReportDate { get; set; } = DateTime.UtcNow;
    public int CompanyId { get; set; }
    public Company? Company { get; set; }
    public string ReportContent { get; set; } = string.Empty;
    public decimal TotalRevenue { get; set; }
    public decimal TotalExpense { get; set; }
    public decimal NetIncome { get; set; }
}
