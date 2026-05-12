using AutomaticPaymentReminder.Application.Interfaces.IRepositories.ICustomerRepo;
using AutomaticPaymentReminder.Domain.Entites;
using AutomaticPaymentReminder.Infrastructure.Persistence;
using AutomaticPaymentReminder.Infrastructure.Repositories.BaseRepo;

namespace AutomaticPaymentReminder.Infrastructure.Repositories.CustomerRepo;

public class CustomerReadRepo(AutoPayReminderDbContext autoPayReminderDbContext) : BaseReadRepo<Customers>(autoPayReminderDbContext), ICustomerReadRepo
{
    
}