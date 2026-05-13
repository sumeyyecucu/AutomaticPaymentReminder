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
         .ForMember(dest => dest.SubscriptionId, opt => opt.MapFrom(src => src.Subscription != null ? src.Subscription.Id : Guid.Empty))
         .ForMember(dest => dest.ServiceProvider, opt => opt.MapFrom(src => src.Subscription != null ? src.Subscription.ServiceProvider : null))
         .ForMember(dest => dest.SubscriptionType, opt => opt.MapFrom(src => src.Subscription != null && src.Subscription.Type != null ? src.Subscription.Type.Name : null));
   }
}