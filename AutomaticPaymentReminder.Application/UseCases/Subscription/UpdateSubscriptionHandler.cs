using AutoMapper;
using AutomaticPaymentReminder.Application.Features.Subscriptions.Requests;
using AutomaticPaymentReminder.Application.Features.Subscriptions.Responses.Commands;
using AutomaticPaymentReminder.Application.Interfaces.IRepositories.ISubscriptionRepo;
using AutomaticPaymentReminder.Domain.Entites;
using MediatR;

namespace AutomaticPaymentReminder.Application.UseCases.Subscription;

public class UpdateSubscriptionHandler: IRequestHandler<UpdateSubscriptionRequest,UpdateSubscriptionResponse>
{
    private readonly IMapper _mapper;
    private readonly ISubscriptionWriteRepo _subscriptionWriteRepo;

    public UpdateSubscriptionHandler(IMapper mapper, ISubscriptionWriteRepo subscriptionWriteRepo)
    {
        _mapper = mapper;
        _subscriptionWriteRepo = subscriptionWriteRepo;
    }

    public async Task<UpdateSubscriptionResponse> Handle(UpdateSubscriptionRequest request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Subscriptions>(request);
        _subscriptionWriteRepo.Update(entity);
        await _subscriptionWriteRepo.SaveChangesAsync();
        return new UpdateSubscriptionResponse();
        
    }
}