namespace AutomaticPaymentReminder.Domain.Entites;

public class Payments : BaseEntity
{
    public decimal Amount { get; set; } 
    public DateTime PaymentDate { get; set; }
    public int Year { get; set; }
    public int Month { get; set; }
    public bool IsPaid { get; set; }
    public Subscriptions Subscription { get; set; }
    
    
}