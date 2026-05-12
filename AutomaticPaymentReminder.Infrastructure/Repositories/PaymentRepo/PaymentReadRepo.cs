using AutomaticPaymentReminder.Application.Interfaces.IRepositories.IPaymentRepo;
using AutomaticPaymentReminder.Domain.Entites;
using AutomaticPaymentReminder.Infrastructure.Persistence;
using AutomaticPaymentReminder.Infrastructure.Repositories.BaseRepo;

namespace AutomaticPaymentReminder.Infrastructure.Repositories.PaymentRepo;

public class PaymentReadRepo(AutoPayReminderDbContext autoPayReminderDbContext) : BaseReadRepo<Payments>(autoPayReminderDbContext), IPaymentReadRepo
{
    
}