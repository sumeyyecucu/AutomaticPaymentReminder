using AutomaticPaymentReminder.Application.DTOs;
using AutomaticPaymentReminder.Application.Interfaces.IRepositories.IPaymentRepo;
using AutomaticPaymentReminder.Application.Interfaces.IRepositories.ISubscriptionRepo;
using AutomaticPaymentReminder.Application.Interfaces.IServices;
using Microsoft.EntityFrameworkCore;


namespace AutomaticPaymentReminder.Application.UseCases;

public class SendEmailService
{
    private readonly IEmailService _emailService;
    private readonly IDebtQueryService _debtQueryService;
    private readonly IPaymentReadRepo _paymentReadRepo;
    private readonly ISubscriptionReadRepo _subscriptionReadRepo;

    public SendEmailService(IEmailService emailService, IDebtQueryService debtQueryService, IPaymentReadRepo paymentReadRepo, ISubscriptionReadRepo subscriptionReadRepo)
    {
        _emailService = emailService;
        _debtQueryService = debtQueryService;
        _paymentReadRepo = paymentReadRepo;
        _subscriptionReadRepo = subscriptionReadRepo;
    }

    public async Task<IQueryable<DebtQueryResult>> GetUnpaidDebts()
    {
        var upcoming = _debtQueryService.GetAllDebtAsync()
            .Where(d => d.DueDate.Subtract(DateTime.UtcNow).TotalDays >= 0 &&
                        d.DueDate.Subtract(DateTime.UtcNow).TotalDays <= 3);

        var paidKeys = _paymentReadRepo.GetAll()
            .Where(p => p.IsPaid)
            .Select(p => new { p.Subscription.SubscriptionNum, p.Month, p.Year })
            .ToList();

        var unpaid = upcoming.Where(d => !paidKeys.Any(p =>
            p.SubscriptionNum == d.SubscriptionNum &&
            p.Month == d.DueDate.Month &&
            p.Year == d.DueDate.Year));
        return unpaid;
    }

    public async Task<int> SendReminder()
    {
        var unpaidDebts = (await GetUnpaidDebts()).ToList();

        var subNumbers = unpaidDebts
            .Select(d => d.SubscriptionNum)
            .Where(n => n != null)
            .ToHashSet();

        var allSubscriptions = await _subscriptionReadRepo.GetAll()
            .Include(s => s.Customer)
            .ToListAsync();

        var matchedSubscriptions = allSubscriptions
            .Where(s => s.SubscriptionNum != null && subNumbers.Contains(s.SubscriptionNum))
            .ToList();

        var sentCount = 0;
        foreach (var sub in matchedSubscriptions)
        {
            if (sub.Customer == null || string.IsNullOrEmpty(sub.Customer.Email))
                continue;

            var debt = unpaidDebts.First(d => d.SubscriptionNum == sub.SubscriptionNum);
            await _emailService.SendReminderAsync(sub.Customer.Email, sub.ServiceProvider, debt.DueDate);
            sentCount++;
        }

        return sentCount;
    }
}