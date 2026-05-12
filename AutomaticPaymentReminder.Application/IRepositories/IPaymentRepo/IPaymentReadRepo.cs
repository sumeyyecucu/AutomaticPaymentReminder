using AutomaticPaymentReminder.Application.IRepositories.IBaseRepo;
using AutomaticPaymentReminder.Domain.Entites;

namespace AutomaticPaymentReminder.Application.IRepositories.IPaymentRepo;

public interface IPaymentReadRepo : IBaseReadRepo<Payments>
{
    
}