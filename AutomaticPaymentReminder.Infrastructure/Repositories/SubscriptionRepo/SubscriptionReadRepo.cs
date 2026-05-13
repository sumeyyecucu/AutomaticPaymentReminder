using AutomaticPaymentReminder.Application.Interfaces.IRepositories.ISubscriptionRepo;
using AutomaticPaymentReminder.Domain.Entites;
using AutomaticPaymentReminder.Infrastructure.Persistence;
using AutomaticPaymentReminder.Infrastructure.Repositories.BaseRepo;

namespace AutomaticPaymentReminder.Infrastructure.Repositories.SubscriptionRepo;

public class SubscriptionReadRepo(AutoPayReminderDbContext autoPayReminderDbContext) : BaseReadRepo<Subscriptions>(autoPayReminderDbContext), ISubscriptionReadRepo
{
    public Task<bool> ExistsBySubscriptionNumAndProviderAsync(Guid customerId, string subscriptionNum, string serviceProvider)
        => Task.FromResult(autoPayReminderDbContext.Set<Subscriptions>()
            .Any(s => s.Customer.Id == customerId
                   && s.SubscriptionNum == subscriptionNum
                   && s.ServiceProvider == serviceProvider));
}