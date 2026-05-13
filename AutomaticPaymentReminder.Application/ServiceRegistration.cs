using AutomaticPaymentReminder.Application.Behaviors;
using AutomaticPaymentReminder.Application.UseCases;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace AutomaticPaymentReminder.Application;

public static class ServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceRegistration).Assembly));
        services.AddAutoMapper(cfg => cfg.AddMaps(typeof(ServiceRegistration).Assembly));
        services.AddValidatorsFromAssembly(typeof(ServiceRegistration).Assembly);
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddScoped<SendEmailService>();
    }
}