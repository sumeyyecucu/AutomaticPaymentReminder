using AutomaticPaymentReminder.Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace AutomaticPaymentReminder.Application.Interfaces.IRepositories.IBaseRepo;

public interface IRepo<T> where T : BaseEntity
{
    DbSet<T> Table  { get;}
}