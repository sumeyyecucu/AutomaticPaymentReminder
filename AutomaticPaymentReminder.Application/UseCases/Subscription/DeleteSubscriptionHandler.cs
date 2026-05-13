using AutoMapper;
using AutomaticPaymentReminder.Application.Features.Subscriptions.Requests;
using AutomaticPaymentReminder.Application.Features.Subscriptions.Responses.Commands;
using AutomaticPaymentReminder.Application.Interfaces.IRepositories.ISubscriptionRepo;
using MediatR;

namespace AutomaticPaymentReminder.Application.UseCases.Subscription;

public class DeleteSubscriptionHandler : IRequestHandler<DeleteSubscriptionRequest,DeleteSubscriptionResponse>
{
    private readonly ISubscriptionWriteRepo _subscriptionWriteRepo;

    public DeleteSubscriptionHandler(ISubscriptionWriteRepo subscriptionWriteRepo)
    {
        _subscriptionWriteRepo = subscriptionWriteRepo;
    }

    public async Task<DeleteSubscriptionResponse> Handle(DeleteSubscriptionRequest request, CancellationToken cancellationToken)
    {
        await _subscriptionWriteRepo.DeleteAsync(request.Id);
        await _subscriptionWriteRepo.SaveChangesAsync();
        return new DeleteSubscriptionResponse();
    }
}