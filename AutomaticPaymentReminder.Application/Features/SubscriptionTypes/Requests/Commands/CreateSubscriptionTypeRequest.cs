using AutomaticPaymentReminder.Application.Features.SubscriptionTypes.Responses.Commands;
using MediatR;

namespace AutomaticPaymentReminder.Application.Features.SubscriptionTypes.Requests.Commands;

public class CreateSubscriptionTypeRequest : IRequest<CreateSubscriptionTypeResponse>
{
    public string Name { get; set; } = string.Empty;
}
