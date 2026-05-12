using AutomaticPaymentReminder.Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace AutomaticPaymentReminder.Infrastructure.Persistence;

public class AutoPayReminderDbContext : DbContext
{
    public AutoPayReminderDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Customers> Customers { get; set; }
    public DbSet<Payments> Payments { get; set; }
    public DbSet<Subscriptions> Subscriptions { get; set; }
    public DbSet<SubscriptionTypes>  SubscriptionTypes { get; set; }
}