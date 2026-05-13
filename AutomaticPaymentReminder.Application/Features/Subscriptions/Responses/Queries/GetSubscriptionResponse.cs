namespace AutomaticPaymentReminder.Application.Features.Subscriptions.Responses.Queries;

public class GetSubscriptionResponse
{
    public string SubscriptionType { get; set; }
    public string? ServiceProvider { get; set; }
    public int? SubscriptionNum { get; set; }
    public int? CustomerNum { get; set; }
    public bool IsActive { get; set; }
}