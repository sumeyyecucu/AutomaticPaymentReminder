using AutomaticPaymentReminder.Domain.Entites;

namespace AutomaticPaymentReminder.Application.IRepositories.IBaseRepo;

public interface IBaseReadRepo <T> : IRepo<T>  where T : BaseEntity
{
    IQueryable<T> GetAll();
    Task <T> GetByIdAsync(Guid id);

    
}