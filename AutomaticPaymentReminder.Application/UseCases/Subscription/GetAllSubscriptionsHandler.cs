using AutoMapper;
using AutomaticPaymentReminder.Application.Features.Subscriptions.Requests.Queries;
using AutomaticPaymentReminder.Application.Features.Subscriptions.Responses.Queries;
using AutomaticPaymentReminder.Application.Interfaces.IRepositories.ISubscriptionRepo;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutomaticPaymentReminder.Application.UseCases.Subscription;

public class GetAllSubscriptionsHandler : IRequestHandler<GetAllSubscriptionsRequest,List<GetSubscriptionResponse>>
{
    private readonly IMapper _mapper;
    private readonly ISubscriptionReadRepo _subscriptionReadRepo;

    public GetAllSubscriptionsHandler(IMapper mapper, ISubscriptionReadRepo subscriptionReadRepo)
    {
        _mapper = mapper;
        _subscriptionReadRepo = subscriptionReadRepo;
    }

    public async Task<List<GetSubscriptionResponse>> Handle(GetAllSubscriptionsRequest request, CancellationToken cancellationToken)
    {
        var entity = _subscriptionReadRepo.GetAll().Include(s => s.Type);
        var subscriptions = _mapper.Map<List<GetSubscriptionResponse>>(entity);
        return subscriptions;
    }
}