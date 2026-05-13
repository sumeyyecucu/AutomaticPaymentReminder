using AutomaticPaymentReminder.Application.Features.Payments.Responses.Commands;
using MediatR;

namespace AutomaticPaymentReminder.Application.Features.Payments.Requests.Commands;

public class CreatePaymentRequest : IRequest<CreatePaymentResponse>
{
    public Guid SubscriptionId { get; set; }
    public decimal Amount { get; set; }
    public int  Month { get; set; }
    public int Year { get; set; }
}