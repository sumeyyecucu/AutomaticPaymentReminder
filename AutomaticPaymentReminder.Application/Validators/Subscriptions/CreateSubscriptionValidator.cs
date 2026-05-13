using AutomaticPaymentReminder.Application.Features.Subscriptions.Requests.Commands;
using AutomaticPaymentReminder.Application.Interfaces.IRepositories.ISubscriptionRepo;
using FluentValidation;

namespace AutomaticPaymentReminder.Application.Validators.Subscriptions;

public class CreateSubscriptionValidator : AbstractValidator<CreateSubscriptionRequest>
{
    public CreateSubscriptionValidator(ISubscriptionReadRepo subscriptionReadRepo)
    {
        RuleFor(x => x.CustomerId)
            .NotEmpty().WithMessage("Müşteri Id boş olamaz.");
        

        RuleFor(x => x.SubscriptionId)
            .NotEmpty().WithMessage("Abonelik tipi boş olamaz.");

        RuleFor(x => x)
            .MustAsync(async (request, _) =>
                !await subscriptionReadRepo.ExistsBySubscriptionNumAndProviderAsync(
                    request.CustomerId,
                    request.SubscriptionNum!.Value.ToString(),
                    request.ServiceProvider ?? string.Empty))
            .When(x => x.SubscriptionNum.HasValue && !string.IsNullOrEmpty(x.ServiceProvider))
            .WithMessage("Bu müşteriye ait aynı sağlayıcıdan aynı abonelik numarası zaten mevcut.");
    }
}
