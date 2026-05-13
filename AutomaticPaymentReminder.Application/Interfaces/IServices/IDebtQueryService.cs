using AutomaticPaymentReminder.Application.DTOs;

namespace AutomaticPaymentReminder.Application.Interfaces.IServices;

public interface IDebtQueryService
{
    DebtQueryResult? GetDebtAsync(int number);
    public IQueryable<DebtQueryResult> GetAllDebtAsync();

}