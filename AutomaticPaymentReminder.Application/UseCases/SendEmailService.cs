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

    public async Task SendReminder()
    {
        var unpaidDebts = await GetUnpaidDebts();
        var subNumbers = unpaidDebts.Select(d => d.SubscriptionNum).ToList();
        
        var subscriptions = await _subscriptionReadRepo.GetAll()
            .Where(s => subNumbers.Contains(s.SubscriptionNum))
            .Include(s => s.Customer)
            .ToListAsync();
        foreach (var sub in subscriptions)
        {
            var debt = unpaidDebts.First(d => d.SubscriptionNum == sub.SubscriptionNum);
            await _emailService.SendReminderAsync(sub.Customer.Email,sub.ServiceProvider,debt.DueDate);
        }
    }
}