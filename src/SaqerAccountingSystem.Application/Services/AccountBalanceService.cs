using SaqerAccountingSystem.Application.Interfaces;
using SaqerAccountingSystem.Domain.Entities;

namespace SaqerAccountingSystem.Application.Services;

public class AccountBalanceService : IAccountBalanceService
{
    private readonly List<AccountBalance> _balances = new();

    public Task<AccountBalance?> GetByAccountIdAsync(int accountId)
        => Task.FromResult(_balances.FirstOrDefault(x => x.AccountId == accountId));

    public Task<decimal> GetCurrentBalanceAsync(int accountId)
    {
        var balance = _balances.FirstOrDefault(x => x.AccountId == accountId);
        return Task.FromResult(balance?.CurrentBalance ?? 0m);
    }

    public Task UpdateBalanceAsync(int accountId, decimal debit, decimal credit)
    {
        var balance = _balances.FirstOrDefault(x => x.AccountId == accountId);
        if (balance is null)
        {
            balance = new AccountBalance
            {
                AccountId = accountId,
                OpeningBalance = 0,
                Debit = debit,
                Credit = credit,
                CurrentBalance = debit - credit
            };
            _balances.Add(balance);
        }
        else
        {
            balance.Debit += debit;
            balance.Credit += credit;
            balance.CurrentBalance = balance.OpeningBalance + balance.Debit - balance.Credit;
        }

        return Task.CompletedTask;
    }
}
