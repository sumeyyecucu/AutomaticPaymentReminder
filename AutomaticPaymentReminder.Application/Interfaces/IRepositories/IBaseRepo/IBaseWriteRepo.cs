using AutomaticPaymentReminder.Domain.Entites;

namespace AutomaticPaymentReminder.Application.Interfaces.IRepositories.IBaseRepo;

public interface IBaseWriteRepo <T> : IRepo<T> where T : BaseEntity
{
    Task<bool> AddAsync(T entity);
    bool Update(T entity);
    Task<bool> DeleteAsync(Guid id);
    Task SaveChangesAsync();

}