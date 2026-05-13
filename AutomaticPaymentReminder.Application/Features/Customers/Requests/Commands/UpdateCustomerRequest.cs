using AutomaticPaymentReminder.Application.Features.Customers.Responses.Commands;
using MediatR;

namespace AutomaticPaymentReminder.Application.Features.Customers.Requests;

public class UpdateCustomerRequest : IRequest<UpdateCustomerResponse>
{
    public Guid Id { get; set; }
    public int CustomerNum { get; set; }
    public string NameSurname { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
}
