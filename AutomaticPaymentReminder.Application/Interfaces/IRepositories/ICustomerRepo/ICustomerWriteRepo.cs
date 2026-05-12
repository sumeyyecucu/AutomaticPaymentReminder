using AutomaticPaymentReminder.Application.Interfaces.IRepositories.IBaseRepo;
using AutomaticPaymentReminder.Domain.Entites;

namespace AutomaticPaymentReminder.Application.Interfaces.IRepositories.ICustomerRepo;

public interface ICustomerWriteRepo : IBaseWriteRepo<Customers>
{
    
}