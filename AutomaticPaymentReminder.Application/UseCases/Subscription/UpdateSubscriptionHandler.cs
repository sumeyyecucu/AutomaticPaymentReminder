using AutoMapper;
using AutomaticPaymentReminder.Application.Features.Subscriptions.Requests;
using AutomaticPaymentReminder.Application.Features.Subscriptions.Responses.Commands;
using AutomaticPaymentReminder.Application.Interfaces.IRepositories.ISubscriptionRepo;
using AutomaticPaymentReminder.Application.Interfaces.IRepositories.ISubscriptionTypeRepo;
using AutomaticPaymentReminder.Domain.Entites;
using MediatR;

namespace AutomaticPaymentReminder.Application.UseCases.Subscription;

public class UpdateSubscriptionHandler : IRequestHandler<UpdateSubscriptionRequest, UpdateSubscriptionResponse>
{
    private readonly IMapper _mapper;
    private readonly ISubscriptionWriteRepo _subscriptionWriteRepo;
    private readonly ISubscriptionTypeReadRepo _subscriptionTypeReadRepo;

    public UpdateSubscriptionHandler(IMapper mapper, ISubscriptionWriteRepo subscriptionWriteRepo, ISubscriptionTypeReadRepo subscriptionTypeReadRepo)
    {
        _mapper = mapper;
        _subscriptionWriteRepo = subscriptionWriteRepo;
        _subscriptionTypeReadRepo = subscriptionTypeReadRepo;
    }

    public async Task<UpdateSubscriptionResponse> Handle(UpdateSubscriptionRequest request, CancellationToken cancellationToken)
    {
        var subscriptionType = await _subscriptionTypeReadRepo.GetByIdAsync(request.SubscriptionId);
        var entity = _mapper.Map<Subscriptions>(request);
        entity.Type = subscriptionType;
        _subscriptionWriteRepo.Update(entity);
        await _subscriptionWriteRepo.SaveChangesAsync();
        return new UpdateSubscriptionResponse();
    }
}