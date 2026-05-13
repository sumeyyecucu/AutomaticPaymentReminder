using AutomaticPaymentReminder.Application.Features.Subscriptions.Requests;
using FluentValidation;

namespace AutomaticPaymentReminder.Application.Validators.Subscriptions;

public class UpdateSubscriptionValidator : AbstractValidator<UpdateSubscriptionRequest>
{
    public UpdateSubscriptionValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Abonelik Id boş olamaz.");

        RuleFor(x => x.SubscriptionId)
            .NotEmpty().WithMessage("Abonelik tipi boş olamaz.");
    }
}