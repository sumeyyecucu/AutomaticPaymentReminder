namespace AutomaticPaymentReminder.Application.Features.SubscriptionTypes.Responses.Queries;

public class GetSubscriptionTypeResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}