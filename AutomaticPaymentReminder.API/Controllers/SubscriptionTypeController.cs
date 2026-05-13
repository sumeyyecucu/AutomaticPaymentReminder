using AutomaticPaymentReminder.Application.Features.SubscriptionTypes.Requests.Commands;
using AutomaticPaymentReminder.Application.Features.SubscriptionTypes.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AutomaticPaymentReminder.API.Controllers;

[ApiController]
[Route("api/subscriptionTypes")]
public class SubscriptionTypeController : BaseController
{
    private readonly IMediator _mediator;

    public SubscriptionTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await _mediator.Send(new GetAllSubscriptionTypesRequest());
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSubscriptionTypeRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var response = await _mediator.Send(new DeleteSubscriptionTypeRequest { Id = id });
        return Ok(response);
    }
}