using AutomaticPaymentReminder.Application.Features.Subscriptions.Requests;
using AutomaticPaymentReminder.Application.Features.Subscriptions.Requests.Commands;
using AutomaticPaymentReminder.Application.Features.Subscriptions.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AutomaticPaymentReminder.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubscriptionController : BaseController
{
    private readonly IMediator _mediator;

    public SubscriptionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await _mediator.Send(new GetAllSubscriptionsRequest());
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var response = await _mediator.Send(new GetSubscriptionRequest { Id = id });
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSubscriptionRequest request)
    {
        var customerId = GetCustomerId();
        request.CustomerId = customerId;
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateSubscriptionRequest request)
    {
        request.Id = id;
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var response = await _mediator.Send(new DeleteSubscriptionRequest { Id = id });
        return Ok(response);
    }
}