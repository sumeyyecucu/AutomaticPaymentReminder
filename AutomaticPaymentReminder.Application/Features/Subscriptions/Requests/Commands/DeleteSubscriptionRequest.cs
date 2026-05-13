using AutomaticPaymentReminder.Application.Features.Subscriptions.Responses.Commands;
using MediatR;

namespace AutomaticPaymentReminder.Application.Features.Subscriptions.Requests;

public class DeleteSubscriptionRequest : IRequest<DeleteSubscriptionResponse>
{
    public Guid Id { get; set; }

}