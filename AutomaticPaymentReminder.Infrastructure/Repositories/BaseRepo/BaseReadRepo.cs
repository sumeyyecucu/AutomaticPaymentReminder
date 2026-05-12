using AutomaticPaymentReminder.Application.Interfaces.IRepositories.IBaseRepo;
using AutomaticPaymentReminder.Domain.Entites;
using AutomaticPaymentReminder.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AutomaticPaymentReminder.Infrastructure.Repositories.BaseRepo;

public class BaseReadRepo<T>(AutoPayReminderDbContext autoPayReminderDbContext) : IBaseReadRepo<T>
    where T : BaseEntity
{
    public DbSet<T> Table => autoPayReminderDbContext.Set<T>();
    public IQueryable<T> GetAll()  => Table;

    public async Task<T> GetByIdAsync(Guid id) => await Table.FindAsync(id);
}