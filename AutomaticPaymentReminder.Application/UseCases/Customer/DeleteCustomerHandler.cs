using AutomaticPaymentReminder.Application.Features.Customers.Requests;
using AutomaticPaymentReminder.Application.Features.Customers.Responses.Commands;
using AutomaticPaymentReminder.Application.Interfaces.IRepositories.ICustomerRepo;
using MediatR;

namespace AutomaticPaymentReminder.Application.UseCases.Customer;

public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerRequest, DeleteCustomerResponse>
{
    private readonly ICustomerWriteRepo _customerWriteRepo;

    public DeleteCustomerHandler(ICustomerWriteRepo customerWriteRepo)
    {
        _customerWriteRepo = customerWriteRepo;
    }

    public async Task<DeleteCustomerResponse> Handle(DeleteCustomerRequest request, CancellationToken cancellationToken)
    {
        await _customerWriteRepo.DeleteAsync(request.Id);
        await _customerWriteRepo.SaveChangesAsync();
        return new DeleteCustomerResponse();
    }
}