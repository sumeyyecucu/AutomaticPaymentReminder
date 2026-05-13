using AutomaticPaymentReminder.Application.Features.Subscriptions.Responses.Commands;
using MediatR;

namespace AutomaticPaymentReminder.Application.Features.Subscriptions.Requests.Commands;

public class CreateSubscriptionRequest : IRequest<CreateSubscriptionResponse>
{
    public string SubscriptionType { get; set; }
    public string? ServiceProvider { get; set; }
    public int? SubscriptionNum { get; set; }
    public int? CustomerNum { get; set; }
    public bool IsActive { get; set; }

}