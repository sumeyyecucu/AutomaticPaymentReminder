using AutomaticPaymentReminder.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AutomaticPaymentReminder.Infrastructure;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration )
    {
        services.AddDbContext<AutoPayReminderDbContext>(options =>
            options.UseMySQL(configuration.GetConnectionString("DefaultConnection")));
    }
}