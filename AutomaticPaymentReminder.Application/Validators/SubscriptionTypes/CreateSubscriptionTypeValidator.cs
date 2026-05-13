using AutomaticPaymentReminder.Application.Features.SubscriptionTypes.Requests.Commands;
using FluentValidation;

namespace AutomaticPaymentReminder.Application.Validators.SubscriptionTypes;

public class CreateSubscriptionTypeValidator : AbstractValidator<CreateSubscriptionTypeRequest>
{
    public CreateSubscriptionTypeValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Abonelik tipi adı boş olamaz.")
            .MaximumLength(100).WithMessage("Abonelik tipi adı 100 karakterden uzun olamaz.");
    }
}