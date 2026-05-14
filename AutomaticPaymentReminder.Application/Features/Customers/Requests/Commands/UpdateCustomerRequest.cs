using AutomaticPaymentReminder.Application.Features.Customers.Responses.Commands;
using MediatR;

namespace AutomaticPaymentReminder.Application.Features.Customers.Requests.Commands;

public class UpdateCustomerRequest : IRequest<UpdateCustomerResponse>
{
   
    
    public string NameSurname { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
   
}
