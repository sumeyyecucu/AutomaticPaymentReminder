using AutomaticPaymentReminder.Application.Interfaces.IRepositories.ISubscriptionRepo;
using AutomaticPaymentReminder.Domain.Entites;
using AutomaticPaymentReminder.Infrastructure.Persistence;
using AutomaticPaymentReminder.Infrastructure.Repositories.BaseRepo;
using Microsoft.EntityFrameworkCore;

namespace AutomaticPaymentReminder.Infrastructure.Repositories.SubscriptionRepo;

public class SubscriptionReadRepo(AutoPayReminderDbContext autoPayReminderDbContext, ISubscriptionReadRepo subscriptionReadRepo) : BaseReadRepo<Subscriptions>(autoPayReminderDbContext), ISubscriptionReadRepo
{
    private readonly ISubscriptionReadRepo _subscriptionReadRepo = subscriptionReadRepo;
    
    public async Task<bool> ExistsBySubscriptionNumAndProviderAsync(
        Guid customerId, string subscriptionNum, string serviceProvider)
        => await _subscriptionReadRepo.Table
            .AnyAsync(s => s.Customer.Id == customerId
                           && s.SubscriptionNum == subscriptionNum
                           && s.ServiceProvider == serviceProvider);
}