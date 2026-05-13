using AutomaticPaymentReminder.Application.Interfaces.IRepositories.ICustomerRepo;
using AutomaticPaymentReminder.Application.Interfaces.IRepositories.IPaymentRepo;
using AutomaticPaymentReminder.Application.Interfaces.IRepositories.ISubscriptionRepo;
using AutomaticPaymentReminder.Application.Interfaces.IRepositories.ISubscriptionTypeRepo;
using AutomaticPaymentReminder.Application.Interfaces.IServices;
using AutomaticPaymentReminder.Infrastructure.Persistence;
using AutomaticPaymentReminder.Infrastructure.Repositories.CustomerRepo;
using AutomaticPaymentReminder.Infrastructure.Repositories.PaymentRepo;
using AutomaticPaymentReminder.Infrastructure.Repositories.SubscriptionRepo;
using AutomaticPaymentReminder.Infrastructure.Repositories.SubscriptionTypeRepo;
using AutomaticPaymentReminder.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AutomaticPaymentReminder.Infrastructure;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AutoPayReminderDbContext>(options =>
            options.UseMySQL(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<ICustomerReadRepo, CustomerReadRepo>();
        services.AddScoped<ICustomerWriteRepo, CustomerWriteRepo>();
        services.AddScoped<ISubscriptionReadRepo, SubscriptionReadRepo>();
        services.AddScoped<ISubscriptionWriteRepo, SubscriptionWriteRepo>();
        services.AddScoped<ISubscriptionTypeReadRepo, SubscriptionTypeReadRepo>();
        services.AddScoped<ISubscriptionTypeWriteRepo, SubscriptionTypeWriteRepo>();
        services.AddScoped<IPaymentReadRepo, PaymentReadRepo>();
        services.AddScoped<IPaymentWriteRepo, PaymentWriteRepo>();

        services.AddScoped<IPaymentGatewayService, MockPaymentGatewayService>();
        services.AddScoped<IDebtQueryService, MockDebtQueryService>();
        services.AddScoped<IEmailService, EmailService>();
    }
}