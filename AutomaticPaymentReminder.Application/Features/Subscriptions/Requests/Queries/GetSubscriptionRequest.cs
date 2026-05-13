using AutomaticPaymentReminder.Application.Features.Subscriptions.Responses.Queries;
using MediatR;

namespace AutomaticPaymentReminder.Application.Features.Subscriptions.Requests.Queries;

public class GetSubscriptionRequest : IRequest<GetSubscriptionResponse>
{
    public Guid Id { get; set; }

}