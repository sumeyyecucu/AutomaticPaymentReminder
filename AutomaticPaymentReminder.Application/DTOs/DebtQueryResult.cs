namespace AutomaticPaymentReminder.Application.DTOs;

public class DebtQueryResult
{
    public int? SubscriptionNum { get; set; }
    public int? CustomerNum { get; set; }
    public string? ServiceProvider { get; set; }
    public DateTime DueDate { get; set; }
    public decimal Amount { get; set; }
    public int Year { get; set; }
    public int Month { get; set; }
}

