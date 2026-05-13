using AutoMapper;
using AutomaticPaymentReminder.Application.Features.Customers.Requests;
using AutomaticPaymentReminder.Application.Features.Customers.Responses.Commands;
using AutomaticPaymentReminder.Application.Interfaces.IRepositories.ICustomerRepo;
using AutomaticPaymentReminder.Domain.Entites;
using MediatR;

namespace AutomaticPaymentReminder.Application.UseCases.Customer;

public class CreateCustomerHandler : IRequestHandler<CreateCustomerRequest, CreateCustomerResponse>
{
    private readonly ICustomerWriteRepo _customerWriteRepo;
    private readonly IMapper _mapper;

    public CreateCustomerHandler(ICustomerWriteRepo customerWriteRepo, IMapper mapper)
    {
        _customerWriteRepo = customerWriteRepo;
        _mapper = mapper;
    }

    public async Task<CreateCustomerResponse> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Customers>(request);
        await _customerWriteRepo.AddAsync(entity);
        await _customerWriteRepo.SaveChangesAsync();
        return new CreateCustomerResponse();
    }
}