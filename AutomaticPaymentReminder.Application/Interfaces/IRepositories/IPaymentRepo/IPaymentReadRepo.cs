using AutomaticPaymentReminder.Application.Interfaces.IRepositories.IBaseRepo;
using AutomaticPaymentReminder.Domain.Entites;

namespace AutomaticPaymentReminder.Application.Interfaces.IRepositories.IPaymentRepo;

public interface IPaymentReadRepo : IBaseReadRepo<Payments>
{
    
}