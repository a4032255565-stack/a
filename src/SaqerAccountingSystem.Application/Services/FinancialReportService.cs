using SaqerAccountingSystem.Application.Interfaces;
using SaqerAccountingSystem.Domain.Entities;

namespace SaqerAccountingSystem.Application.Services;

public class FinancialReportService : IFinancialReportService
{
    private readonly List<FinancialReport> _reports = new();

    public Task<IEnumerable<FinancialReport>> GetAllAsync()
        => Task.FromResult<IEnumerable<FinancialReport>>(_reports);

    public Task<FinancialReport?> GetByIdAsync(int id)
        => Task.FromResult(_reports.FirstOrDefault(x => x.Id == id));

    public Task<FinancialReport> GenerateIncomeStatementAsync(int companyId, DateTime fromDate, DateTime toDate)
    {
        var report = new FinancialReport
        {
            Id = _reports.Count == 0 ? 1 : _reports.Max(x => x.Id) + 1,
            ReportName = $"Income Statement - {fromDate:yyyy-MM-dd} to {toDate:yyyy-MM-dd}",
            ReportType = "IncomeStatement",
            ReportDate = DateTime.UtcNow,
            CompanyId = companyId,
            TotalRevenue = 0,
            TotalExpense = 0,
            NetIncome = 0
        };

        _reports.Add(report);
        return Task.FromResult(report);
    }

    public Task<FinancialReport> GenerateBalanceSheetAsync(int companyId, DateTime asOfDate)
    {
        var report = new FinancialReport
        {
            Id = _reports.Count == 0 ? 1 : _reports.Max(x => x.Id) + 1,
            ReportName = $"Balance Sheet - {asOfDate:yyyy-MM-dd}",
            ReportType = "BalanceSheet",
            ReportDate = asOfDate,
            CompanyId = companyId
        };

        _reports.Add(report);
        return Task.FromResult(report);
    }
}
