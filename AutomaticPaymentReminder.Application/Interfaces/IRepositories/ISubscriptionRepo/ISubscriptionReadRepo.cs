using AutomaticPaymentReminder.Application.Interfaces.IRepositories.IBaseRepo;
using AutomaticPaymentReminder.Domain.Entites;

namespace AutomaticPaymentReminder.Application.Interfaces.IRepositories.ISubscriptionRepo;

public interface ISubscriptionReadRepo : IBaseReadRepo<Subscriptions>
{
    Task<bool> ExistsBySubscriptionNumAndProviderAsync(Guid customerId, string subscriptionNum, string serviceProvider);
}