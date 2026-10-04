using SaqerAccountingSystem.Domain.Entities;

namespace SaqerAccountingSystem.Application.Interfaces;

public interface IReportService
{
    Task<DashboardSummary> GetDashboardAsync();
}

public class DashboardSummary
{
    public int TotalCustomers { get; set; }
    public int TotalSuppliers { get; set; }
    public int TotalInvoices { get; set; }
    public decimal TotalSales { get; set; }
    public decimal TotalPurchases { get; set; }
    public decimal NetBalance { get; set; }
    public int TotalItems { get; set; }
    public int TotalBranches { get; set; }
}
