namespace AutomaticPaymentReminder.Application.Interfaces.IServices;

public interface IEmailService
{
    Task SendReminderAsync(string email,string subscriptionName, DateTime paymentDate);
}