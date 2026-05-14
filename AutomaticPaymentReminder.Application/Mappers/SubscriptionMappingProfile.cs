using AutoMapper;
using AutomaticPaymentReminder.Application.Features.Subscriptions.Requests;
using AutomaticPaymentReminder.Application.Features.Subscriptions.Requests.Commands;
using AutomaticPaymentReminder.Application.Features.Subscriptions.Responses.Queries;
using AutomaticPaymentReminder.Domain.Entites;

namespace AutomaticPaymentReminder.Application.Mappers;

public class SubscriptionMappingProfile : Profile
{
    public SubscriptionMappingProfile()
    {
        CreateMap<CreateSubscriptionRequest, Subscriptions>();
        CreateMap<UpdateSubscriptionRequest, Subscriptions>();
        CreateMap<Subscriptions, GetSubscriptionResponse>()
            .ForMember(dest => dest.SubscriptionType, opt => opt.MapFrom(src => src.Type.Name))
            .ForMember(dest => dest.SubscriptionTypeId, opt => opt.MapFrom(src =>  src.Type.Id));
    }
}