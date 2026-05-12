using AutomaticPaymentReminder.Domain.Entites;

namespace AutomaticPaymentReminder.Application.IRepositories.IBaseRepo;

public interface IBaseWriteRepo <T> : IRepo<T> where T : BaseEntity
{
    Task<bool> AddAsync(T entity);
    bool UpdateAsync(T entity);
    Task<bool> DeleteAsync(Guid id);
    Task SaveChangesAsync();

}