using AutomaticPaymentReminder.Application.Features.SubscriptionTypes.Requests.Commands;
using AutomaticPaymentReminder.Application.Features.SubscriptionTypes.Responses.Commands;
using AutomaticPaymentReminder.Application.Interfaces.IRepositories.ISubscriptionTypeRepo;
using MediatR;

namespace AutomaticPaymentReminder.Application.UseCases.SubscriptionType;

public class DeleteSubscriptionTypeHandler : IRequestHandler<DeleteSubscriptionTypeRequest, DeleteSubscriptionTypeResponse>
{
    private readonly ISubscriptionTypeWriteRepo _subscriptionTypeWriteRepo;

    public DeleteSubscriptionTypeHandler(ISubscriptionTypeWriteRepo subscriptionTypeWriteRepo)
    {
        _subscriptionTypeWriteRepo = subscriptionTypeWriteRepo;
    }

    public async Task<DeleteSubscriptionTypeResponse> Handle(DeleteSubscriptionTypeRequest request, CancellationToken cancellationToken)
    {
        await _subscriptionTypeWriteRepo.DeleteAsync(request.Id);
        await _subscriptionTypeWriteRepo.SaveChangesAsync();
        return new DeleteSubscriptionTypeResponse();
    }
}