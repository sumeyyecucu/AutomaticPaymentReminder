namespace AutomaticPaymentReminder.Domain.Entites;

public class Subscriptions : BaseEntity
{
   
    public SubscriptionTypes Type { get; set; }
    public string? ServiceProvider { get; set; }
    public string? SubscriptionNum { get; set; }
    public string? CustomerNum { get; set; }
    public bool IsActive { get; set; }
    public Customers Customer { get; set; }
    public List<Payments> Payments { get; set; }
    
}