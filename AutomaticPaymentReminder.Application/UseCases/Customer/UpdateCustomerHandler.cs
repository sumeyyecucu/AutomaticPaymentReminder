using AutoMapper;
using AutomaticPaymentReminder.Application.Features.Customers.Requests;
using AutomaticPaymentReminder.Application.Features.Customers.Responses.Commands;
using AutomaticPaymentReminder.Application.Interfaces.IRepositories.ICustomerRepo;
using AutomaticPaymentReminder.Domain.Entites;
using MediatR;

namespace AutomaticPaymentReminder.Application.UseCases.Customer;

public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerRequest, UpdateCustomerResponse>
{
    private readonly ICustomerWriteRepo _customerWriteRepo;
    private readonly IMapper _mapper;

    public UpdateCustomerHandler(ICustomerWriteRepo customerWriteRepo, IMapper mapper)
    {
        _customerWriteRepo = customerWriteRepo;
        _mapper = mapper;
    }

    public async Task<UpdateCustomerResponse> Handle(UpdateCustomerRequest request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Customers>(request);
        _customerWriteRepo.Update(entity);
        await _customerWriteRepo.SaveChangesAsync();
        return new UpdateCustomerResponse();
    }
}