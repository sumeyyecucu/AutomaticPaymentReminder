namespace AutomaticPaymentReminder.Application.Features.Payments.Responses.Queries;

public class GetPaymentResponse
{
    public decimal Amount { get; set; } 
    public DateTime PaymentDate { get; set; }
    public int Year { get; set; }
    public int Month { get; set; }
    public bool IsPaid { get; set; }
    public Domain.Entites.Subscriptions Subscription { get; set; }
}