namespace AutomaticPaymentReminder.Application.Interfaces.IServices;

public interface IPaymentGatewayService
{
    Task<bool> ProcessPaymentAsync(Guid subscriptionId, decimal amount);
}