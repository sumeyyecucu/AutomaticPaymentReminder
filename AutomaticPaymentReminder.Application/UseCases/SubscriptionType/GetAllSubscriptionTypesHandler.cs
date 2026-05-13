using AutoMapper;
using AutomaticPaymentReminder.Application.Features.SubscriptionTypes.Requests.Queries;
using AutomaticPaymentReminder.Application.Features.SubscriptionTypes.Responses.Queries;
using AutomaticPaymentReminder.Application.Interfaces.IRepositories.ISubscriptionTypeRepo;
using MediatR;

namespace AutomaticPaymentReminder.Application.UseCases.SubscriptionType;

public class GetAllSubscriptionTypesHandler : IRequestHandler<GetAllSubscriptionTypesRequest, List<GetSubscriptionTypeResponse>>
{
    private readonly IMapper _mapper;
    private readonly ISubscriptionTypeReadRepo _subscriptionTypeReadRepo;

    public GetAllSubscriptionTypesHandler(IMapper mapper, ISubscriptionTypeReadRepo subscriptionTypeReadRepo)
    {
        _mapper = mapper;
        _subscriptionTypeReadRepo = subscriptionTypeReadRepo;
    }

    public async Task<List<GetSubscriptionTypeResponse>> Handle(GetAllSubscriptionTypesRequest request, CancellationToken cancellationToken)
    {
        var entities = _subscriptionTypeReadRepo.GetAll();
        return _mapper.Map<List<GetSubscriptionTypeResponse>>(entities);
    }
}