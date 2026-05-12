using AutomaticPaymentReminder.Application.Interfaces.IRepositories.IBaseRepo;
using AutomaticPaymentReminder.Domain.Entites;
using AutomaticPaymentReminder.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AutomaticPaymentReminder.Infrastructure.Repositories.BaseRepo;

public class BaseWriteRepo<T>(AutoPayReminderDbContext dbContext) : IBaseWriteRepo<T>
    where T : BaseEntity
{
    private readonly AutoPayReminderDbContext _dbContext = dbContext;


    public DbSet<T> Table => _dbContext.Set<T>();
    public async Task<bool> AddAsync(T entity)
    {
       EntityEntry<T> entry = await Table.AddAsync(entity);
       return entry.State == EntityState.Added;
    }

    public bool UpdateAsync(T entity)
    {
       EntityEntry<T> entry = Table.Update(entity);
       return entry.State == EntityState.Modified;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        T entity = await Table.FirstOrDefaultAsync(p => p.Id == id);
        if (entity is null)
            return false;
        EntityEntry<T> entry = Table.Remove(entity);
        return entry.State == EntityState.Deleted;
    }

    public async Task SaveChangesAsync() => await _dbContext.SaveChangesAsync();
}