using SaqerAccountingSystem.Domain.Entities;

namespace SaqerAccountingSystem.Application.Interfaces;

public interface IAccountBalanceService
{
    Task<AccountBalance?> GetByAccountIdAsync(int accountId);
    Task<decimal> GetCurrentBalanceAsync(int accountId);
    Task UpdateBalanceAsync(int accountId, decimal debit, decimal credit);
}
