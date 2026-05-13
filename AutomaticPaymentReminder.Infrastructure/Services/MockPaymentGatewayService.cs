using AutomaticPaymentReminder.Application.Interfaces.IServices;

namespace AutomaticPaymentReminder.Infrastructure.Services;

public class MockPaymentGatewayService : IPaymentGatewayService
{

    public Task<bool> ProcessPaymentAsync(Guid subscriptionId, decimal amount)
    {
        var isSuccess = amount > 0 && new Random().Next(1, 10) != 1; 
        return Task.FromResult(isSuccess);
    }
}