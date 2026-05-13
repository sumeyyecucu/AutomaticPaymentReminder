using AutomaticPaymentReminder.Application.Interfaces.IServices;
using AutomaticPaymentReminder.Infrastructure.Persistence;
using AutomaticPaymentReminder.Infrastructure.Services;
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
        services.AddScoped<IPaymentGatewayService, MockPaymentGatewayService>();
        services.AddScoped<IDebtQueryService, MockDebtQueryService>();
    }
}