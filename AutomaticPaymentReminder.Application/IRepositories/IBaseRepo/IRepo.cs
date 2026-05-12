using AutomaticPaymentReminder.Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace AutomaticPaymentReminder.Application.IRepositories.IBaseRepo;

public interface IRepo<T> where T : BaseEntity
{
    DbSet<T> Table  { get;}
}