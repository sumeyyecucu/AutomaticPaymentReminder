using AutomaticPaymentReminder.Application.DTOs;
using AutomaticPaymentReminder.Application.Interfaces.IServices;

namespace AutomaticPaymentReminder.Infrastructure.Services;

public class MockDebtQueryService : IDebtQueryService
{
    private static readonly List<DebtQueryResult> _mockData = new()
    {
        new DebtQueryResult
        {
            SubscriptionNum = 1001,
            CustomerNum = 201,
            ServiceProvider = "İski",
            Year = 2025,
            Month = 3,
            Amount = 349.99m
        },
        new DebtQueryResult
        {
            SubscriptionNum = 1002,
            CustomerNum = 201,
            ServiceProvider = "Turkcell",
            Year = 2025,
            Month = 4,
            Amount = 459.99m

        },
        new DebtQueryResult
        {
            SubscriptionNum = 1003,
            CustomerNum = 202,
            ServiceProvider = "Enerjisa",
            Year = 2025,
            Month = 2,
            Amount = 39.99m
        }
    };
    

    public  Task<DebtQueryResult?> GetDebtAsync(int number)
    {
        var result =  _mockData.FirstOrDefault(x => x.SubscriptionNum == number || x.CustomerNum == number);
        if (result != null)
        {
            var debt = new DebtQueryResult
            {

                ServiceProvider = result.ServiceProvider,
                Amount = result.Amount,
                Year = result.Year,
                Month = result.Month,
            };
            return Task.FromResult<DebtQueryResult?>(debt);
        }
        return Task.FromResult<DebtQueryResult?>(null);
    }
}