using AutomaticPaymentReminder.Application.Features.Debt.Requests.Queries;
using AutomaticPaymentReminder.Application.Features.Debt.Responses.Queries;
using AutomaticPaymentReminder.Application.Interfaces.IRepositories.IPaymentRepo;
using AutomaticPaymentReminder.Application.Interfaces.IServices;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutomaticPaymentReminder.Application.UseCases.Debt;

public class GetDebtHandler : IRequestHandler<GetDebtRequest, GetDebtResponse>
{
    private readonly IDebtQueryService _debtQueryService;
    private readonly IPaymentReadRepo _paymentReadRepo;

    public GetDebtHandler(IDebtQueryService debtQueryService, IPaymentReadRepo paymentReadRepo)
    {
        _debtQueryService = debtQueryService;
        _paymentReadRepo = paymentReadRepo;
    }

    public async Task<GetDebtResponse> Handle(GetDebtRequest request, CancellationToken cancellationToken)
    {
        var debt = _debtQueryService.GetDebtAsync(request.Number);
        if (debt == null)
            return new GetDebtResponse() { Debt = null };

        var isPaid = await _paymentReadRepo.GetAll()
            .Include(p => p.Subscription)
            .AnyAsync(p => p.Subscription.SubscriptionNum == request.Number
                        && p.Year == debt.Year
                        && p.Month == debt.Month
                        && p.IsPaid, cancellationToken);

        return new GetDebtResponse() { Debt = debt, IsPaid = isPaid };
    }
}