using AutomaticPaymentReminder.Application.Features.Debt.Responses.Queries;
using MediatR;

namespace AutomaticPaymentReminder.Application.Features.Debt.Requests.Queries;

public class GetDebtRequest : IRequest<GetDebtResponse>
{
    public int Number { get; set; }
}