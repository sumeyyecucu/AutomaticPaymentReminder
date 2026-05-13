using AutomaticPaymentReminder.Application.Features.Customers.Responses.Queries;
using MediatR;

namespace AutomaticPaymentReminder.Application.Features.Customers.Requests;

public class GetCustomerRequest : IRequest<GetCustomerResponse>
{
    public Guid Id { get; set; }
}