using AutoMapper;
using AutomaticPaymentReminder.Application.Features.Subscriptions.Requests.Queries;
using AutomaticPaymentReminder.Application.Features.Subscriptions.Responses.Queries;
using AutomaticPaymentReminder.Application.Interfaces.IRepositories.ISubscriptionRepo;
using MediatR;

namespace AutomaticPaymentReminder.Application.UseCases.Subscription;

public class GetSubscriptionHandler : IRequestHandler<GetSubscriptionRequest,GetSubscriptionResponse>
{
    private readonly IMapper _mapper;
    private readonly ISubscriptionReadRepo _subscriptionReadRepo;

    public GetSubscriptionHandler(IMapper mapper, ISubscriptionReadRepo subscriptionReadRepo)
    {
        _mapper = mapper;
        _subscriptionReadRepo = subscriptionReadRepo;
    }

    public async Task<GetSubscriptionResponse> Handle(GetSubscriptionRequest request, CancellationToken cancellationToken)
    {
        var entity = await _subscriptionReadRepo.GetByIdAsync(request.Id);
        return _mapper.Map<GetSubscriptionResponse>(entity);
        
    }
}