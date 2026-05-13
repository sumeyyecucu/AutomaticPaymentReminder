using AutoMapper;
using AutomaticPaymentReminder.Application.Features.SubscriptionTypes.Requests.Commands;
using AutomaticPaymentReminder.Application.Features.SubscriptionTypes.Responses.Commands;
using AutomaticPaymentReminder.Application.Interfaces.IRepositories.ISubscriptionTypeRepo;
using AutomaticPaymentReminder.Domain.Entites;
using MediatR;

namespace AutomaticPaymentReminder.Application.UseCases.SubscriptionType;

public class CreateSubscriptionTypeHandler : IRequestHandler<CreateSubscriptionTypeRequest, CreateSubscriptionTypeResponse>
{
    private readonly ISubscriptionTypeWriteRepo _subscriptionTypeWriteRepo;
    private readonly IMapper _mapper;

    public CreateSubscriptionTypeHandler(ISubscriptionTypeWriteRepo subscriptionTypeWriteRepo, IMapper mapper)
    {
        _subscriptionTypeWriteRepo = subscriptionTypeWriteRepo;
        _mapper = mapper;
    }

    public async Task<CreateSubscriptionTypeResponse> Handle(CreateSubscriptionTypeRequest request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<SubscriptionTypes>(request);
        await _subscriptionTypeWriteRepo.AddAsync(entity);
        await _subscriptionTypeWriteRepo.SaveChangesAsync();
        return new CreateSubscriptionTypeResponse();
    }
}