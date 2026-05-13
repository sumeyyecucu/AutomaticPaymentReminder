using AutomaticPaymentReminder.Application.Features.Customers.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AutomaticPaymentReminder.API.Controllers;

[ApiController]
[Route("api/customers")]
public class CustomerController : BaseController
{
    private readonly IMediator _mediator;

    public CustomerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await _mediator.Send(new GetAllCustomersRequest());
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var response = await _mediator.Send(new GetCustomerRequest { Id = id });
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCustomerRequest request)
    {
        
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCustomerRequest request)
    {
        
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var response = await _mediator.Send(new DeleteCustomerRequest { Id = id });
        return Ok(response);
    }
}