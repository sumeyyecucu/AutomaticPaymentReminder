using AutomaticPaymentReminder.Application.Features.Debt.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AutomaticPaymentReminder.API.Controllers;

[ApiController]
[Route("api/debt")]
public class DebtController : BaseController
{
    private readonly IMediator _mediator;

    public DebtController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{number}")]
    public async Task<IActionResult> Get(string number)
    {
        var response = await _mediator.Send(new GetDebtRequest { Number = number });
        return Ok(response);
    }
}