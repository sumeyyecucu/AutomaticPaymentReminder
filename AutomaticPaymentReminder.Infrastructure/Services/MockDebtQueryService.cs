using AutomaticPaymentReminder.Application.DTOs;
using AutomaticPaymentReminder.Application.Interfaces.IServices;

namespace AutomaticPaymentReminder.Infrastructure.Services;

public class MockDebtQueryService : IDebtQueryService
{
    private static readonly List<DebtQueryResult> mockData = new()
    {
        new DebtQueryResult
        {
            SubscriptionNum = 1001,
            CustomerNum = 201,
            ServiceProvider = "İski",
            DueDate = new DateTime(2026, 3, 14),
            Year = 2026,
            Month = 2,
            Amount = 349.99m
        },
        new DebtQueryResult
        {
            SubscriptionNum = 1002,
            CustomerNum = 201,
            ServiceProvider = "Turkcell",
            DueDate = new DateTime(2026, 5, 16),
            Year = 2026,
            Month = 4,
            Amount = 459.99m
        },
        new DebtQueryResult
        {
            SubscriptionNum = 1003,
            CustomerNum = 202,
            ServiceProvider = "Enerjisa",
            DueDate = new DateTime(2026, 5, 22),
            Year = 2025,
            Month = 4,
            Amount = 39.99m
        }
    };
    

    public DebtQueryResult? GetDebtAsync(int number)
    {
        var result =  mockData.FirstOrDefault(x => x.SubscriptionNum == number || x.CustomerNum == number);
        if (result != null)
        {
            var debt = new DebtQueryResult
            {

                ServiceProvider = result.ServiceProvider,
                Amount = result.Amount,
                Year = result.Year,
                Month = result.Month,
                DueDate = result.DueDate,
            };
            return debt;
        }
        return null;
    }

    public IQueryable<DebtQueryResult> GetAllDebtAsync()
    {
        return mockData.AsQueryable();
    }
}