using AutoMapper;
using AutomaticPaymentReminder.Application.Features.SubscriptionTypes.Requests.Commands;
using AutomaticPaymentReminder.Application.Features.SubscriptionTypes.Responses.Queries;
using AutomaticPaymentReminder.Domain.Entites;

namespace AutomaticPaymentReminder.Application.Mappers;

public class SubscriptionTypeMappingProfile : Profile
{
    public SubscriptionTypeMappingProfile()
    {
        CreateMap<CreateSubscriptionTypeRequest, SubscriptionTypes>();
        CreateMap<SubscriptionTypes, GetSubscriptionTypeResponse>();
    }
}