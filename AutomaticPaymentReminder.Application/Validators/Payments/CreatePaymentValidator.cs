using AutomaticPaymentReminder.Application.Features.Payments.Requests.Commands;
using FluentValidation;

namespace AutomaticPaymentReminder.Application.Validators.Payments;

public class CreatePaymentValidator : AbstractValidator<CreatePaymentRequest>
{
    public CreatePaymentValidator()
    {
        RuleFor(x => x.SubscriptionId)
            .NotEmpty().WithMessage("Abonelik Id boş olamaz.");

        RuleFor(x => x.Amount)
            .GreaterThan(0).WithMessage("Ödeme tutarı 0'dan büyük olmalıdır.");

        RuleFor(x => x.Month)
            .InclusiveBetween(1, 12).WithMessage("Ay 1 ile 12 arasında olmalıdır.");

        RuleFor(x => x.Year)
            .GreaterThanOrEqualTo(2000).WithMessage("Yıl 2000'den küçük olamaz.");
    }
}