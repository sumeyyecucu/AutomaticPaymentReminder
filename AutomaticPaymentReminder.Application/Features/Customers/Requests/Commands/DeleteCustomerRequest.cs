using AutomaticPaymentReminder.Application.Features.Customers.Responses.Commands;
using MediatR;

namespace AutomaticPaymentReminder.Application.Features.Customers.Requests;

public class DeleteCustomerRequest : IRequest<DeleteCustomerResponse>
{
    public Guid Id { get; set; }
}