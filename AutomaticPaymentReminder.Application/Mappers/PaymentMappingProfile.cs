using AutoMapper;
using AutomaticPaymentReminder.Application.Features.Payments.Requests.Commands;
using AutomaticPaymentReminder.Application.Features.Payments.Responses.Queries;
using AutomaticPaymentReminder.Domain.Entites;

namespace AutomaticPaymentReminder.Application.Mappers;

public class PaymentMappingProfile : Profile
{
   public PaymentMappingProfile()
   {
      CreateMap<Payments, GetPaymentResponse>();
   }
}