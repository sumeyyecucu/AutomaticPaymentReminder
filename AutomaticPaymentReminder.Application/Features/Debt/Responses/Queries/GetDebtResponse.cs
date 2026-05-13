using AutomaticPaymentReminder.Application.DTOs;

namespace AutomaticPaymentReminder.Application.Features.Debt.Responses.Queries;

public class GetDebtResponse
{
    public DebtQueryResult Debt { get; set; }
}