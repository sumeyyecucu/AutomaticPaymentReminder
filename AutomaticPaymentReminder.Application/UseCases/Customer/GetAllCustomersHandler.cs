using AutoMapper;
using AutomaticPaymentReminder.Application.Features.Customers.Requests;
using AutomaticPaymentReminder.Application.Features.Customers.Responses.Queries;
using AutomaticPaymentReminder.Application.Interfaces.IRepositories.ICustomerRepo;
using MediatR;

namespace AutomaticPaymentReminder.Application.UseCases.Customer;

public class GetAllCustomersHandler : IRequestHandler<GetAllCustomersRequest, List<GetCustomerResponse>>
{
    private readonly ICustomerReadRepo _customerReadRepo;
    private readonly IMapper _mapper;

    public GetAllCustomersHandler(ICustomerReadRepo customerReadRepo, IMapper mapper)
    {
        _customerReadRepo = customerReadRepo;
        _mapper = mapper;
    }

    public async Task<List<GetCustomerResponse>> Handle(GetAllCustomersRequest request, CancellationToken cancellationToken)
    {
        var entities = _customerReadRepo.GetAll();
        return _mapper.Map<List<GetCustomerResponse>>(entities);
    }
}