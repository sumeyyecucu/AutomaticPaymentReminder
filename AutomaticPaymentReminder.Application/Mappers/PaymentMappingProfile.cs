using AutoMapper;
using AutomaticPaymentReminder.Application.Features.Payments.Requests.Commands;
using AutomaticPaymentReminder.Application.Features.Payments.Responses.Queries;
using AutomaticPaymentReminder.Domain.Entites;

namespace AutomaticPaymentReminder.Application.Mappers;

public class PaymentMappingProfile : Profile
{
   public PaymentMappingProfile()
   {
      CreateMap<Payments, GetPaymentResponse>()
         .ForMember(dest => dest.SubscriptionId, opt => opt.MapFrom(src => src.Subscription.Id ))
         .ForMember(dest => dest.ServiceProvider, opt => opt.MapFrom(src => src.Subscription.ServiceProvider))
         .ForMember(dest => dest.SubscriptionType, opt => opt.MapFrom(src =>  src.Subscription.Type.Name));
   }
}