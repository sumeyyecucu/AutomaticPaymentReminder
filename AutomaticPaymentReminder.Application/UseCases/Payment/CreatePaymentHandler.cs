using AutomaticPaymentReminder.Application.Features.Payments.Requests.Commands;
using AutomaticPaymentReminder.Application.Features.Payments.Responses.Commands;
using AutomaticPaymentReminder.Application.Interfaces.IRepositories.IPaymentRepo;
using AutomaticPaymentReminder.Application.Interfaces.IRepositories.ISubscriptionRepo;
using AutomaticPaymentReminder.Application.Interfaces.IServices;
using AutomaticPaymentReminder.Domain.Entites;
using MediatR;

namespace AutomaticPaymentReminder.Application.UseCases.Payment;

public class CreatePaymentHandler : IRequestHandler<CreatePaymentRequest, CreatePaymentResponse>
{
    private readonly IPaymentGatewayService _paymentGatewayService;
    private readonly IPaymentWriteRepo _paymentWriteRepo;
    private readonly ISubscriptionReadRepo _subscriptionReadRepo;

    public CreatePaymentHandler(IPaymentGatewayService paymentGatewayService, IPaymentWriteRepo paymentWriteRepo, ISubscriptionReadRepo subscriptionReadRepo)
    {
        _paymentGatewayService = paymentGatewayService;
        _paymentWriteRepo = paymentWriteRepo;
        _subscriptionReadRepo = subscriptionReadRepo;
    }

    public async Task<CreatePaymentResponse> Handle(CreatePaymentRequest request, CancellationToken cancellationToken)
    {
        var subscription = await _subscriptionReadRepo.GetByIdAsync(request.SubscriptionId);

        var success = await _paymentGatewayService.ProcessPaymentAsync(request.SubscriptionId, request.Amount);

        var newPayment = new Payments
        {
            Id = Guid.NewGuid(),
            Amount = request.Amount,
            PaymentDate = DateTime.Now,
            Month = request.Month,
            Year = request.Year,
            IsPaid = success,
            Subscription = subscription
        };

        await _paymentWriteRepo.AddAsync(newPayment);
        await _paymentWriteRepo.SaveChangesAsync();

        return new CreatePaymentResponse { Success = success };
    }
}