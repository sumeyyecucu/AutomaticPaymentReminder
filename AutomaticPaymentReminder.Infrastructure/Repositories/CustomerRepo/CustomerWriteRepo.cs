using AutomaticPaymentReminder.Application.IRepositories.ICustomerRepo;
using AutomaticPaymentReminder.Domain.Entites;
using AutomaticPaymentReminder.Infrastructure.Persistence;
using AutomaticPaymentReminder.Infrastructure.Repositories.BaseRepo;

namespace AutomaticPaymentReminder.Infrastructure.Repositories.CustomerRepo;

public class CustomerWriteRepo(AutoPayReminderDbContext dbContext) : BaseWriteRepo<Customers>(dbContext), ICustomerWriteRepo
{
    
}