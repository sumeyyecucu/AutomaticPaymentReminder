using AutomaticPaymentReminder.Application.Features.Payments.Requests.Commands;
using AutomaticPaymentReminder.Application.Features.Payments.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AutomaticPaymentReminder.API.Controllers;

[ApiController]
[Route("api/payments")]
public class PaymentController : BaseController
{
    private readonly IMediator _mediator;

    public PaymentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await _mediator.Send(new GetAllPaymentsRequest());
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePaymentRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}
