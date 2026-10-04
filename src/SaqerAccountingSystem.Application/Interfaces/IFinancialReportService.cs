using SaqerAccountingSystem.Domain.Entities;

namespace SaqerAccountingSystem.Application.Interfaces;

public interface IFinancialReportService
{
    Task<IEnumerable<FinancialReport>> GetAllAsync();
    Task<FinancialReport?> GetByIdAsync(int id);
    Task<FinancialReport> GenerateIncomeStatementAsync(int companyId, DateTime fromDate, DateTime toDate);
    Task<FinancialReport> GenerateBalanceSheetAsync(int companyId, DateTime asOfDate);
}
