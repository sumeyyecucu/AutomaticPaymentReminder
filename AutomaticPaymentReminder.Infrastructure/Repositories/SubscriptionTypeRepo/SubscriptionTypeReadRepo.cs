using AutomaticPaymentReminder.Application.IRepositories.ISubscriptionTypeRepo;
using AutomaticPaymentReminder.Domain.Entites;
using AutomaticPaymentReminder.Infrastructure.Persistence;
using AutomaticPaymentReminder.Infrastructure.Repositories.BaseRepo;

namespace AutomaticPaymentReminder.Infrastructure.Repositories.SubscriptionTypeRepo;

public class SubscriptionTypeReadRepo(AutoPayReminderDbContext autoPayReminderDbContext) : BaseReadRepo<SubscriptionTypes>(autoPayReminderDbContext), ISubscriptionTypeReadRepo
{
    
}