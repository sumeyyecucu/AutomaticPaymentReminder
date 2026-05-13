using AutomaticPaymentReminder.Application.Features.Debt.Requests.Queries;
using AutomaticPaymentReminder.Application.Features.Debt.Responses.Queries;
using AutomaticPaymentReminder.Application.Interfaces.IServices;
using MediatR;

namespace AutomaticPaymentReminder.Application.UseCases.Debt;

public class GetDebtHandler : IRequestHandler<GetDebtRequest, GetDebtResponse>
{
    private readonly IDebtQueryService _debtQueryService;

    public GetDebtHandler(IDebtQueryService debtQueryService)
    {
        _debtQueryService = debtQueryService;
    }

    public async Task<GetDebtResponse> Handle(GetDebtRequest request, CancellationToken cancellationToken)
    {
        var debt = _debtQueryService.GetDebtAsync(request.Number);
        if (debt != null)
        {
            return new GetDebtResponse() { Debt = debt };
        }

        return new GetDebtResponse() { Debt = null };


    }
}