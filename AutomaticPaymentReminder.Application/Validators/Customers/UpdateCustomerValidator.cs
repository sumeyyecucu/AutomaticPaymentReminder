using AutomaticPaymentReminder.Application.Features.Customers.Requests;
using FluentValidation;

namespace AutomaticPaymentReminder.Application.Validators.Customers;

public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerRequest>
{
    public UpdateCustomerValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Müşteri Id boş olamaz.");

        RuleFor(x => x.NameSurname)
            .NotEmpty().WithMessage("Ad Soyad boş olamaz.")
            .MaximumLength(100).WithMessage("Ad Soyad 100 karakterden uzun olamaz.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("E-posta boş olamaz.")
            .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");

        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage("Telefon boş olamaz.")
            .Matches(@"^\+?[0-9]{10,15}$").WithMessage("Geçerli bir telefon numarası giriniz.");

        RuleFor(x => x.CustomerNum)
            .GreaterThan(0).WithMessage("Müşteri numarası 0'dan büyük olmalıdır.");

        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("Adres boş olamaz.");

        RuleFor(x => x.City)
            .NotEmpty().WithMessage("Şehir boş olamaz.");

        RuleFor(x => x.State)
            .NotEmpty().WithMessage("İlçe/Eyalet boş olamaz.");
    }
}