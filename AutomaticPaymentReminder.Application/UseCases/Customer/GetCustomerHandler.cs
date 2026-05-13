using AutoMapper;
using AutomaticPaymentReminder.Application.Features.Customers.Requests;
using AutomaticPaymentReminder.Application.Features.Customers.Responses.Queries;
using AutomaticPaymentReminder.Application.Interfaces.IRepositories.ICustomerRepo;
using MediatR;

namespace AutomaticPaymentReminder.Application.UseCases.Customer;

public class GetCustomerHandler : IRequestHandler<GetCustomerRequest, GetCustomerResponse>
{
    private readonly ICustomerReadRepo _customerReadRepo;
    private readonly IMapper _mapper;

    public GetCustomerHandler(ICustomerReadRepo customerReadRepo, IMapper mapper)
    {
        _customerReadRepo = customerReadRepo;
        _mapper = mapper;
    }

    public async Task<GetCustomerResponse> Handle(GetCustomerRequest request, CancellationToken cancellationToken)
    {
        var entity = await _customerReadRepo.GetByIdAsync(request.Id);
        return _mapper.Map<GetCustomerResponse>(entity);
    }
}
