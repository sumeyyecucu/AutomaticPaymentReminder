using AutomaticPaymentReminder.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace AutomaticPaymentReminder.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseController : ControllerBase
{
    protected Guid GetCustomerId()
    {
        var header = Request.Headers["X-Customer-Id"].FirstOrDefault();
        if (!Guid.TryParse(header, out var customerId))
            throw new UnauthorizedException("Geçersiz müşteri kimliği.");
        return customerId;
    }
}