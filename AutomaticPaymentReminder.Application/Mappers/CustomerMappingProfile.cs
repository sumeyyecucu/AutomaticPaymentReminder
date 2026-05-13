using AutoMapper;
using AutomaticPaymentReminder.Application.Features.Customers.Requests;
using AutomaticPaymentReminder.Application.Features.Customers.Responses.Queries;
using AutomaticPaymentReminder.Domain.Entites;

namespace AutomaticPaymentReminder.Application.Mappers;

public class CustomerMappingProfile : Profile
{
    public CustomerMappingProfile()
    {
        CreateMap<CreateCustomerRequest, Customers>();
        CreateMap<UpdateCustomerRequest, Customers>();
     
        CreateMap<Customers, GetCustomerResponse>();
    }
}
