using AutomaticPaymentReminder.Application.Features.SubscriptionTypes.Responses.Commands;
using MediatR;

namespace AutomaticPaymentReminder.Application.Features.SubscriptionTypes.Requests.Commands;

public class DeleteSubscriptionTypeRequest : IRequest<DeleteSubscriptionTypeResponse>
{
    public Guid Id { get; set; }
}