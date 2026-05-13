using AutoMapper;
using AutomaticPaymentReminder.Application.Features.Subscriptions.Requests.Commands;
using AutomaticPaymentReminder.Application.Features.Subscriptions.Responses.Commands;
using AutomaticPaymentReminder.Application.Interfaces.IRepositories.ICustomerRepo;
using AutomaticPaymentReminder.Application.Interfaces.IRepositories.ISubscriptionRepo;
using AutomaticPaymentReminder.Application.Interfaces.IRepositories.ISubscriptionTypeRepo;
using AutomaticPaymentReminder.Domain.Entites;
using MediatR;

namespace AutomaticPaymentReminder.Application.UseCases.Subscription;

public class CrateSubscriptionHandler : IRequestHandler<CreateSubscriptionRequest,CreateSubscriptionResponse>
{
    private readonly ISubscriptionWriteRepo _subscriptionWriteRepo;
    private readonly ICustomerReadRepo _customerReadRepo;
    private readonly IMapper _mapper;
    private readonly ISubscriptionTypeReadRepo _subscriptionTypeReadRepo;
    public CrateSubscriptionHandler(ISubscriptionWriteRepo subscriptionWriteRepo, IMapper mapper, ICustomerReadRepo customerReadRepo, ISubscriptionTypeReadRepo subscriptionTypeReadRepo)
    {
        _subscriptionWriteRepo = subscriptionWriteRepo;
        _mapper = mapper;
        _customerReadRepo = customerReadRepo;
        _subscriptionTypeReadRepo = subscriptionTypeReadRepo;
    }

    public async Task<CreateSubscriptionResponse> Handle(CreateSubscriptionRequest request, CancellationToken cancellationToken)
    {
        var customer = await _customerReadRepo.GetByIdAsync(request.CustomerId);
        var subscriptionType = await _subscriptionTypeReadRepo.GetByIdAsync(request.SubscriptionId);
        var entity = _mapper.Map<Subscriptions>(request);
        entity.Customer = customer;
        entity.Type = subscriptionType;
        await _subscriptionWriteRepo.AddAsync(entity);
        await _subscriptionWriteRepo.SaveChangesAsync();
        return new CreateSubscriptionResponse();

    }
}