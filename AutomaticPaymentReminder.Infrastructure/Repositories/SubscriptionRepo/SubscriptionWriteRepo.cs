using AutomaticPaymentReminder.Application.Interfaces.IRepositories.ISubscriptionRepo;
using AutomaticPaymentReminder.Domain.Entites;
using AutomaticPaymentReminder.Infrastructure.Persistence;
using AutomaticPaymentReminder.Infrastructure.Repositories.BaseRepo;

namespace AutomaticPaymentReminder.Infrastructure.Repositories.SubscriptionRepo;

public class SubscriptionWriteRepo(AutoPayReminderDbContext dbContext) : BaseWriteRepo<Subscriptions>(dbContext),ISubscriptionWriteRepo
{
    
}