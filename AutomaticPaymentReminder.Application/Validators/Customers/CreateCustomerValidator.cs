using AutomaticPaymentReminder.Application.Features.Customers.Requests;
using FluentValidation;

namespace AutomaticPaymentReminder.Application.Validators.Customers;

public class CreateCustomerValidator : AbstractValidator<CreateCustomerRequest>
{
    public CreateCustomerValidator()
    {
        RuleFor(x => x.NameSurname)
            .NotEmpty().WithMessage("Ad Soyad boş olamaz.")
            .MaximumLength(100).WithMessage("Ad Soyad 100 karakterden uzun olamaz.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("E-posta boş olamaz.")
            .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");

        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage("Telefon boş olamaz.")
            .Matches(@"^\+?[0-9]{10,15}$").WithMessage("Geçerli bir telefon numarası giriniz.");

       
    }
}