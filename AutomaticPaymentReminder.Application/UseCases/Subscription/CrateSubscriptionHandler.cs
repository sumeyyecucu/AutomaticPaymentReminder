using AutoMapper;
using AutomaticPaymentReminder.Application.Features.Subscriptions.Requests.Commands;
using AutomaticPaymentReminder.Application.Features.Subscriptions.Responses.Commands;
using AutomaticPaymentReminder.Application.Interfaces.IRepositories.ISubscriptionRepo;
using AutomaticPaymentReminder.Domain.Entites;
using MediatR;

namespace AutomaticPaymentReminder.Application.UseCases.Subscription;

public class CrateSubscriptionHandler : IRequestHandler<CreateSubscriptionRequest,CreateSubscriptionResponse>
{
    private readonly ISubscriptionWriteRepo _subscriptionWriteRepo;
    private readonly IMapper _mapper;
    public CrateSubscriptionHandler(ISubscriptionWriteRepo subscriptionWriteRepo, IMapper mapper)
    {
        _subscriptionWriteRepo = subscriptionWriteRepo;
        _mapper = mapper;
    }

    public async Task<CreateSubscriptionResponse> Handle(CreateSubscriptionRequest request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Subscriptions>(request);
        await _subscriptionWriteRepo.AddAsync(entity);
        return new CreateSubscriptionResponse();

    }
}