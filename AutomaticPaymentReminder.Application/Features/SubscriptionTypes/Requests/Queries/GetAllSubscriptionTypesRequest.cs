using AutomaticPaymentReminder.Application.Features.SubscriptionTypes.Responses.Queries;
using MediatR;

namespace AutomaticPaymentReminder.Application.Features.SubscriptionTypes.Requests.Queries;

public class GetAllSubscriptionTypesRequest : IRequest<List<GetSubscriptionTypeResponse>>
{
}