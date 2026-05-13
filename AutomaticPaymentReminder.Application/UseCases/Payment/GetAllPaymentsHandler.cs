using AutoMapper;
using AutomaticPaymentReminder.Application.Features.Payments.Requests.Queries;
using AutomaticPaymentReminder.Application.Features.Payments.Responses.Queries;
using AutomaticPaymentReminder.Application.Interfaces.IRepositories.IPaymentRepo;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutomaticPaymentReminder.Application.UseCases.Payment;

public class GetAllPaymentsHandler : IRequestHandler<GetAllPaymentsRequest, List<GetPaymentResponse>>
{
    private readonly IMapper _mapper;
    private readonly IPaymentReadRepo _paymentReadRepo;

    public GetAllPaymentsHandler(IMapper mapper, IPaymentReadRepo paymentReadRepo)
    {
        _mapper = mapper;
        _paymentReadRepo = paymentReadRepo;
    }

    public async Task<List<GetPaymentResponse>> Handle(GetAllPaymentsRequest request, CancellationToken cancellationToken)
    {
        var payments = await _paymentReadRepo.GetAll()
            .Include(p => p.Subscription)
            .ThenInclude(s => s.Type)
            .ToListAsync(cancellationToken);

        return _mapper.Map<List<GetPaymentResponse>>(payments);
    }
}
