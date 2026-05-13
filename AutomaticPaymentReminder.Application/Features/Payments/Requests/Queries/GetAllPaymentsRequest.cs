using AutomaticPaymentReminder.Application.Features.Payments.Responses.Queries;
using MediatR;

namespace AutomaticPaymentReminder.Application.Features.Payments.Requests.Queries;

public class GetAllPaymentsRequest : IRequest<List<GetPaymentResponse>>
{
    
}