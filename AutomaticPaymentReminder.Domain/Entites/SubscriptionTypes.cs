namespace AutomaticPaymentReminder.Domain.Entites;

public class SubscriptionTypes : BaseEntity
{
    
    public string Name { get; set; } = string.Empty;
    public List<Subscriptions>? Subscriptions { get; set; }
}