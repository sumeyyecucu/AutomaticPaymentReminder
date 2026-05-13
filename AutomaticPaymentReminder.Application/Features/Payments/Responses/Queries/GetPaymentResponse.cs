namespace AutomaticPaymentReminder.Application.Features.Payments.Responses.Queries;

public class GetPaymentResponse
{
    public Guid Id { get; set; }
    public Guid SubscriptionId { get; set; }
    public string? ServiceProvider { get; set; }
    public string? SubscriptionType { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public int Year { get; set; }
    public int Month { get; set; }
    public bool IsPaid { get; set; }
}