using AutomaticPaymentReminder.Application.DTOs;

namespace AutomaticPaymentReminder.Application.Interfaces.IServices;

public interface IDebtQueryService
{
    Task<DebtQueryResult?> GetDebtAsync(int number);

}