using AutomaticPaymentReminder.Application.Features.Customers.Requests;
using AutomaticPaymentReminder.Application.Features.Customers.Requests.Commands;
using FluentValidation;

namespace AutomaticPaymentReminder.Application.Validators.Customers;

public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerRequest>
{
    public UpdateCustomerValidator()
    {

        RuleFor(x => x.NameSurname)
            .NotEmpty().WithMessage("Ad Soyad boş olamaz.")
            .MaximumLength(100).WithMessage("Ad Soyad 100 karakterden uzun olamaz.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("E-posta boş olamaz.")
            .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");

        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage("Telefon boş olamaz.")
            .Matches(@"^05[0-9]{9}$").WithMessage("Telefon numarası 05 ile başlamalı ve 11 haneli olmalıdır.");
    }
}