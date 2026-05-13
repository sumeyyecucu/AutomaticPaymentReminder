using AutomaticPaymentReminder.Application.Features.Subscriptions.Responses.Commands;
using MediatR;

namespace AutomaticPaymentReminder.Application.Features.Subscriptions.Requests;

public class UpdateSubscriptionRequest : IRequest<UpdateSubscriptionResponse>
{
    public Guid Id { get; set; }
    public Guid SubscriptionId { get; set; }
    public string? ServiceProvider { get; set; }
    public int? SubscriptionNum { get; set; }
    public int? CustomerNum { get; set; }
    public bool IsActive { get; set; }
}